using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                TcpClient client = await listener.AcceptTcpClientAsync();
                clientList.Add(client);
                Console.WriteLine("새 클라이언트 연결됨");

                HandleClient(client);
            }
        }
        async static void HandleClient(TcpClient client)
        {
            const int MAX_SIZE = 1024;
            NetworkStream stream = client.GetStream();

            while (true)
            {
                byte[] buff = new byte[MAX_SIZE];
                int nbytes = await stream.ReadAsync(buff, 0, buff.Length);
                if (nbytes == 0)
                    break;
                string msg = Encoding.ASCII.GetString(buff, 0, nbytes);
                Console.WriteLine($"{msg} at {DateTime.Now}");
                Dispatcher.Instance.DispatchMessage(msg);

                // 비동기 송신
                //await stream.WriteAsync(buff, 0, nbytes);
            }

            clientList.Remove(client);
            stream.Close();
            client.Close();
        }

        static async void BroadcastMessage(string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            foreach (var client in clientList)
            {
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
            }
        }
    }
}