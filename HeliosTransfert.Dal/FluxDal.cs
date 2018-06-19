using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeliosTransfert.Dal
{
    public class FluxDal
    {

        public static void InsertFlux(String designation)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                int cd_flux = getCdFluxmax();
                bool res = o.ExecuterUpdate("INSERT INTO trft_flux (CD_FLUX, DESIGNATION) VALUES (:1, :2)", transac, cd_flux, designation).ErrCode == 0;

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

        public static void UpdateFlux(int cdFlux, String designation)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_flux SET DESIGNATION = :2 WHERE CD_FLUX = :1 ", -1, cdFlux, designation).ErrCode == 0;

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

        public static void DeleteFlux(int cd_flux)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("DELETE FROM trft_flux WHERE cd_flux = :1", transac, cd_flux).ErrCode == 0;

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


        public static int getCdFluxmax()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT MAX(cd_flux) FROM trft_flux", -1).Result.ToString();
            int cd_flux;
            if (re == "")
            {
                cd_flux = 1;
            }
            else
            {
                cd_flux = Convert.ToInt32(o.ExecuterSelectScalar("SELECT MAX(cd_flux) FROM trft_flux", -1).Result) + 1;
            }

            return cd_flux;
        }

        public static int getNbreFlux()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT COUNT(cd_flux) FROM trft_flux", -1).Result.ToString();
          
            return Convert.ToInt32(re);
        }
        public static String getDesignation(int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT DESIGNATION FROM trft_flux WHERE cd_flux = :1", -1, cdFlux).Result.ToString();
        }

        public static Flux getFlux(int cdFlux)
        {
            OracleTrans o = OracleTrans.getInstance;
            var data = o.ExecuterSelect<Flux>("SELECT DESIGNATION FROM trft_flux WHERE cd_flux = :1 ", -1, cdFlux).Data;
            return data.FirstOrDefault();
        }

        public static IList<Flux> getFluxs()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Flux>("SELECT CD_FLUX, DESIGNATION FROM trft_flux").Data;
        }

    }
}
