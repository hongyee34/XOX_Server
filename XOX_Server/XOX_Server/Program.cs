using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace XOX_Server
{
    class Program
    {
        private static List<TcpClient> clientList = new List<TcpClient>();

        static void Main(string[] args)
        {
            Server().Wait();
        }
        async static Task Server()
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.0.15"), 6974);
            listener.Start();
            Console.WriteLine("서버 실행중");
            while (true)
            {
                // 비동기 Accept                
                TcpClient client1 = await listener.AcceptTcpClientAsync();
                clientList.Add(client1);
                Console.WriteLine("레드 클라이언트 연결됨");

                HandleClient(client1, "Red");

                TcpClient client2 = await listener.AcceptTcpClientAsync();
                clientList.Add(client2);
                Console.WriteLine("블루 클라이언트 연결됨");

                HandleClient(client2, "Blue");
            }

        }
        async static void HandleClient(TcpClient client,string teamColor)
        {
            const int MAX_SIZE = 1024;
            NetworkStream stream = client.GetStream();

            CommandData commandData = new CommandData()
            {
                command = "SetColor",
                color = teamColor
            };
            byte[] messageBytes = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(commandData));
            await stream.WriteAsync(messageBytes,0,messageBytes.Length);

            DefaultMoneyIncrease(stream);

            while (stream.CanRead)
            {
                try
                {
                    byte[] buff = new byte[MAX_SIZE];
                    int nbytes = await stream.ReadAsync(buff, 0, buff.Length);
                    if (nbytes == 0)
                        break;
                    string msg = Encoding.ASCII.GetString(buff, 0, nbytes);
                    Dispatcher.Instance.DispatchMessage(msg);
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("클라이언트 연결 끊김");
                    break;
                }
            }
            clientList.Remove(client);
            stream.Close();
            client.Close();
        }

        public static async Task BroadcastMessage(string message)
        {
            Console.WriteLine($"Broadcast: {message}");
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            foreach (var client in clientList)
            {
                Console.WriteLine("Broadcasting...");
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
            }
        }

        public static async void DefaultMoneyIncrease(NetworkStream stream)
        {
            while (stream.CanWrite)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                CommandData commandData = new CommandData()
                {
                    command = "AddMoney",
                    amount = 1
                };
                byte[] messageBytes = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(commandData));

                try
                {
                    await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("클라이언트 연결 끊김");
                    break;
                }
            }
        }
    }
}