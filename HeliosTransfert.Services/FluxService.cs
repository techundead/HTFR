using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class FluxService
    {

        public static void ajoutFlux(String designation)
        {

            FluxManager.ajoutFlux(designation);
        }

        public static void modifFlux(int cdFlux, String designation)
        {

            FluxManager.modifFlux(cdFlux, designation);
        }

        public static void suppFlux(int cdFlux)
        {

            FluxManager.suppFlux(cdFlux);
        }

        public static int getcdFluxmax()
        {
            return FluxManager.getcdFluxmax();
        }

        public static int getNbreFlux()
        {
            return FluxManager.getNbreFlux();
        }

        //Retourne un flux
        public static Flux getFlux(int cdFlux)
        {
            return FluxManager.getFlux(cdFlux);
        }

        //Retourne tout les flux
        public static IList<Flux> getFluxs()
        {
            return FluxManager.getFluxs();
        }
    }
}
