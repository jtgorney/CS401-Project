using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankingLiveSupportServer
{
    class Program
    {
        private static Hashtable clients = new Hashtable();
        static void Main(string[] args)
        {
            int numAttempts = 0;
            //If the server connection throws an exception, it will reach the top of this loop again
            //and attempt to start the server again without user action
            //After 5 attempts the server gives up and displays a message
            while (numAttempts < 5)
            {
            bool running = true;
            // Create the socket connections
            int count = 0;
            TcpListener serverSock = new TcpListener(IPAddress.Parse("127.0.0.1"), 8081);
            TcpClient clientSock;

            // Begin server communications
            serverSock.Start();
            // Write a message to the CMD line
            Console.WriteLine("Banking chat successfully started on port 8081!" + Environment.NewLine);
            
            // The main chat loop
            
                while (running)
                {
                    try
                    {
                        // Increment count
                        count++;
                        // Accept the next connection
                        clientSock = serverSock.AcceptTcpClient();
                        // Byte handler
                        byte[] dataFrom = new byte[100025];
                        string dataClient = null;
                        // Get the data from stream
                        NetworkStream stream = clientSock.GetStream();
                        // Read the data to buffer and get the ASCII representation of the bytes in buffer
                        stream.Read(dataFrom, 0, clientSock.ReceiveBufferSize);
                        dataClient = Encoding.ASCII.GetString(dataFrom);
                        // Parse out the username
                        dataClient = dataClient.Substring(0, dataClient.IndexOf("#"));
                        // Add user to client listing
                        clients.Add(dataClient, clientSock);
                        // Send an updated message to everyone
                        message(Environment.NewLine + "User " + dataClient + " has joined support chat!" + Environment.NewLine, dataClient, false);
                        // Server spawn
                        ClientHandler h = new ClientHandler();
                        // Finally, spawn the server.
                        h.start(clientSock, dataClient, clients);
                        //This next line is for testing purposes only. Should not be uncommented on production systems.
                        //throw new Exception();
                    }
                    catch
                    {
                        //If an exception happens, set running to false
                        //so you drop out of the loop and attempt to save the server
                        try
                        {
                            serverSock.Server.Close();
                        }
                        catch
                        {
                        }
                        numAttempts++;
                        Console.WriteLine("Server failed " + numAttempts + " times. Attempting to restart..." + Environment.NewLine);
                        running = false;
                    }
                }
            }
            Console.WriteLine("Server failed to start 5 times. The server will not attempt again until you restart the program." + Environment.NewLine);
        }

        /// <summary>
        /// Send a message to all clients.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="username">Username of sending user</param>
        /// <param name="userSender">System or user message</param>
        public static void message(string message, string username, bool userSender)
        {
            foreach (DictionaryEntry entry in clients)
            {
                // Build the output stream
                TcpClient sendSocket = (TcpClient)entry.Value;
                if (sendSocket.Connected)
                {
                    NetworkStream ns = sendSocket.GetStream();
                    byte[] sendBytes = null;

                    // Determine whether this is system or user sending message
                    if (userSender)
                    {
                        sendBytes = Encoding.ASCII.GetBytes(username + ": " + message);
                        Console.WriteLine(username + ": " + message);
                    }
                    else
                    {
                        sendBytes = Encoding.ASCII.GetBytes(message);
                        Console.WriteLine(message);
                    }
                    // Output and flush!
                    ns.Write(sendBytes, 0, sendBytes.Length);
                    ns.Flush();
                }
            }
        }

        private class ClientHandler
        {
            private TcpClient clientSock;
            private string clientNumber;
            private Hashtable clients;

            /// <summary>
            /// Start the client handler object listener.
            /// </summary>
            /// <param name="clSock">Client socket connection</param>
            /// <param name="cNum">Client number from socket</param>
            /// <param name="cList">List of current clients</param>
            public void start(TcpClient clSock, string cNum, Hashtable cList)
            {
                // Set data for the handler
                clientSock = clSock;
                clientNumber = cNum;
                clients = cList;
                // Spawn a new thread
                Thread t = new Thread(chat);
                t.Start();
            }

            /// <summary>
            /// Send chat to clients.
            /// </summary>
            private void chat()
            {
                // Number of requests
                int req = 0;
                byte[] dataFrom = new byte[100025];
                string dataClient = null;
                string rCount = null;

                while (true)
                {
                    try
                    {
                        if (clientSock.Connected)
                        {
                            // Inc requests
                            req++;
                            // Get the input stream, like we did before but in our own handler
                            NetworkStream ns = clientSock.GetStream();
                            ns.Read(dataFrom, 0, clientSock.ReceiveBufferSize);
                            // Get the data as string
                            dataClient = Encoding.ASCII.GetString(dataFrom);
                            dataClient = dataClient.Substring(0, dataClient.IndexOf("#"));
                            // Get requests as string
                            rCount = req.ToString();
                            // Send the message
                            message(dataClient, clientNumber, true);
                        }
                    }
                    catch (Exception exc) { }
                }
            }
        }
    }
}
