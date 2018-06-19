using Global.Business.Dto;
using System;


namespace HeliosTransfert.Business.Dto
{
    public class Transfert : IEntityMethodParsing
    {
        public int codeTransfert { get; set; }
        public int codeFlux { get; set; }
        public String designation { get; set; }
        public String tailleFichier { get; set; }
        public String ipSource { get; set; }
        public String etat { get; set; }
        public DateTime dateTransfert { get; set; }

        public void Parse(System.Data.IDataReader odr)
        {
            codeTransfert = odr.IsReallyNull("CD_TRFT") ? -1 : Convert.ToInt32(odr["CD_TRFT"]);
            codeFlux = odr.IsReallyNull("CD_FLUX") ? -1 : Convert.ToInt32(odr["CD_FLUX"]);
            designation = odr.IsReallyNull("DESIGNATION") ? String.Empty : Convert.ToString(odr["DESIGNATION"]);
            tailleFichier = odr.IsReallyNull("TAILLE_FICHIER") ? String.Empty : Convert.ToString(odr["TAILLE_FICHIER"]);
            ipSource = odr.IsReallyNull("IP_SOURCE") ? String.Empty : Convert.ToString(odr["IP_SOURCE"]);
            etat = odr.IsReallyNull("ETAT") ? String.Empty : Convert.ToString(odr["ETAT"]);
            dateTransfert = odr.IsReallyNull("DATE_TRANSFERT") ? DateTime.Now : Convert.ToDateTime(odr["DATE_TRANSFERT"]);

        }
    }
}
