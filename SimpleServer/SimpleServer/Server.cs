using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Library;

namespace SimpleServer {
    public class AsynchronousServer {
        private static ManualResetEvent allDone = new ManualResetEvent(false);
        public delegate String Response(String request);
        public static Response response = (String request) => {
            Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", request.Length, request);
            return request;
        };
        public static void StartListening() {
            byte[] bytes = new Byte[1024];
            IPHostEntry ipHostInfo = Dns.GetHostEntry("127.0.0.1");
            IPAddress ipAddress = IPAddress.Loopback;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try {
                listener.Bind(localEndPoint);
                listener.Listen(100);                     
                while (true) {
                    allDone.Reset();
                    Console.WriteLine("waiting for a connection");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
        public static void AcceptCallback(IAsyncResult ar) {
            allDone.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject() {
                workSocket = handler
            };
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public static void ReadCallback(IAsyncResult ar) {
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0) {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                content = state.sb.ToString();
                if (content.Length > 0) {
                    Send(handler, response(content));
                } else {
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }
        private static void Send(Socket handler, String data) {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        private static void SendCallback(IAsyncResult ar) {
            try {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                handler.Shutdown(SocketShutdown.Both);  
                handler.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        public static int Main(String[] args) {
            response = (String request) => {
                return request.Length + " bytes received!";
            };
            StartListening();
            return 0;
        }
    }
}