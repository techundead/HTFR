using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HeliosTransfert.Business;
using HeliosTransfert.Business.Dto;

namespace HeliosTransfert.Services
{
    public class ControlerClientService
    {

        public static void demarrerTransfert()
        {
            ControlerTransfert.Instance.Demarrer();        
        }

        public static void arreterTransfert()
        {
            ControlerTransfert.Instance.Arreter();
        }


    }
}
