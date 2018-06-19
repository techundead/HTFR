using System.Data;

namespace Global.Business.Dto
{
    public interface IEntity 
    {        
    }

        
    public interface IEntityMethodParsing : IEntity
    {        
        void Parse(IDataReader odr);
    }

}
