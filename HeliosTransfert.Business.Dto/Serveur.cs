using Global.Business.Dto;
using System;

namespace HeliosTransfert.Business.Dto
{
    public class Serveur : IEntityMethodParsing
    {
        public int codeServeur { get; set; }
        public String adresseIp { get; set; }
        public String ftpIdtf { get; set; }
        public String ftpMdp { get; set; }
        public int ftpPort { get; set; }
        public int trftPort { get; set; }
        public int code_client_srv { get; set; }

        public void Parse(System.Data.IDataReader odr)
        {
            codeServeur = odr.IsReallyNull("CD_SRV") ? -1 : Convert.ToInt32(odr["CD_SRV"]);
            adresseIp = odr.IsReallyNull("ADRESSE_IP") ? String.Empty : Convert.ToString(odr["ADRESSE_IP"]);
            ftpIdtf = odr.IsReallyNull("FTP_IDENTIFIANT") ? String.Empty : Convert.ToString(odr["FTP_IDENTIFIANT"]);
            ftpMdp = odr.IsReallyNull("FTP_MDP") ? String.Empty : Convert.ToString(odr["FTP_MDP"]);
            ftpPort = odr.IsReallyNull("FTP_PORT") ? -1 : Convert.ToInt32(odr["FTP_PORT"]);
            trftPort = odr.IsReallyNull("TRFT_PORT") ? -1 : Convert.ToInt32(odr["TRFT_PORT"]);
            code_client_srv = odr.IsReallyNull("CD_CLIENT_SRV") ? -1 : Convert.ToInt32(odr["CD_CLIENT_SRV"]);

        }

    }
}
