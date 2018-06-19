using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;

namespace HeliosTransfert.Business
{
    public class TransfertManager
    {

        public static Boolean ajoutTransfert(int cdFlux, int cdClient, String designation, String tailleFichier, String etat, String ipSource, DateTime date)
        {
            return TransfertDal.InsertTransfert(cdFlux, cdClient, designation, tailleFichier, etat, ipSource, date);
        }

        public static void modifTransfert(int cdTransfert, String etat)
        {
            TransfertDal.UpdateTransfertEtat(cdTransfert, etat);
        }

        public static int getcdTransfertmax()
        {
            return TransfertDal.getCdTransfertmax();
        }

        public static int getCdTransfert(int cdFlux, int cdClient, String etat)
        {
            return TransfertDal.getCdTransfert(cdFlux, cdClient, etat);
        }

        public static String getDesignation(int cdTransfert)
        {
            return TransfertDal.getDesignation(cdTransfert);
        }

        public static String getTailleFichier(int cdTransfert)
        {
            return TransfertDal.getTailleFichier(cdTransfert);
        }

        public static String getEtat(int cdTransfert)
        {
            return TransfertDal.getEtat(cdTransfert);
        }

        public static String getIpSource(int cdTransfert)
        {
            return TransfertDal.getIpSource(cdTransfert);
        }

        public static String getDate(int cdTransfert)
        {
            return TransfertDal.getDate(cdTransfert);
        }

        public static Transfert getTransfert(int cdTransfert)
        {
            return TransfertDal.getTransfert(cdTransfert);
        }

        public static IList<Transfert> getTransferts()
        {
            return TransfertDal.getTransferts();
        }

        public static IList<Transfert> getTransfertsEtat(String etat)
        {
            return TransfertDal.getTransfertsEtat(etat);
        }
        
    }
}
