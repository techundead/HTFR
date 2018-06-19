using System;
using System.Data;

namespace Global.Business.Dto
{
    public static class IDataTableExtensionMethod
    {
        public static Boolean IsReallyNull(this DataRow row, String champ)
        {
            if (!row.Table.Columns.Contains(champ)) return true;
            if (row[champ] == null) return true;
            if (row[champ] == DBNull.Value) return true;

            return false;
        }

    }
}
