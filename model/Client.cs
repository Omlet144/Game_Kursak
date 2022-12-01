using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Game_Kursak.model
{
    internal class Client
    {
        static TcpClient client = new TcpClient();
        static NetworkStream stream = null;


        string userName = Environment.UserName;
        

        const int PORT = 8008;
        const string HOST = "127.0.0.1";

        public void Work(string msg)
        {

            try
            {
                client.Connect(HOST, PORT);
                stream = client.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(userName+"\t");
                stream.Write(buffer, 0, buffer.Length);

                Thread receiveMsgThread = new Thread(ReceiveMsg);
                receiveMsgThread.Start();
                SendMsg(msg);
                MessageBox.Show($"Welcome, {userName}, my msg:{msg}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Disconnect();
            }
        }
        static void Disconnect()
        {
            client.Close();
            stream.Close();
        }
        static void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int byteCount = 0;
                    do
                    {
                        byteCount = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, byteCount));
                    } while (stream.DataAvailable);

                    MessageBox.Show(builder.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Disconnect();
                    Environment.Exit(0);
                }
            }
        }
        private static void SendMsg(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
    }
}
