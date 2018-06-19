using Global.Oracle;
using HeliosTransfert.Business.Dto;


namespace HeliosTransfert.Dal
{
    class FTP
    {

        //public static ExtendedReturnedSelect<ClientFTP> AffichageUtilisateur(int cdUtilisateur)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    return o.ExecuterSelect<AffichageBase>(RequeteAffichageUtilisateur(), -1, cdUtilisateur);
        //}


        private static string RequeteParametreFTP()
        {
            string ls_sql;

            ls_sql = "SELECT " +
               " FROM " +
               " WHERE ";

            return ls_sql;
        }
    }
}
