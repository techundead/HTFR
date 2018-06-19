using System;
using System.Collections.Generic;

namespace Global.Oracle
{
    public abstract class ExtendedReturn
    {
        public Dictionary<String, Type> Structure = new Dictionary<String, Type>();

        public Boolean HasError { get; set; }
        public int ErrCode { get; set; }
        public String ErrText { get; set; }
        public Exception OracleException { get; set; }

        public String Query { get; set; }
        public object[] Parametres { get; set; }
        
        public int RowMin { get; set; }
        public int RowMax { get; set; }
        
    }
}
