using Global.Business.Dto;
using System;

namespace HeliosTransfert.Business.Dto
{
    public class Client :  IEntityMethodParsing
    {
        public int codeClient { get; set; }
        public String raisonSocial { get; set; }
        public String adressePostale { get; set; }
        public String codePostal { get; set; }
        public String ville { get; set; }
        public String pays { get; set; }

        public void Parse(System.Data.IDataReader odr)
        {
            codeClient =  odr.IsReallyNull("CD_CLIENT") ? -1 : Convert.ToInt32(odr["CD_CLIENT"]);
            raisonSocial = odr.IsReallyNull("RAISON_SOCIAL") ? String.Empty : Convert.ToString(odr["RAISON_SOCIAL"]);
            adressePostale = odr.IsReallyNull("ADRESSE_POSTALE") ? String.Empty : Convert.ToString(odr["ADRESSE_POSTALE"]);
            codePostal = odr.IsReallyNull("CODE_POSTAL") ? String.Empty : Convert.ToString(odr["CODE_POSTAL"]);
            ville = odr.IsReallyNull("VILLE") ? String.Empty : Convert.ToString(odr["VILLE"]);
            pays = odr.IsReallyNull("PAYS") ? String.Empty : Convert.ToString(odr["PAYS"]);

        }

    }
}
