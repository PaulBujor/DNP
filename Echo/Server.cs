using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace Echo
{
	class Server
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting server...");

			IPAddress ip = IPAddress.Parse("127.0.0.1");
			TcpListener listener = new TcpListener(ip, 5000);
			listener.Start();

			Console.WriteLine("Server started...");

			while(true)
			{
				TcpClient client = listener.AcceptTcpClient();
				Thread clientHandler = new Thread(new ClientHandler(client).Run);
				clientHandler.Start();
			}
		}
	}

	class ClientHandler
	{
		private TcpClient client;

		public ClientHandler(TcpClient client)
		{
			this.client = client;
		}

		public void Run()
		{
			Console.WriteLine("Client connected");
			NetworkStream stream = client.GetStream();

			bool stayConnected = true;

			while (stayConnected)
			{
				try
				{
					//read
					byte[] dataFromClient = new byte[1024];
					int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
					string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
					Console.WriteLine(s);
					stayConnected = !s.Equals("exit");

					if (stayConnected)
					{
						//reply
						byte[] dataToClient = Encoding.ASCII.GetBytes($"Reply: {s}");
						stream.Write(dataToClient, 0, dataToClient.Length);
					}
				} catch (System.IO.IOException e)
				{
					Console.WriteLine("Client disconnected with force.");
					stayConnected = false;
				}
			}

			Console.WriteLine("Client disconnected...");
			client.Close();
		}
	}
}
