using System;
using System.Net.Sockets;
using System.Net;

using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using Game_Kursak.view_model;
using System.IO;
using System.Linq;

namespace Game_Kursak.model
{
    internal class Client
    {
        static TcpClient client = new TcpClient();
        static NetworkStream stream = null;
        public delegate void ConnectedEventHandler(object sender, string result);
        public event ConnectedEventHandler Connected;
        public string json = null;

        string userName = Environment.UserName;
        string result = "Подключение провалено!";
        const int PORT = 8008;
        const string HOST = "127.0.0.1";

        public void Work(string msg, DataGridView dataGridView)
        {
            try
            {
                client.Connect(HOST, PORT);
                stream = client.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(userName + "\t");
                stream.Write(buffer, 0, buffer.Length);
                SendMsg(msg);

                MessageBox.Show($"Welcome, {userName}, my msg:{msg}");
                json = ReceiveMsg();
                List<Player_statistics_for_client> player_Statistics_From_Servers = new List<Player_statistics_for_client>();
                player_Statistics_From_Servers = JsonConvert.DeserializeObject<List<Player_statistics_for_client>>(json);
                //dataGridView.DataSource = player_Statistics_From_Servers;
                SaveToTxt(player_Statistics_From_Servers);
                MessageBox.Show(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Disconnect();
                if (Connected != null)
                    Connected.BeginInvoke(this, result, null, null);
            }
        }
        static void Disconnect()
        {
            if (client != null && client.Connected == true)
            {
                client.Dispose();
                stream.Dispose();
            }
            
        }
        public string ReceiveMsg()
        {
            byte[] buff = new byte[256];
            StringBuilder builder = new StringBuilder();
            do
            {
                int bytes = stream.Read(buff, 0, buff.Length);
                builder.Append(Encoding.UTF8.GetString(buff, 0, bytes));
            } while (stream.DataAvailable);

            return builder.ToString(); 
        }
        private static void SendMsg(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
        public void SaveToTxt(List<Player_statistics_for_client> results)
        {
            string path = $@"C:\Users\Alex\source\repos\Omlet144\Game_Kursak\bin\Debug\MyResults2.json";
            string json = null;

            try
            {
                json = JsonConvert.SerializeObject(results, Formatting.Indented);
          

                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(json);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
