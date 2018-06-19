using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using HeliosTransfert.Business;


namespace HeliosTransfert.Business.Dto
{
    public class ServeurTCP
    {


        public static TcpListener DemarrageServeur(String AddressIp, int port)
        {

            TcpListener listener = new TcpListener(IPAddress.Any, port);

            listener.Start();

            return listener;
        }
    }
}
