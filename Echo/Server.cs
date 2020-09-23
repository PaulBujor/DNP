using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace Echo
{
	class Server
	{
		private List<ClientHandler> clients;

		public Action<string> OnMessageReceive;

		static void Main(string[] args)
		{
			new Server().Run();
		}

		public Server()
		{
			clients = new List<ClientHandler>();
		}

		public void Run()
		{
			Console.WriteLine("Starting server...");

			IPAddress ip = IPAddress.Parse("127.0.0.1");
			TcpListener listener = new TcpListener(ip, 6969);
			listener.Start();

			Console.WriteLine("Server started...");
			OnMessageReceive += Send;

			while (true)
			{
				TcpClient client = listener.AcceptTcpClient();
				ClientHandler clientHandler = new ClientHandler(client, OnMessageReceive);
				clientHandler.ClientDisconnected += Disconnect;
				clients.Add(clientHandler);

				Thread clientThread = new Thread(clientHandler.Run);
				clientThread.Start();
			}
		}

		public void Send(string s)
		{
			foreach (ClientHandler client in clients)
			{
				client.Send(s);
			}
		}

		public void Disconnect(ClientHandler client)
		{
			clients.Remove(client);
		}
	}

	class ClientHandler
	{
		private TcpClient client;
		private NetworkStream stream;

		public Action<string> OnMessageReceive;
		public Action<ClientHandler> ClientDisconnected;

		public ClientHandler(TcpClient client, Action<String> action)
		{
			this.client = client;
			stream = client.GetStream();
			OnMessageReceive = action;
		}

		public void Run()
		{
			Console.WriteLine("Client connected");

			bool stayConnected = true;

			while (stayConnected)
			{
				try
				{
					//read
					byte[] dataFromClient = new byte[1024];
					int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
					string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
					OnMessageReceive?.Invoke(s);
					stayConnected = !s.Equals("exit");
				}
				catch (System.IO.IOException e)
				{
					Console.WriteLine("Client force disconnected.");
					stayConnected = false;
				}
			}
			Disconnect();

			Console.WriteLine("Client disconnected...");
			client.Close();
		}

		public void Send(String s)
		{
			byte[] dataToClient = Encoding.ASCII.GetBytes(s);
			stream.Write(dataToClient, 0, dataToClient.Length);
		}

		public void Disconnect()
		{
			ClientDisconnected?.Invoke(this);
		}
	}
}
