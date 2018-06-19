using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;


namespace HeliosTransfert.Business
{
    public class ServeurFluxManager
    {
        public static void ajoutServeurFlux(int cdFlux, int cdServeur, String cheminLocal, String cheminDistant)
        {
            ServeurFluxDal.InsertServeurFlux(cdFlux, cdServeur, cheminLocal, cheminDistant);
        }

        public static void modifServeurFlux(int cdFlux, int cdServeur, String cheminLocal, String cheminDistant)
        {
            ServeurFluxDal.UpdateServeurFlux(cdFlux, cdServeur, cheminLocal, cheminDistant);
        }

        public static void modifCdSRVServeurFlux(int cdFlux, int cdServeurOld, int cdServeurNew, String cheminLocal, String cheminDistant)
        {
            ServeurFluxDal.UpdateCDSRVServeurFlux(cdFlux, cdServeurOld, cdServeurNew, cheminLocal, cheminDistant);
        }

        
        public static void suppServeurFlux(int cdServeur, int cdFlux)
        {
            ServeurFluxDal.DeleteServeurFlux(cdServeur, cdFlux);
        }

        public static String getCheminLocal(int cdSrv, int cdFlux)
        {
            return ServeurFluxDal.getCheminLocal(cdSrv, cdFlux);
        }

        public static String getCheminDistant(int cdSrv, int cdFlux)
        {
            return ServeurFluxDal.getCheminDistant(cdSrv, cdFlux);
        }

        public static ServeurFlux getServeurFlux(int cdSrv, int cdFlux)
        {
            return ServeurFluxDal.getServeurFlux(cdSrv, cdFlux);
        }

        public static IList<ServeurFlux> getServeursFlux()
        {
            return ServeurFluxDal.getServeursFlux();       
        }

        public static IList<ServeurFlux> getLstServeursFlux(int cdFlux)
        {
            return ServeurFluxDal.getLstServeursFlux(cdFlux);
        }

    }
}
