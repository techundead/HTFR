using Global.Business.Dto;
using System;

namespace HeliosTransfert.Business.Dto
{
    public class Transaction : IEntityMethodParsing
    {
        public int codeTransaction { get; set; }
        public int codeTransfert { get; set; }
        public String detail { get; set; }
        public String codeErreur { get; set; }
        public String etat { get; set; }
        public DateTime dateTransaction { get; set; }

        public void Parse(System.Data.IDataReader odr)
        {
            codeTransaction = odr.IsReallyNull("CD_TRST") ? -1 : Convert.ToInt32(odr["CD_TRST"]);
            codeTransfert = odr.IsReallyNull("CD_TRFT") ? -1 : Convert.ToInt32(odr["CD_TRFT"]);
            detail = odr.IsReallyNull("DETAIL") ? String.Empty : Convert.ToString(odr["DETAIL"]);
            codeErreur = odr.IsReallyNull("CODE_ERREUR") ? String.Empty : Convert.ToString(odr["CODE_ERREUR"]);
            etat = odr.IsReallyNull("ETAT") ? String.Empty : Convert.ToString(odr["ETAT"]);
            dateTransaction = odr.IsReallyNull("DATE_TRANSACTION") ? DateTime.Now : Convert.ToDateTime(odr["DATE_TRANSACTION"]);

        }

    }
}
