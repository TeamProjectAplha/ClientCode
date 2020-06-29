using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace OpenSSL.CLI
{
    public class Frm_client
    {
        private static string username, password;
        
        public Frm_client(string username)
        {
            Frm_client.username = username;
            Thread th = new Thread(startclient);
            th.Start();
            Thread.Sleep(1000);
        }

        public void startclient()
        {
            if (AsynchronousClient.Client == null)
                AsynchronousClient.StartClient();
        }

        public string GetMessages()
        {
            return AsynchronousClient.Get_Messages();
        }
        public string SendMessage(string msg)
        {
            return AsynchronousClient.Send_Messages(msg);
        }
        public string SendMessage2(string msg)
        {
            return AsynchronousClient.Send_Messages2(msg);
        }
        // State object for receiving data from remote device.  
        public class StateObject
        {
            // Client socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 256;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }

        public class AsynchronousClient
        {
            // The port number for the remote device.  
            private const int port = 12000;
            // ManualResetEvent instances signal completion.  
            private static ManualResetEvent connectDone =
                new ManualResetEvent(false);
            private static ManualResetEvent sendDone =
                new ManualResetEvent(false);
            private static ManualResetEvent receiveDone =
                new ManualResetEvent(false);
            private static Socket client;
            public static Socket Client { get { return client; } }
            // The response from the remote device.  
            private static String response = String.Empty;
            private static bool flag = true;
            public static void StartClient()
            {
                // Connect to a remote device.  
                try
                {
                    // Establish the remote endpoint for the socket.  
                    // The name of the
                    // remote device is "host.contoso.com".  
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                    // Create a TCP/IP socket.  
                    client = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.  
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();

                    StateObject state = new StateObject();
                    state.workSocket = client;
                    while (true)
                    {
                        // Set the event to nonsignaled state.  
                        receiveDone.Reset();

                        // Start an asynchronous socket to listen for connections.  
                       
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);

                        // Wait until a connection is made before continuing.  
                        receiveDone.WaitOne();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            public static string Get_Messages()
            {
                try
                {
                    sendDone.Reset(); //receiveDone.Reset();
                    // Send test data to the remote device.  
                    flag = false;
                    Send(client, "username=" + Frm_client.username + "&message=GetAllMessages<EOF>");
                    sendDone.WaitOne();

                    // Receive the response from the remote device.  
                    //Receive(client);
                    receiveDone.WaitOne();

                    // Write the response to the console.  
                    //Console.WriteLine("Response received : {0}", response);
                    return response;
                    //// Release the socket.  
                    //client.Shutdown(SocketShutdown.Both);
                    //client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return "";
                }
                finally
                {
                    //StateObject state = new StateObject();
                    //state.workSocket = client;
                    //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    //    new AsyncCallback(ReceiveCallback), state);
                }
            }
            public static string Send_Messages(string msg)
            {
                try
                {
                    sendDone.Reset(); //receiveDone.Reset();
                    // Send test data to the remote device.  

                    flag = false;
                    Send(client, "username=" + Frm_client.username + "&message="+msg+"<EOF>");
                    sendDone.WaitOne();

                    // Receive the response from the remote device.  
                    //Receive(client);
                    receiveDone.WaitOne();

                    // Write the response to the console.  
                    //Console.WriteLine("Response received : {0}", response);
                    return response;
                    //// Release the socket.  
                    //client.Shutdown(SocketShutdown.Both);
                    //client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return "";
                }
                finally
                {
                    //StateObject state = new StateObject();
                    //state.workSocket = client;
                    //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    //    new AsyncCallback(ReceiveCallback), state);
                }
            }
            public static string Send_Messages2(string msg)
            {
                try
                {
                    sendDone.Reset(); //receiveDone.Reset();
                    // Send test data to the remote device.  

                    flag = false;
                    Send(client, "username=" + Frm_client.username  + "&smessage=" + msg + "<EOF>");
                    sendDone.WaitOne();

                    // Receive the response from the remote device.  
                    //Receive(client);
                    receiveDone.WaitOne();

                    // Write the response to the console.  
                    //Console.WriteLine("Response received : {0}", response);
                    return response;
                    //// Release the socket.  
                    //client.Shutdown(SocketShutdown.Both);
                    //client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return "";
                }
                finally
                {
                    //StateObject state = new StateObject();
                    //state.workSocket = client;
                    //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    //    new AsyncCallback(ReceiveCallback), state);
                }
            }
            private static void ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete the connection.  
                    client.EndConnect(ar);

                    Console.WriteLine("Socket connected to {0}",
                        client.RemoteEndPoint.ToString());

                    // Signal that the connection has been made.  
                    connectDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void Receive(Socket client)
            {
                try
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = client;

                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void ReceiveCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the state object and the client socket
                    // from the asynchronous state object.  
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;

                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        response = state.sb.ToString();
                        if (response.IndexOf("<EOF>") != -1)
                        {
                            state.sb.Clear();
                            response = response.Replace("<EOF>", "");
                            receiveDone.Set();
                            if (flag)
                            {
                                Forum_Client.Instance.Update_Msgbox(response);
                            }
                            flag = true;
                        }
                        else
                        {
                            // Get the rest of the data.  
                            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReceiveCallback), state);
                        }
                    }
                    else
                    {
                        // All the data has arrived; put it in response.  
                        if (state.sb.Length > 1)
                        {
                            response = state.sb.ToString();
                        }
                        // Signal that all bytes have been received.  
                        receiveDone.Set();
                        if (flag)
                            Forum_Client.Instance.Update_Msgbox(response);
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void Send(Socket client, String data)
            {
                try
                {
                    // Convert the string data to byte data using ASCII encoding.  
                    byte[] byteData = Encoding.ASCII.GetBytes(data);

                    // Begin sending the data to the remote device.  
                    client.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), client);
                }
                catch (Exception ex)
                { }
            }

            private static void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);
                    //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                    // Signal that all bytes have been sent.  
                    sendDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
    }
}
