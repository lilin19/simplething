using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Library {
    public class Client {
        private const int port = 11000;
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        private static String response = String.Empty;
        public delegate String Operate(String response);
        public static Operate operate = (String response) => { return response; };
        public static String StartClient(byte[] request) {
            connectDone = new ManualResetEvent(false);
            sendDone = new ManualResetEvent(false);
            receiveDone = new ManualResetEvent(false);
            response = String.Empty;
            try {
                IPAddress ipAddress = IPAddress.Loopback;
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                Send(client, request);
                sendDone.WaitOne();
                Receive(client);
                receiveDone.WaitOne();
                //client.Shutdown(SocketShutdown.Both);
                //client.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return response;
        }
        private static void ConnectCallback(IAsyncResult ar) {
            try {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                connectDone.Set();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        private static void Receive(Socket client) {
            try {
                StateObject state = new StateObject() {
                    workSocket = client
                };
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        private static void ReceiveCallback(IAsyncResult ar) {
            try {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0) {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                } else {
                    if (state.sb.Length > 1) {
                        response = operate(state.sb.ToString());
                    }
                    receiveDone.Set();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        private static void Send(Socket client, byte[] data) {
            client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }
        private static void SendCallback(IAsyncResult ar) {
            try {
                Socket client = (Socket)ar.AsyncState;
                sendDone.Set();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}