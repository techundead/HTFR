using System;

namespace Global.Business.Dto
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbAttribute : Attribute
    {
        public String DbName { get; set; }

        public DbAttribute(String dbName)
        {
            DbName = dbName;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TypeParserAttribute : Attribute
    {
        public Type TypeParser { get; set; }

        public TypeParserAttribute(Type typeParser)
        {
            TypeParser = typeParser;
        }
    }
}
