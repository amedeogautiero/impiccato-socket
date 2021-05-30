using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpiccatoSocketClient
{
    public delegate void ListeningDelegate(string endpoint);

    public delegate bool ChiediSfidaDelegate(string endpoint);

    public delegate void SfidaOkDelegate(string endpoint);

    public delegate void StartGameDelegate(string endpoint);

    public class SocketHelper
    {
        public event ListeningDelegate ListeningCompleted;
        public event ChiediSfidaDelegate OnChiediSfida;
        public event SfidaOkDelegate OnSfidaOk;
        public event StartGameDelegate OnStartGame;

        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());


            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPAddress ipAddress = ipHostInfo.AddressList.FirstOrDefault(f => f.ToString().StartsWith("192.168.10"));

            if (ipAddress == null)
                return;

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                if (ListeningCompleted != null)
                {
                    ListeningCompleted($"{ipAddress.ToString()}:11000");
                }

                // Start listening for connections.  
                while (true)
                {
                    Socket handler = listener.Accept();

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        string message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        MessageBox.Show(message);
                        elab_message(message, (handler.RemoteEndPoint as IPEndPoint).Address.ToString());
                        break;
                    }

                    byte[] msg = Encoding.ASCII.GetBytes("OK");
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        private void elab_message(string message_receive, string remote)
        {
            if (message_receive == null)
                return;

            string[] parts = message_receive.Split(':');

            if (parts.Length != 2)
            {
                return;
            }

            string tipomesaggio = parts[0];
            string message = parts[1];

            if (tipomesaggio == TipoMessaggio.comando.ToString() && message == "sfida")
            {
                if (OnChiediSfida != null)
                {
                    var ret = OnChiediSfida(remote);

                    if (ret == true)
                    {
                        ClientMessage clientMessage = new ClientMessage()
                        {
                            IPDest = remote,
                            TipoMessaggio = TipoMessaggio.comando,
                            Message = "sfidaok",
                        };
                        this.StartClient(clientMessage);
                    }
                }
            }
            else if (tipomesaggio == TipoMessaggio.comando.ToString() && message == "sfidaok")
            {
                if (OnSfidaOk != null)
                {
                    OnSfidaOk("");
                }
            }
            else if (tipomesaggio == TipoMessaggio.comando.ToString() && message == "startgame")
            {
                if (OnStartGame != null)
                {
                    OnStartGame("");
                }
            }

        }

        public void StartClient(object _message)
        {
            ClientMessage message = _message as ClientMessage;
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];

                string dest = message.IPDest;
                IPAddress ipAddress = null;

                if (message.IPDest.ToLower() == "me")
                {
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    ipAddress = ipHostInfo.AddressList.FirstOrDefault(f => f.ToString().StartsWith("192.168.10"));
                }
                else
                { 
                    ipAddress = IPAddress.Parse(dest);
                }

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  

                    string message_to_send = string.Empty;

                    message_to_send = $"{message.TipoMessaggio.ToString()}:{message.Message}";

                    //if (message.TipoMessaggio == TipoMessaggio.comando)
                    //{
                    //    message_to_send = $"{message.TipoMessaggio.ToString()}:{message.Message}";
                    //}
                    //else if(message.TipoMessaggio == TipoMessaggio.trychar)
                    //{
                    //    message_to_send = $"{message.TipoMessaggio.ToString()}:{message.Message}";
                    //}

                    byte[] msg = Encoding.ASCII.GetBytes(message_to_send);

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class ClientMessage
    {
        public string IPDest { get; set; }

        public string Message { get; set; }

        public TipoMessaggio TipoMessaggio { get; set; }
    }

    public enum TipoMessaggio
    { 
        comando,
        trychar,
    }
}
