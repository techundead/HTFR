using System.Collections.Generic;
using System.Data;
using Global.Business.Dto;

namespace Global.Oracle
{
    /// <summary>
    /// Classe utilisée en retour pour la couche DATA
    /// Contient les données, ainsi que l'erreur rencontrée s'il y a lieu
    /// </summary>
    public class ExtendedReturnedSelect<T> : ExtendedReturn where T : IEntity
    {
        public IList<T> Data { get; set; }
        
        public ExtendedReturnedSelect()
        {
            Data = new List<T>();
        }
    }

    /// <summary>
    /// Classe utilisée en retour pour la couche DATA
    /// Contient les données, ainsi que l'erreur rencontrée s'il y a lieu
    /// </summary>
    public class ExtendedReturnedSelect : ExtendedReturn
    {
        public DataTable Data { get; set; }

        public ExtendedReturnedSelect()
        {
            Data = new DataTable();
        }
    }
}
