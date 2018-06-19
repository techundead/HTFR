using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class ServeurFluxService
    {

        public static void ajoutServeurFlux(int cdFlux, int cdServeur, String cheminLocal, String cheminDistant)
        {
            ServeurFluxManager.ajoutServeurFlux(cdFlux, cdServeur, cheminLocal, cheminDistant);
        }

        public static void modifServeurFlux(int cdFlux, int cdServeur, String cheminLocal, String cheminDistant)
        {
            ServeurFluxManager.modifServeurFlux(cdFlux, cdServeur, cheminLocal, cheminDistant);
        }
        public static void modifCdSRVServeurFlux(int cdFlux, int cdServeurOld, int cdServeurNew, String cheminLocal, String cheminDistant)
        {
            ServeurFluxManager.modifCdSRVServeurFlux(cdFlux, cdServeurOld, cdServeurNew, cheminLocal, cheminDistant);
        }

        public static void suppServeurFlux(int cdServeur, int cdFlux)
        {
            ServeurFluxManager.suppServeurFlux(cdServeur, cdFlux);
        }

        public static String getCheminLocal(int cdSrv, int cdFlux)
        {
            return ServeurFluxManager.getCheminLocal(cdSrv, cdFlux);
        }

        public static String getCheminDistant(int cdSrv, int cdFlux)
        {
            return ServeurFluxManager.getCheminDistant(cdSrv, cdFlux);
        }

        public static ServeurFlux getServeurFlux(int cdSrv, int cdFlux)
        {
            return ServeurFluxManager.getServeurFlux(cdSrv, cdFlux);
        }

        public static IList<ServeurFlux> getServeursFlux()
        {
            return ServeurFluxManager.getServeursFlux();
        }

        public static IList<ServeurFlux> getLstServeursFlux(int cdFlux)
        {
            return ServeurFluxManager.getLstServeursFlux(cdFlux);
        }
    }
}
