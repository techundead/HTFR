namespace Global.Oracle
{
    /// <summary>
    /// Classe utilisée en retour pour la couche DATA
    /// Contient les données, ainsi que l'erreur rencontrée s'il y a lieu
    /// </summary>
    public class ExtendedReturnedUpdate : ExtendedReturn
    {
        public int AffectedRows { get; set; }
    }
}
