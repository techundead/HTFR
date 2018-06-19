using System;
using System.Data;

namespace Global.Business.Dto
{
    public static class IDataReaderExtensionMethods
    {
        public static int GetPropertyIndex(this IDataReader row, Type type, String propertyName)
        {
            String dbName = type.GetDbNameAttribute(propertyName);
            return row.HasColumn(dbName) ? row.GetOrdinal(dbName) : -1;
        }

        public static bool HasColumn(this IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;

            //return dr.GetSchemaTable().Columns.Contains(columnName);

            //try
            //{
            //    return dr.GetOrdinal(columnName) >= 0;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    return false;
            //}
        }

        public static bool IsReallyNull(this IDataReader dr, string columnName)
        {
            if (!dr.HasColumn(columnName)) return true;
            if (dr[columnName] == null) return true;
            if (dr[columnName] == DBNull.Value) return true;

            return false;
        }

        
        public static Int32 MyGetInt32(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? Convert.ToInt32(row.GetValue(index)) : -1;            
            //if (index <= -1) return -1;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return -1;
            //else if (o is Int16)
            //    return (Int32)(Int16)o;
            //else
            //    return (Int32)o;                        
        }

        public static Int64 MyGetInt64(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? row.GetInt64(index) : -1;
            //if (index <= -1) return -1;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return -1;
            //else
            //    return (Int64)o;
        }

        public static Decimal MyGetDecimal(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? row.GetDecimal(index) : 0;
            //if (index <= -1) return -1;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return -1;
            //else
            //    return (Decimal)o;
        }

        public static Double MyGetDouble(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? row.GetDouble(index) : 0;
            //if (index <= -1) return -1;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return -1;
            //else
            //    return (Decimal)o;
        }


        public static DateTime MyGetDateTime(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? row.GetDateTime(index) : DateTime.MinValue;
            //if (index <= -1) return DateTime.MinValue;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return DateTime.MinValue;
            //else
            //    return (DateTime)o;
        }

        public static String MyGetString(this IDataReader row, int index)
        {
            return index >= 0 && !row.IsDBNull(index) ? row.GetString(index) : String.Empty;
            //if (index <= -1) return String.Empty;

            //object o;
            //o = row.GetValue(index);
            //if (o is DBNull || o == null)
            //    return String.Empty;
            //else
            //    return (String)o;
        }

        

    }


}

