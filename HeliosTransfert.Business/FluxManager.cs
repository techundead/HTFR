using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;

namespace HeliosTransfert.Business
{
   public class FluxManager
    {

        public static void ajoutFlux(String designation)
        {
            FluxDal.InsertFlux(designation);
        }

        public static void modifFlux(int cdFlux, String designation)
        {
            FluxDal.UpdateFlux(cdFlux, designation);
        }

        public static void suppFlux(int cdFlux)
        {
            FluxDal.DeleteFlux(cdFlux);
        }

        public static int getcdFluxmax()
        {
            return FluxDal.getCdFluxmax();
        }

        public static int getNbreFlux()
        {
            return FluxDal.getNbreFlux();
        }


            public static String getDesignation(int cdFlux)
        {
            return FluxDal.getDesignation(cdFlux);
        }
        

        public static Flux getFlux(int cdFlux)
        {
            return FluxDal.getFlux(cdFlux);
        }

        public static IList<Flux> getFluxs()
        {
            return FluxDal.getFluxs();
        }
    }
}
