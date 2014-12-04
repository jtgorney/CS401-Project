using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingLiveSupportClient
{
    public partial class frmClient : Form
    {
        // The socket connection to send to
        private TcpClient socket = new TcpClient();
        // Implicitly call default constructor
        private NetworkStream ns = default(NetworkStream);
        // Username
        private string username;
        private bool kill = false;
        public frmClient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FormLoad event.
        /// </summary>
        /// <param name="sender">Calling object</param>
        /// <param name="e">Event</param>
        private void frmClient_Load(object sender, EventArgs e)
        {
            // Get the user's name
            username = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name for support.", "Enter Your Name", "User" + 
                (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, -1, -1);
            try
            {
                // Make the initial connection
                socket.Connect(IPAddress.Parse("127.0.0.1"), 8081);
                ns = socket.GetStream();
                // Send the username to the server
                byte[] data = Encoding.ASCII.GetBytes(username + "#");
                ns.Write(data, 0, data.Length);
                ns.Flush();
                // Start a new thread for listeners
                Thread t = new Thread(msg);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Button send message click.
        /// </summary>
        /// <param name="sender">Calling object</param>
        /// <param name="e">Event</param>
        private void cmdSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
                send();
        }

        /// <summary>
        /// Send a message to the server.
        /// </summary>
        private void send()
        {
            // Push the data to the socket
            byte[] outData = Encoding.ASCII.GetBytes(txtMessage.Text.Trim() + "#");
            // Write to stream
            Debug.WriteLine("Sending: " + txtMessage.Text);
            ns.Write(outData, 0, outData.Length);
            ns.Flush();
            // Clean the input field
            txtMessage.Clear();
        }

        /// <summary>
        /// Thread method that sends message on thread.
        /// </summary>
        private void msg()
        {
            // Inf loop
            while (!kill)
            {
                try
                {
                    // Buffer size
                    int buff = 0;
                    ns = socket.GetStream();
                    byte[] input = new byte[100025];
                    buff = socket.ReceiveBufferSize;
                    ns.Read(input, 0, buff);
                    string data = Encoding.ASCII.GetString(input);
                    Invoke(new MethodInvoker(delegate
                    {
                        txtTranscript.Text += Environment.NewLine + data + Environment.NewLine;
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your session has been terminated.", "Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                
            }
        }

        /// <summary>
        /// KeyUp Event
        /// </summary>
        /// <param name="sender">Calling object</param>
        /// <param name="e">Event</param>
        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            // On enter keypress send the message.
            if (e.KeyCode == Keys.Enter && txtMessage.Text != "")
                send();
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to disconnect?", "Disconnect", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMessage.Text = "has disconnected from chat.";
                send();
                kill = true;
                this.Close();
            }
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            kill = true;
            //Environment.Exit(0);
            Application.Exit();
        }
    }
}
