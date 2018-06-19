using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data.Common;
using Global.Business.Dto;
using System.Collections;


namespace Global.Oracle
{
    public class OracleTrans //: IDisposable
    {
        #region Attributs de classe
        
        /// Attributs pour singleton
        private static OracleTrans _instance = null;
        private static readonly object lockConnection = new object();

        private static readonly object lockTransaction = new object();

        String _connectionString = "";

        /// Connection à la base pour SELECT(liée par singleton)
        //private OracleConnection _oracleCon;
        //private OracleConnection OracleCon
        //{
        //    get
        //    {
        //        if (_oracleCon == null) _oracleCon = new OracleConnection(_connectionString);
        //        Open(_oracleCon);
        //        return _oracleCon;
        //    }
        //}

        // Connection dédiée aux requêtes non-transactionnelles
        //private OracleConnection _oracleConnection;

        /// Liste de connections dédiée aux transactions
        //private List<OracleConnection> _oracleConnections = new List<OracleConnection>();
                
        /// Liste de transactions liées aux connexions transactionnelles
        private List<OracleTransaction> _oracleTransacs = new List<OracleTransaction>();
        
        
        #endregion        

        ///////////////////////////////////////////////////////////////////
        #region Propriétés

        /// <summary>
        /// Code d'erreur ORACLE
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// Message d'erreur ORACLE
        /// </summary>
        public string ErrText { get; set; }

        /// <summary>
        /// Propriété d'accès à la connexion. Design Pattern Singleton, ne retournera 
        /// qu'une instance de la connexion
        /// </summary>
        public static OracleTrans getInstance
        {
            get
            {
                lock ((lockConnection))
                {
                    if (_instance == null)
                    {
                        try
                        {
                            _instance = new OracleTrans();
                        }
                        catch (Exception ex) 
                        {
                            
                        }
                    }
                    return _instance;                    
                }
            }
        }

        public DateTime HeureServeur
        {
            get
            {
                return (DateTime)this.ExecuterSelectScalar("SELECT SYSDATE FROM DUAL").Result;
            }
        }


        #endregion
        
        //////////////////////////////////// 
        #region Construction, destruction

