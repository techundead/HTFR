using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HeliosTransfert.Dal
{
    public class ServeurFluxDal
    {

        //Ajoute un flux au serveur
        public static void InsertServeurFlux(int cdFlux,int cdServeur,String cheminLocal, String cheminDistant)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {

                bool res = o.ExecuterUpdate("INSERT INTO trft_serveur_flux (CD_FLUX, CD_SRV, CHEMIN_LOCAL, CHEMIN_DISTANT) VALUES (:1, :2, :3, :4)", transac, cdFlux, cdServeur, cheminLocal, cheminDistant).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }


        }

        public static void UpdateServeurFlux(int cdFlux, int cdServeur, String cheminLocal, String cheminDistant)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_serveur_flux SET CHEMIN_LOCAL = :2, CHEMIN_DISTANT = :3 WHERE CD_SRV = :1 AND CD_FLUX = :4 ", -1, cdServeur, cheminLocal, cheminDistant, cdFlux).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }

        }


        public static void UpdateCDSRVServeurFlux(int cdFlux, int cdServeurOld, int cdServeurNew,String cheminLocal, String cheminDistant)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_serveur_flux SET CHEMIN_LOCAL = :2, CHEMIN_DISTANT = :3, CD_SRV = :5 WHERE CD_SRV = :1 AND CD_FLUX = :4 ", -1, cdServeurOld, cheminLocal, cheminDistant, cdFlux, cdServeurNew).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }

        }


        public static void DeleteServeurFlux(int cdServeur, int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("DELETE FROM trft_serveur_flux WHERE cd_srv = :1 AND cd_flux = :2", transac, cdServeur, cdFlux).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }


        }


        public static String getCheminLocal(int cdSrv, int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CHEMIN_LOCAL FROM trft_serveur_flux WHERE cd_srv = :1 AND cd_flux = :2", -1, cdSrv, cdFlux).Result.ToString();
        }

        public static String getCheminDistant(int cdSrv, int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CHEMIN_DISTANT FROM trft_serveur_flux WHERE cd_srv = :1 AND cd_flux = :2", -1, cdSrv, cdFlux).Result.ToString();
        }

        public static ServeurFlux getServeurFlux(int cdSrv, int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            var data = o.ExecuterSelect<ServeurFlux>("SELECT CD_SERVEUR, CD_FLUX, CHEMIN_LOCAL, CHEMIN_DISTANT FROM trft_serveur_flux WHERE cd_srv = :1 AND cd_flux = :2", -1, cdSrv, cdFlux).Data;
            return data.FirstOrDefault();
        }

        public static IList<ServeurFlux> getServeursFlux()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<ServeurFlux>("SELECT TRFT_FLUX.CD_FLUX, TRFT_SERVEUR_FLUX.CD_SRV, TRFT_SERVEURS.ADRESSE_IP, TRFT_FLUX.DESIGNATION, TRFT_SERVEUR_FLUX.CHEMIN_LOCAL FROM TRFT_SERVEUR_FLUX, TRFT_SERVEURS, TRFT_FLUX WHERE TRFT_SERVEUR_FLUX.CD_SRV = TRFT_SERVEURS.CD_SRV AND TRFT_SERVEUR_FLUX.CD_FLUX = TRFT_FLUX.CD_FLUX").Data;
        }

        public static IList<ServeurFlux> getLstServeursFlux(int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<ServeurFlux>("SELECT TRFT_FLUX.CD_FLUX, TRFT_SERVEUR_FLUX.CD_SRV, TRFT_SERVEURS.ADRESSE_IP, TRFT_FLUX.DESIGNATION, TRFT_SERVEUR_FLUX.CHEMIN_LOCAL FROM TRFT_SERVEUR_FLUX, TRFT_SERVEURS, TRFT_FLUX WHERE TRFT_SERVEUR_FLUX.CD_SRV = TRFT_SERVEURS.CD_SRV AND TRFT_SERVEUR_FLUX.CD_FLUX = TRFT_FLUX.CD_FLUX AND TRFT_FLUX.CD_FLUX = :1", -1, cdFlux).Data;
        }

    }
}
