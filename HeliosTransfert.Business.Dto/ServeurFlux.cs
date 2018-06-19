using Global.Business.Dto;
using System;

namespace HeliosTransfert.Business.Dto
{
    public class ServeurFlux : IEntityMethodParsing
    {
        public int codeServeur { get; set; }
        public int codeFlux { get; set; }
        public String cheminLocal { get; set; }
        public String cheminDistant { get; set; }
        public String adresseIP { get; set; }
        public String designation { get; set; }



        public void Parse(System.Data.IDataReader odr)
        {
            codeServeur = odr.IsReallyNull("CD_SRV") ? -1 : Convert.ToInt32(odr["CD_SRV"]);
            codeFlux = odr.IsReallyNull("CD_FLUX") ? -1 : Convert.ToInt32(odr["CD_FLUX"]);
            cheminLocal = odr.IsReallyNull("CHEMIN_LOCAL") ? String.Empty : Convert.ToString(odr["CHEMIN_LOCAL"]);
            cheminDistant = odr.IsReallyNull("CHEMIN_DISTANT") ? String.Empty : Convert.ToString(odr["CHEMIN_DISTANT"]);
            adresseIP = odr.IsReallyNull("ADRESSE_IP") ? String.Empty : Convert.ToString(odr["ADRESSE_IP"]);
            designation = odr.IsReallyNull("DESIGNATION") ? String.Empty : Convert.ToString(odr["DESIGNATION"]);


        }

    }
}