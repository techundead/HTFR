using Global.Business.Dto;
using System;


namespace HeliosTransfert.Business.Dto
{
    public class Flux : IEntityMethodParsing
    {
        public int codeFlux { get; set; }
        public String designation { get; set; }


        public void Parse(System.Data.IDataReader odr)
        {
            codeFlux = odr.IsReallyNull("CD_FLUX") ? -1 : Convert.ToInt32(odr["CD_FLUX"]);
            designation = odr.IsReallyNull("DESIGNATION") ? String.Empty : Convert.ToString(odr["DESIGNATION"]);


        }

    }
}
