using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EchoClient
{
	class Client
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting client...");

			TcpClient client = new TcpClient("localhost", 5000);

			NetworkStream stream = client.GetStream();

			bool connected = true;

			string msg = "connect";

			new Thread(() =>
			{
				while (connected)
				{
					byte[] dataFromServer = new byte[1024];
					int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
					string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
					Console.WriteLine(response);
				}
			}).Start();

			while (connected)
			{
				msg = Console.ReadLine();

				if (!msg.Equals("exit"))
				{
					byte[] dataToServer = Encoding.ASCII.GetBytes(msg);
					stream.Write(dataToServer, 0, dataToServer.Length);
				}
				else
				{
					connected = false;
				}
			}

			stream.Close();
			client.Close();
		}
	}
}
