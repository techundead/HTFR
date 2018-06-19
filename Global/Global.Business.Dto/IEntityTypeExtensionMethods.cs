using System;
using System.Linq;

namespace Global.Business.Dto
{
    public static class IEntityTypeExtensionMethods
    {
        
        public static String GetDbNameAttribute(this Type typeEntity, String propertyName)
        {
            return (typeEntity.GetProperty(propertyName).GetCustomAttributes(typeof(DbAttribute), true)[0] as DbAttribute).DbName;
        }

        public static Type GetTypeParserAttribute(this Type typeEntity)
        {
            if (typeEntity.GetCustomAttributes(typeof(TypeParserAttribute), true).Count() > 0)
            {
                object typeParserAttribute = typeEntity.GetCustomAttributes(typeof(TypeParserAttribute), true).First();
                return (typeParserAttribute as TypeParserAttribute).TypeParser;
            }
            else
                return null;
        }
        
    }


}

