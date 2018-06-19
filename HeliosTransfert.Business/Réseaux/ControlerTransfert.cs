using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HeliosTransfert.Business;
using HeliosTransfert.Business.Dto;
using System.Windows.Forms;

namespace HeliosTransfert.Services
{
    public class ControlerTransfert
    {
        ClientHeliosTransfert ClientHTRFT;

        private static readonly object _lock = new object();
        private static ControlerTransfert _instance;
        public static ControlerTransfert Instance
        {
            get
            {
                    if (_instance == null)
                    _instance = new ControlerTransfert();

                return _instance;
            }
        }

        private ControlerTransfert()
        {
            ClientHTRFT = new ClientHeliosTransfert();
        }
        public void Demarrer()
        {
            ClientHTRFT.transfert();

        }

        public void Arreter()
        {
            _instance = null;
        }

    }
}