        /// <summary>
        /// Constructeur de la connexion
        /// </summary>
        private OracleTrans()
        {
            //string ls_base, ls_user, ls_pwd, ls_chaine;
            //ls_base = ConfigurationSettings.AppSettings["base"];
            //ls_user = ConfigurationSettings.AppSettings["user"];
            //ls_pwd = ConfigurationSettings.AppSettings["pass"];
            //ls_chaine = ;
            try
            {
                
                _connectionString = 
                        (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("host")
                        && System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("service")
                        ? "Data Source= " +
                        "   (DESCRIPTION= " +
                        "       (ADDRESS_LIST= " +
                        "           (ADDRESS= " +
                        "               (PROTOCOL=TCP) " +
                        "               (HOST=" + System.Configuration.ConfigurationManager.AppSettings["host"] + ") " +
                        "               (PORT=1521) " +
                        "           ) " +
                        "       ) " +
                        "       (CONNECT_DATA= " +
                        //"           (SERVER=DEDICATED) " +
                        "           (SERVICE_NAME=" + System.Configuration.ConfigurationManager.AppSettings["service"] + ") " +
                        "       ) " +
                        "   )"
                        : "Data Source=" + System.Configuration.ConfigurationManager.AppSettings["base"] ) + ";" +
                        "Persist Security Info=True;" +
                        "User ID=" + System.Configuration.ConfigurationManager.AppSettings["user"] + ";" +
                        "Password=" + System.Configuration.ConfigurationManager.AppSettings["pass"] + ";" +
                        "pooling=true;"
                        ;

                //(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(Host=database_host_name)(Port=1521))(CONNECT_DATA=(SERVICE_NAME=database_service_name)))
                
                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
        }

        //~OracleTrans()
        //{   
        //    Dispose(false);            
        //    /// Ici le destructeur va être appelée par le runtime via la finalisation.
        //    /// ATTENTION !
        //    /// Toutes les ressources managées ne doivent pas être disposées (car elles l'ont
        //    /// peut être déjà été...). Seules les ressources non-managées doivent être 
        //    /// détruites (pointeurs de fichiers par exemple).
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    /// On fait appel "manuellement" à la destruction de l'objet.
        //    /// L'objet doit être retiré de la liste du thread de finalisation.
        //    GC.SuppressFinalize(this);
        //}

        //public void Dispose(bool disposing)
        //{
        //    System.Windows.Forms.MessageBox.Show("Dispose");
        //    if (!disposed)
        //    {
        //        if (disposing) // i.e. Si on fait "manuellement" appel à la méthode dispose
        //        {
        //            /// On fait un dispose de toutes les ressources externe de la classe.
        //            /// On ne le fait que si l'appel à la méthode est manuel,
        //            /// car s'il ne l'est pas (thread de finalisation), on ne peut pas savoir
        //            /// si la ressource externe de la classe (comme une connexion à une BdD par exemple) 
        //            /// a déjà été finalisée ou non (l'ordre de finalisation dans le 
        //            /// thread de finalisation n'est pas assuré).                
        //            _oracleCon.Dispose();
        //            foreach (OracleConnection o in _oracleConnections)
        //            {
        //                o.Dispose();
        //            }
        //        }
        //        /// On détruit ici les ressources non-managées                
        //        disposed = true;
        //    }
        //}
        
        #endregion

        ////////////////////////////////////////////////////////////////////
        #region Ouverture, fermeture de connexion

        /// <summary>
        /// Ouverture de connexion
        /// <param name="oracleCon">La connexion à ouvrir</param>
        /// </summary>
        private void Open(OracleConnection oracleCon)
        {
            try
            {
                if (oracleCon == null)
                    oracleCon = new OracleConnection(_connectionString);

                if (oracleCon != null && oracleCon.State == ConnectionState.Closed)
                {
                    oracleCon.ConnectionString = _connectionString;
                    oracleCon.Open();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Fermeture de connexion
        /// <param name="oracleCon">La connexion à fermer</param>
        /// </summary>
        private void Close(OracleConnection oracleCon)
        {
            try
            {
                if (oracleCon != null && oracleCon.State != ConnectionState.Closed) 
                {
                    oracleCon.Close();
                    oracleCon.Dispose();
                }
            }
            catch (Exception)
            { }
        }

        public Boolean TestConnection(String alias, String host, String service, String user, String pass)
        {
            String connectionString =
                        host != "" && service != ""
                        ? "Data Source= " +
                        "   (DESCRIPTION= " +
                        "       (ADDRESS_LIST= " +
                        "           (ADDRESS= " +
                        "               (PROTOCOL=TCP) " +
                        "               (HOST=" + host + ") " +
                        "               (PORT=1521) " +
                        "           ) " +
                        "       ) " +
                        "       (CONNECT_DATA= (SERVICE_NAME=" + service + ") " +
                        "       ) " +
                        "   )"
                        : "Data Source=" + alias + ";" +
                        "Persist Security Info=True;" +
                        "User ID=" + user + ";" +
                        "Password=" + pass + ";" +
                        "pooling=false;"
                        ;

            OracleConnection oracleCon = new OracleConnection(connectionString);
            Boolean res = false;

            try
            {
                oracleCon.Open();

                if (oracleCon.State == ConnectionState.Open)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            finally
            {
                oracleCon.Close();
                oracleCon.Dispose();
            }

            return res;

        }

        #endregion

        ////////////////////////////////////////////////////////////////////
        #region Gestion de la transaction

        /// <summary>
        /// Débute une transaction (créé une nouvelle connexion dédiée à celle ci) et retourne 
        /// un identifiant de transaction
        /// </summary>
        public int DebutTransaction()
        {
            
            // On créé une connection spécifique pour la transaction et on l'ouvre
            OracleConnection oracleConT = new OracleConnection(_connectionString);
            Open(oracleConT);
            //// On ajoute la connexion à la liste des connexions transactionnelles courante
            ////_oracleConnections.Add(_oracleCon);
            //int i = 0;
            //Boolean ok = false;
            //foreach (OracleConnection c in _oracleConnections)
            //{
            //    if (c == null)
            //    {
            //        _oracleConnections[i] = oracleConT;
            //        ok = true;
            //        break;
            //    }
            //    i++;
            //}
            //if (!ok) _oracleConnections.Add(oracleConT);

            // Création de la transaction
            OracleTransaction transac = oracleConT.BeginTransaction();
             
            lock (lockTransaction)
            {            
                // Ajout de la transaction dans la liste (à la première case vide)
                int i = 0;
                Boolean ok = false;
                foreach (OracleTransaction c in _oracleTransacs)
                {
                    if (c == null)
                    {
                        _oracleTransacs[i] = transac;
                        ok = true;
                        break;
                    }
                    i++;
                }
                if (!ok) _oracleTransacs.Add(transac);

                // On récupère l'index de la connexion (ou transaction) ajoutée
                int ind = _oracleTransacs.IndexOf(transac);
                  
                return ind;
            }
        }
        
        /// <summary>
        /// Valide et termine la transaction
        /// <param name="idTransaction">Identifiant de la transaction à valider</param>
        /// </summary>
        public void Commit(int idTransaction)
        {
            lock (lockTransaction)
            {
                // On récupère la connexion & la transaction liée à l'identifiant
                //OracleConnection oracleConT = _oracleConnections[idTransaction];
                OracleTransaction oracleTransac = _oracleTransacs[idTransaction];
                if (oracleTransac != null)
                {
                    OracleConnection oracleConT = oracleTransac.Connection;

                    // On valide
                    oracleTransac.Commit();
                    // On ferme la connexion
                    Close(oracleConT);
                    // On libère la transaction dans la liste      
                    _oracleTransacs[idTransaction].Dispose();
                    _oracleTransacs[idTransaction] = null;
                }
            }
        }

        /// <summary>
        /// Rejette et termine la transaction
        /// <param name="idTransaction">Identifiant de la transaction à rejetter</param>
        /// </summary>
        public void RollBack(int idTransaction)
        {
            lock (lockTransaction)
            {
                // On récupère la connexion & la transaction liée à l'identifiant
                //OracleConnection oracleConT = _oracleConnections[idTransaction];
                OracleTransaction oracleTransac = _oracleTransacs[idTransaction];
                if (oracleTransac != null)
                {
                    OracleConnection oracleConT = oracleTransac.Connection;

                    // On rejette
                    oracleTransac.Rollback();
                    // On ferme la connexion
                    Close(oracleConT);
                    // On libère la transaction dans la liste           
                    _oracleTransacs[idTransaction].Dispose();
                    _oracleTransacs[idTransaction] = null;
                }
            }
        }

        private void PurgeStatementCache(int idTransaction)
        {
            lock (lockTransaction)
            {
                // On récupère la connexion & la transaction liée à l'identifiant
                //OracleConnection oracleConT = _oracleConnections[idTransaction];
                OracleTransaction oracleTransac = _oracleTransacs[idTransaction];
                if (oracleTransac != null)
                {
                    OracleConnection oracleConT = oracleTransac.Connection;
                    oracleConT.PurgeStatementCache();
                }
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////
        #region Méthodes privée de manipulation de commande OracleTrans

        /// <summary>
        /// Créé une commande OracleTrans (de sélection ou de mise à jour) NON TRANSACTIONNELLE.
        /// La connexion à la base est ouverte.
        /// </summary>
        /// <param name="as_sql">Requête à éxécuter</param>
        private OracleCommand CreerCommande(String as_sql)
        {
            /// Ici, on récupère la connexion Oracle et on l'ouvre
            /// La méthode "plebiscitée" est de créer une nouvelle connexion à chaque nouvelle commande Oracle, puis la clore après la commande.
            /// En utilisant le "Connection Pooling", un certain nombre de connections restent ouverte un certain temps sur le serveur. Oracle les utilise alors pour les nouvelles commandes
            /// et les ferment lorsque il y a moins d'activité.
            
            //if (_oracleConnection == null) _oracleConnection = new OracleConnection(_connectionString);
            OracleConnection oracleCon = new OracleConnection(_connectionString);
            Open(oracleCon);

            OracleCommand c = oracleCon.CreateCommand();
            c.CommandText = as_sql;
            c.BindByName = true;

            return c;           
            
        }

        /// <summary>
        /// Créé une commande OracleTrans (de sélection ou de mise à jour) TRANSACTIONNELLE.
        /// Pas d'ouverture de connexion, elle doit se faire au début de la transaction
        /// </summary>
        /// <param name="as_sql">Requête à éxécuter</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        private OracleCommand CreerCommande(String as_sql, int idTransaction)
        {
            // On récupère la connexion & la transaction déjà ouverte liée à l'identifiant
            OracleTransaction oracleTransac = _oracleTransacs[idTransaction];
            OracleConnection oracleConT = oracleTransac.Connection;

            Open(oracleConT);

            OracleCommand c = oracleConT.CreateCommand(); 
            c.CommandText = as_sql;
            c.BindByName = true;
            
            return c;            
        }
               
        /// <summary>
        /// Créé une commande OracleTrans (de sélection ou de mise à jour) TRANSACTIONNELLE ou NON paramétrée.
        /// Si Transactionnelle : ouverture de connexion
        /// Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction
        /// </summary>
        /// <param name="as_sql">Requête à éxécuter</param>
        /// <param name="idTransaction">Identifiant de la transaction (-1 si non transactionnelle, >=0 si transactionnelle)</param>
        /// <param name="parametres">liste de paramètres (params)</param>
        private OracleCommand CreerCommande(string as_sql, int idTransaction, params object[] parametres)
        {
            OracleCommand c;
            if (idTransaction == -1)
            {
                /// On créé une commande "classique"
                c = CreerCommande(as_sql);
            }
            else
            {
                /// On créé une commande "classique" transactionnelle
                c = CreerCommande(as_sql, idTransaction);
            }
            /// On lui ajoute les paramètres
            AjoutParametres(c, parametres);
            return c;
        }

        /// <summary>
        /// Méthode d'ajout de paramètres à une commande OracleTrans
        /// Liste de paramètres à ajouter sous forme de:
        /// <para>Valeur :
        ///     <para><example>- SELECT ... WHERE xxx = :1 AND xxx = :2</example></para>
        ///     <para><example>- AjoutParametre(c, -1, 10, DateTime.Now)</example></para>
        /// </para>
        /// <para>OracleParameter :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- AjoutParametre(c, -1, new OracleParameter(...), new OracleParameter(...))</example></para>
        /// </para>
        /// <para>OracleParameter[] :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- oraclePArray[0] = new OracleParameter() ...</example></para>
        ///     <para><example>- AjoutParametre(c, -1, oraclePArray)</example></para>
        /// </para>
        /// </summary>
        /// <param name="c">Commande OracleTrans contenant les paramètres</param>
        /// <param name="parametres">Paramètres à ajouter, sous forme de valeur ou tableau de valeurs (on peut utiliser valeur = OracleParameter)</param>
        private void AjoutParametres(OracleCommand c, params object[] parametres)
        {
            //DbParameter opTest = new OracleParameter(); /// Pour comparaison de type   
            OracleParameter oracleParameter;                /// Pour ajout dans la collection de paramètres de la commande
            int i = 1;
            if (parametres != null && parametres.Length > 0)
            {
                foreach (object p in parametres)
                {
                    /// Si le tableau de paramètre passé contient des éléments null
                    if (p != null)
                    {
                        /// On teste si le paramètre est un OracleParameter ou une simple valeur
                        if (p is DbParameter)
                        {
                            /// On copie les infos de l'objet OracleParameter en parametre
                            /// (on ne peut ajouter l'objet directement dans la collection car il 
                            /// est déjà dans une collection... "parametres" est une collection )
                                                        
                            //oracleParameter = Convert.ChangeType(p, typeof(OracleParameter)) as OracleParameter;
                            if (p is OracleParameter)
                                oracleParameter = (OracleParameter)p;
                            else
                            {
                                // Paramètre est de type DbParameter mais non OracleParameter
                                oracleParameter = new OracleParameter();
                                oracleParameter.ParameterName = ((DbParameter)p).ParameterName;
                                oracleParameter.Value = ((DbParameter)p).Value;
                                oracleParameter.DbType = ((DbParameter)p).DbType;
                                oracleParameter.Size = ((DbParameter)p).Size;
                            }   
                        }
                        else if (p is byte[])
                        {
                            oracleParameter = new OracleParameter();
                            oracleParameter.ParameterName = i.ToString();
                            oracleParameter.Value = p;
                            oracleParameter.OracleDbType = OracleDbType.Blob;
                            oracleParameter.Size = (p as byte[]).Length;
                        }
                        else if (p.GetType().IsArray)
                        {
                            c.ArrayBindCount = (p as ICollection).Count;

                            // type des objets de la collection
                            Type t = p.GetType().GetElementType();
                            // conversion en oracle db type
                            OracleDbType dbType = OracleDbType.Varchar2;
                            switch (Type.GetTypeCode(t))
	                        {
		                        case TypeCode.Boolean:                                    
                                case TypeCode.Byte:
                                case TypeCode.DBNull: 
                                case TypeCode.Empty:
                                case TypeCode.Object:
                                case TypeCode.SByte:
                                case TypeCode.Single:
                                case TypeCode.UInt16:
                                case TypeCode.UInt32:
                                case TypeCode.UInt64:
                                    break;
                                case TypeCode.Char:
                                    dbType = OracleDbType.Char; break;
                                case TypeCode.DateTime: 
                                    dbType = OracleDbType.Date; break;
                                case TypeCode.Decimal:
                                    dbType = OracleDbType.Decimal; break;
                                case TypeCode.Double:
                                    dbType = OracleDbType.Double; break;                                                                 
                                case TypeCode.Int16:
                                    dbType = OracleDbType.Int16; break;
                                case TypeCode.Int32:
                                    dbType = OracleDbType.Int32; break;
                                case TypeCode.Int64:
                                    dbType = OracleDbType.Int64; break;                                
                                case TypeCode.String:
                                    dbType = OracleDbType.Varchar2; break;                               
                                default:
                                    dbType = OracleDbType.Varchar2; break;
	                        }

                            oracleParameter = new OracleParameter(i.ToString(), dbType, (p as ICollection).Count);
                            //oracleParameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;                            
                            oracleParameter.Value = p;                            
                        }
                        else
                            oracleParameter = new OracleParameter(i.ToString(), p);                        
                    }
                    else
                    {
                        oracleParameter = new OracleParameter(i.ToString(), DBNull.Value);
                    }
                    c.Parameters.Add(oracleParameter);
                    i++;
                }
            }
        }
        
        #endregion
        
        ////////////////////////////////////////////////////////////////
        #region Méthodes de sélection des données

                
        /// <summary>
        /// Execute une requête paramétrée TRANSACTIONNELLE ou NON et retourne le résultat dans un DataSet
        /// <para>Si Transactionnelle : ouverture de connexion</para>
        /// <para>Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction</para>
        /// Liste de paramètres à ajouter sous forme de:
        /// <para>Valeur :
        ///     <para><example>- SELECT ... WHERE xxx = :1 AND xxx = :2</example></para>
        ///     <para><example>- AjoutParametre(c, -1, 10, DateTime.Now)</example></para>
        /// </para>
        /// <para>OracleParameter :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- AjoutParametre(c, -1, new OracleParameter(...), new OracleParameter(...))</example></para>
        /// </para>
        /// <para>OracleParameter[] :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- oraclePArray[0] = new OracleParameter() ...</example></para>
        ///     <para><example>- AjoutParametre(c, -1, oraclePArray)</example></para>
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete (paramètres sous la forme :1, :2 ...) </param>
        /// <param name="idTransaction">Identifiant de transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">Paramètres à ajouter, sous forme de valeur, d'OracleParameter ou de tableau d'OracleParameter</param>
        public ExtendedReturnedSelect ExecuterSelect(string as_sql, int idTransaction, params object[] parametres)
        {
            ExtendedReturnedSelect returnedSelect = new ExtendedReturnedSelect();
            returnedSelect.Query = as_sql;
            returnedSelect.Parametres = parametres;

            OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);
            try
            {
                OracleDataAdapter myAdapter = new OracleDataAdapter(c);                
                myAdapter.Fill(returnedSelect.Data);

                returnedSelect.HasError = false;
                returnedSelect.ErrCode = 0;
                returnedSelect.ErrText = "";
                returnedSelect.OracleException = null;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                returnedSelect.ErrCode = e.Number;
                returnedSelect.ErrText = e.Message;
                returnedSelect.HasError = true;
                returnedSelect.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                // Récupération de la connexion associée à la requête
                OracleConnection oracleCon = c.Connection;
                // Fermeture
                c.Dispose();
                if (idTransaction == -1) Close(oracleCon);
            }
            return returnedSelect;
        }

        // <summary>
        /// Execute une requête NON TRANSACTIONNELLE 
        /// et retourne le résultat dans une datatable
        /// <para>
        /// Si Transactionnelle : ouverture de connexion
        /// </para><para>
        /// Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete</param>
        public ExtendedReturnedSelect ExecuterSelect(string as_sql)
        {
            return ExecuterSelect(as_sql, -1);
        }

        /// <summary>
        /// Execute une requête TRANSACTIONNELLE et retourne le résultat dans une datatable
        /// </summary>
        /// <param name="as_sql">requete</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public ExtendedReturnedSelect ExecuterSelect(string as_sql, int idTransaction) 
        {
            return ExecuterSelect(as_sql, idTransaction, null);
        }

        /// <summary>
        /// Execute une requête paramétrée TRANSACTIONNELLE ou NON et retourne le résultat dans un DataSet
        /// <para>Si Transactionnelle : ouverture de connexion</para>
        /// <para>Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction</para>
        /// Liste de paramètres à ajouter sous forme de:
        /// <para>Valeur :
        ///     <para><example>- SELECT ... WHERE xxx = :1 AND xxx = :2</example></para>
        ///     <para><example>- AjoutParametre(c, -1, 10, DateTime.Now)</example></para>
        /// </para>
        /// <para>OracleParameter :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- AjoutParametre(c, -1, new OracleParameter(...), new OracleParameter(...))</example></para>
        /// </para>
        /// <para>OracleParameter[] :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- oraclePArray[0] = new OracleParameter() ...</example></para>
        ///     <para><example>- AjoutParametre(c, -1, oraclePArray)</example></para>
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete (paramètres sous la forme :1, :2 ...) </param>
        /// <param name="idTransaction">Identifiant de transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">Paramètres à ajouter, sous forme de valeur, d'OracleParameter ou de tableau d'OracleParameter</param>
        public ExtendedReturnedSelect<T> ExecuterSelect<T>(string as_sql, int idTransaction, params object[] parametres) where T : IEntity, new()
        {
            ExtendedReturnedSelect<T> returnedSelect = new ExtendedReturnedSelect<T>();
            returnedSelect.Query = as_sql;
            returnedSelect.Parametres = parametres;

            OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);
            try
            {
                //Stopwatch sw = new Stopwatch();
                //sw.Start();

                OracleDataReader OraDataRead = c.ExecuteReader();
                
                //sw.Stop();
                //Console.WriteLine("REQUETE={0}", sw.Elapsed.TotalSeconds);

                //sw.Restart();
                try
                {
                    if (OraDataRead.HasRows)
                    {
                        OraDataRead.FetchSize = OraDataRead.RowSize * 20000;

                        T oTest = new T();

                        // Cas d'un parsing avec la méthode "Parse" de l'objet métier
                        if (oTest is IEntityMethodParsing)
                        {                            
                            while (OraDataRead.Read())
                            {
                                // Parse de l'entity avec les données du data reader
                                T o = new T();
                                (o as IEntityMethodParsing).Parse(OraDataRead);

                                // Ajout de l'entity à la collection
                                returnedSelect.Data.Add(o);
                            }                            
                        }
                        // Cas d'un parsing avec classe externe (soit classe Parser par défaut, soit classe spécifique définit dans l'attribut TypeParserAttribute)
                        else 
                        {
                            // Récupération du parser associé au type d'entity à retourner
                            Parser<T> parser;
                            if (typeof(T).GetTypeParserAttribute() == null)
                                parser = new Parser<T>();
                            else
                                parser = Activator.CreateInstance(typeof(T).GetTypeParserAttribute()) as Parser<T>;

                            // Récupération (au besoin) des index des colonnes dans le data reader
                            parser.GetIndexes(OraDataRead);

                            // Récupération de la structure
                            for (int i = 0; i < OraDataRead.FieldCount; i++)
                            {
                                returnedSelect.Structure.Add(OraDataRead.GetName(i), OraDataRead.GetFieldType(i));
                            }
                                                       
                            while (OraDataRead.Read())
                            {
                                // Parse de l'entity avec les données du data reader
                                T o = (T)parser.Parse(OraDataRead);
    
                                // Ajout de l'entity à la collection
                                returnedSelect.Data.Add(o);
                            }

                        }
                        
                       
                        
                        //sw.Stop();
                        //Console.WriteLine("PARSING={0}", sw.Elapsed.TotalSeconds);
                    }
                }
                catch (Exception e)
                {
                    returnedSelect.ErrCode = 1;
                    returnedSelect.ErrText = e.Message;
                    returnedSelect.HasError = true;
                }
                finally
                {
                    // VERIFIER STATUT CONNECTION APRES CLOSE DATA READ
                    OraDataRead.Close();
                    OraDataRead.Dispose();
                }

                returnedSelect.HasError = false;
                returnedSelect.ErrCode = 0;
                returnedSelect.ErrText = "";
                returnedSelect.OracleException = null;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                returnedSelect.ErrCode = e.Number;
                returnedSelect.ErrText = e.Message;
                returnedSelect.HasError = true;
                returnedSelect.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                // Récupération de la connexion associée à la requête
                OracleConnection oracleCon = c.Connection;
                // Fermeture
                c.Dispose();
                if (idTransaction == -1) Close(oracleCon);
            }
            return returnedSelect;
        }

        /// <summary>
        /// Execute une requête NON TRANSACTIONNELLE 
        /// et retourne le résultat dans un DataSet.
        /// <para>
        /// Si Transactionnelle : ouverture de connexion
        /// </para><para>
        /// Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete</param>
        public ExtendedReturnedSelect<T> ExecuterSelect<T>(string as_sql) where T : IEntity, new()
        {
            return ExecuterSelect<T>(as_sql, -1);            
        }
        
        /// <summary>
        /// Execute une requête TRANSACTIONNELLE et retourne le résultat dans un DataSet
        /// </summary>
        /// <param name="as_sql">requete</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public ExtendedReturnedSelect<T> ExecuterSelect<T>(string as_sql, int idTransaction) where T : IEntity, new()
        {
            return ExecuterSelect<T>(as_sql, idTransaction, null);            
        }


        /// <summary>
        /// Exécute une requête TRANSACTIONNELLE ou NON paramétrée et ne retourne que 
        /// le premier champs de la première colonne (SELECT avec une seule valeur de retour)
        /// <para>Si Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction</para>
        /// <para>Si Non Transactionnelle : ouverture et fermeture de connexion par la requête</para>
        /// </summary>
        /// <param name="as_sql">requete (paramètres sous la forme :1, :2 ...)</param>
        /// <param name="idTransaction">Identifiant de la transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">liste de paramètres (params)</param>
        public ExtendedReturnedScalar ExecuterSelectScalar(string as_sql, int idTransaction, params object[] parametres)
        {
            ExtendedReturnedScalar returnedScalar = new ExtendedReturnedScalar();
            returnedScalar.Query = as_sql;
            returnedScalar.Parametres = parametres;

            OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);
            try
            {
                returnedScalar.Result = c.ExecuteScalar();
                returnedScalar.ErrCode = 0;
                returnedScalar.ErrText = "";
                returnedScalar.OracleException = null;
                returnedScalar.HasError = false;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                returnedScalar.Result = null;
                returnedScalar.ErrCode = e.Number;
                returnedScalar.ErrText = e.Message;
                returnedScalar.OracleException = e;
                returnedScalar.HasError = true;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                // Récupération de la connexion associée à la requête
                OracleConnection oracleCon = c.Connection;
                // Fermeture
                c.Dispose();
                if (idTransaction == -1) Close(oracleCon);
            }
            return returnedScalar;
        }


        /// <summary>
        /// Exécute une requête et ne retourne que le premier champs de la première 
        /// colonne (SELECT avec une seule valeur de retour)
        /// <para>Si Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction</para>
        /// <para>Si Non Transactionnelle : ouverture et fermeture de connexion gérées par la requête</para>
        /// </summary>
        /// <param name="as_sql">requête</param>        
        public ExtendedReturnedScalar ExecuterSelectScalar(string as_sql)
        {
            return ExecuterSelectScalar(as_sql, -1);            
        }


        /// <summary>
        /// Exécute une requête TRANSACTIONNELLE et ne retourne que le premier champs de la première colonne
        /// (SELECT avec une seule valeur de retour)
        /// </summary>
        /// <param name="as_sql">requête</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public ExtendedReturnedScalar ExecuterSelectScalar(string as_sql, int idTransaction)
        {
            return ExecuterSelectScalar(as_sql, idTransaction, null);            
        }

        
        
        #endregion
        
        
        ////////////////////////////////////////////////////////////////////
        #region Méthodes de mise à jour des données

        /// <summary>
        /// Execute une requête NON TRANSACTIONNELLE et retourne le nombre de lignes touchées 
        /// </summary>
        /// <param name="as_sql">requete</param>
        public ExtendedReturnedUpdate ExecuterUpdate(string as_sql)
        {
            return ExecuterUpdate(as_sql, -1);                        
        }

        /// <summary>
        /// Execute une requête TRANSACTIONNELLE et retourne le nombre de lignes touchées 
        /// </summary>
        /// <param name="as_sql">requete</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public ExtendedReturnedUpdate ExecuterUpdate(string as_sql, int idTransaction)
        {
            return ExecuterUpdate(as_sql, idTransaction, null);            
        }
        
        /// <summary>
        /// Execute une requête TRANSACTIONNELLE paramétrée et retourne le nombre de lignes touchées 
        /// Si Transactionnelle : ouverture de connexion
        /// Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction        
        /// </summary>
        /// <param name="as_sql">requete (paramètres sous la forme :1, :2 ...)</param>
        /// <param name="idTransaction">Identifiant de la transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">liste de parametres (params)</param>
        public ExtendedReturnedUpdate ExecuterUpdate(string as_sql, int idTransaction, params object[] parametres)
        {
            ExtendedReturnedUpdate rowCount = new ExtendedReturnedUpdate();
            OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);            
            try
            {
                rowCount.AffectedRows = c.ExecuteNonQuery();
                rowCount.HasError = false;
                rowCount.ErrCode = 0;
                rowCount.ErrText = "";
                rowCount.OracleException = null;

                ErrCode = 0;
                ErrText = "";                
            }
            catch (OracleException e)
            {
                rowCount.AffectedRows = -1;
                rowCount.HasError = true;
                rowCount.ErrCode = e.Number;
                rowCount.ErrText = e.Message;
                rowCount.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;                
            }
            finally
            {
                c.Dispose();
            }
            return rowCount;            
        }

        #endregion

        #region Exécution de procédure stockée

        /// <summary>
        /// Execute une requête NON TRANSACTIONNELLE d'appel à une procédure stockée et retourne le retour de la procédure
        /// </summary>
        /// <param name="as_sql">requete</param>
        public ExtendedReturnedProc ExecuterProc(string as_sql)
        {
            return ExecuterProc(as_sql, -1);
        }

        /// <summary>
        /// Execute une requête TRANSACTIONNELLE d'appel à une procédure stockée et retourne le retour de la procédure
        /// </summary>
        /// <param name="as_sql">requete</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public ExtendedReturnedProc ExecuterProc(string as_sql, int idTransaction)
        {
            return ExecuterProc(as_sql, idTransaction, null);
        }

        /// <summary>
        /// Execute une requête TRANSACTIONNELLE d'appel à une procédure stockée paramétrée et retourne le retour de la procédure
        /// </summary>
        /// <param name="as_sql">requete = nom de la procédure</param>
        /// <param name="idTransaction">Identifiant de la transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">liste de parametres (params)</param>
        public ExtendedReturnedProc ExecuterProc(string as_sql, int idTransaction, params object[] parametres)
        {
            ExtendedReturnedProc rowCount = new ExtendedReturnedProc();
            OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);
            c.CommandType = CommandType.StoredProcedure;
            try
            {
                c.ExecuteNonQuery();
                rowCount.HasError = false;
                rowCount.ErrCode = 0;
                rowCount.ErrText = "";
                rowCount.OracleException = null;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                //rowCount.Resultat = -1;
                rowCount.HasError = true;
                rowCount.ErrCode = e.Number;
                rowCount.ErrText = e.Message;
                rowCount.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                c.Dispose();
            }
            return rowCount;
        }

        #endregion




        #region DATABASE LINK

        public ExtendedReturnedUpdate CreateLink(int idTransaction, String nom, String alias, String login, string pwd)
        {
            //GRANT CREATE DATABASE LINK TO ADMIN

            ExtendedReturnedUpdate rowCount = new ExtendedReturnedUpdate();
            OracleCommand c = CreerCommande(
                String.Format("CREATE DATABASE LINK {0} CONNECT TO {1} IDENTIFIED BY {2} USING '{3}'", nom, login, pwd, alias), idTransaction);
            try
            {
                rowCount.AffectedRows = c.ExecuteNonQuery();
                rowCount.HasError = false;
                rowCount.ErrCode = 0;
                rowCount.ErrText = "";
                rowCount.OracleException = null;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                rowCount.AffectedRows = -1;
                rowCount.HasError = true;
                rowCount.ErrCode = e.Number;
                rowCount.ErrText = e.Message;
                rowCount.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                c.Dispose();
            }
            return rowCount;
        }


        public ExtendedReturnedUpdate DeleteLink(int idTransaction, String nom)
        {

            PurgeStatementCache(idTransaction);

            ExtendedReturnedUpdate rowCount = new ExtendedReturnedUpdate();
            OracleCommand c = CreerCommande(
                String.Format("DROP DATABASE LINK {0}", nom), idTransaction);
            try
            {
                rowCount.AffectedRows = c.ExecuteNonQuery();
                rowCount.HasError = false;
                rowCount.ErrCode = 0;
                rowCount.ErrText = "";
                rowCount.OracleException = null;

                ErrCode = 0;
                ErrText = "";
            }
            catch (OracleException e)
            {
                rowCount.AffectedRows = -1;
                rowCount.HasError = true;
                rowCount.ErrCode = e.Number;
                rowCount.ErrText = e.Message;
                rowCount.OracleException = e;

                ErrCode = e.ErrorCode;
                ErrText = e.Message;
            }
            finally
            {
                c.Dispose();
            }
            return rowCount;
        }

        #endregion


        /// <summary>
        /// Execute une requête paramétrée TRANSACTIONNELLE ou NON et retourne le résultat dans un OracleDataReader
        /// <para>Si Transactionnelle : ouverture de connexion</para>
        /// <para>Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction</para>
        /// Liste de paramètres à ajouter sous forme de:
        /// <para>Valeur :
        ///     <para><example>- SELECT ... WHERE xxx = :1 AND xxx = :2</example></para>
        ///     <para><example>- AjoutParametre(c, -1, 10, DateTime.Now)</example></para>
        /// </para>
        /// <para>OracleParameter :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- AjoutParametre(c, -1, new OracleParameter(...), new OracleParameter(...))</example></para>
        /// </para>
        /// <para>OracleParameter[] :
        ///     <para><example>- SELECT ... WHERE xxx = :xxx AND xxx = :xxx</example></para>
        ///     <para><example>- oraclePArray[0] = new OracleParameter() ...</example></para>
        ///     <para><example>- AjoutParametre(c, -1, oraclePArray)</example></para>
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete (paramètres sous la forme :1, :2 ...) </param>
        /// <param name="idTransaction">Identifiant de transaction (-1 si non transac., >=0 si transac)</param>
        /// <param name="parametres">Paramètres à ajouter, sous forme de valeur, d'OracleParameter ou de tableau d'OracleParameter</param>
        public IDataReader ExecuterReaderSelect(string as_sql, int idTransaction, params object[] parametres)
        {
            OracleCommand oc = CreerCommande(as_sql, idTransaction, parametres);
            if (oc.Connection.State == ConnectionState.Closed || oc.Connection.State == ConnectionState.Broken)
                oc.Connection.Open();
            OracleDataReader OraDataRead = oc.ExecuteReader();

            return OraDataRead;
        }

        /// <summary>
        /// Execute une requête NON TRANSACTIONNELLE 
        /// et retourne le résultat dans un DataSet.
        /// <para>
        /// Si Transactionnelle : ouverture de connexion
        /// </para><para>
        /// Si Non Transactionnelle : Pas d'ouverture de connexion, elle doit se faire au début de la transaction
        /// </para>
        /// </summary>
        /// <param name="as_sql">requete</param>
        public IDataReader ExecuterReaderSelect(string as_sql)
        {
            return ExecuterReaderSelect(as_sql, -1);
        }

        /// <summary>
        /// Execute une requête TRANSACTIONNELLE et retourne le résultat dans un DataSet
        /// </summary>
        /// <param name="as_sql">requete</param>
        /// <param name="idTransaction">Identifiant de la transaction</param>
        public IDataReader ExecuterReaderSelect(string as_sql, int idTransaction)
        {
            return ExecuterReaderSelect(as_sql, idTransaction, null);
        }

        ////////////////////////////////////////////////////////////////
        #region Méthodes de sélection des données AVEC OracleDataReader

        public OracleDataReader ExecuterSelectReader(string as_sql, int idTransaction, params object[] parametres)
        {
            try
            {
                OracleCommand c = CreerCommande(as_sql, idTransaction, parametres);
                OracleDataReader dr = c.ExecuteReader();
                ErrCode = 0;
                ErrText = "";
                return dr;
            }
            catch (OracleException e)
            {
                ErrCode = e.Number;
                ErrText = e.Message;
            }
            finally
            {
                //if (idTransaction == -1) Close(_oracleCon);
            }
            return null;
        }

        public OracleDataReader ExecuterSelectReader(string as_sql)
        {
            return ExecuterSelectReader(as_sql, -1);
        }

        public OracleDataReader ExecuterSelectReader(string as_sql, int idTransaction)
        {
            return ExecuterSelectReader(as_sql, idTransaction, null);
        }

        #endregion

    }        
}
