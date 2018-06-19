using System;
using System.IO;

namespace Global.Oracle
{
    public class SecureDal
    {

        #region NetworkPath

        /// <summary>
        /// Converti un chemin formaté avec une lettre de lecteur ("J:\....") en son équivalent 
        /// réseau s'il existe ("\\NOM_DE_SERVEUR...")
        /// </summary>
        /// <param name="networkDrivePath">Chemin à convertir</param>
        /// <returns>Le chemin initial si non trouvé</returns>
        public static String NetworkDrivePathToUNCPath(String networkDrivePath)
        {
            // Récupération d'un côté la lettre, de l'autre le reste du chemin
            String[] pathArray = networkDrivePath.Split(new Char[] {Path.VolumeSeparatorChar}, 2, StringSplitOptions.RemoveEmptyEntries);
            if (pathArray[0] != null && pathArray[0].Length == 1)
            {
                // Récupération du chemin associé à la lettre
                String newRoot = NetworkDriveLetterToUNCPath(Char.Parse(pathArray[0]));
                if (newRoot != null && newRoot != String.Empty)
                {
                    // Chemin équivalent trouvé 
                    // Suppression des "/" en fin de chaine 1 et début de chaine 2
                    while (pathArray[1].StartsWith(@"\")) pathArray[1] = pathArray[1].Remove(0, 1);
                    while (newRoot.EndsWith(@"\")) newRoot = newRoot.Remove(newRoot.Length - 1, 1);

                    // Construction du nouveau chemin
                    return String.Format(@"{0}\{1}", newRoot, pathArray[1]);
                }
                else
                {
                    // Pas de chemin équivalent trouvé
                    return networkDrivePath;
                }
            }
            else
            {
                return networkDrivePath;
            }
        }

        /// <summary>
        /// Retourne l'équivalence de chemin réseau (UNC par exemple) associée à une lettre de lecteur réseau
        /// </summary>
        /// <param name="networkDrive">Lettre du lecteur</param>
        public static String NetworkDriveLetterToUNCPath(char networkDrive)
        {
            OracleTrans o = OracleTrans.getInstance;
            ExtendedReturnedScalar res = o.ExecuterSelectScalar(
                    "SELECT path FROM ext_net_drive WHERE UPPER(drive) = :1 AND NVL(inactif, 0) = 0 ", -1, networkDrive.ToString().ToUpper());
            if (o.ErrCode > 0 || res.Result == null || res.Result == DBNull.Value)
                return null;
            else
                return (String)res.Result;        
        }           

        #endregion

        #region VERSIONS

        /// <summary>
        /// Récupère le répertoire ARCHIVE dans la table SOCIETE
        /// </summary>
        /// <param name="codeLogiciel"></param>
        /// <returns></returns>
        public static String GetRepArchive(int codeSociete)
        {
            OracleTrans o = OracleTrans.getInstance;
            ExtendedReturnedScalar res = o.ExecuterSelectScalar(
                    "SELECT BD_NET FROM SOCIETE WHERE CD_SOCIETE = :1", -1, codeSociete);
            if (res.Result == null || res.Result == null || res.Result == DBNull.Value)
                return "";
            else
                return (String)res.Result;
        }

        
        /// <summary>
        /// Récupère la version associée au logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        /// <returns></returns>
        public static String GetVersion(int codeLogiciel)
        {
            OracleTrans o = OracleTrans.getInstance;
            ExtendedReturnedScalar res = o.ExecuterSelectScalar(
                    "SELECT n_version FROM VERSION WHERE CD_LOGICIEL = :1", -1, codeLogiciel);
            if (res.Result == null || res.Result == null || res.Result == DBNull.Value)
                return "";
            else
                return (String)res.Result;
        }

        /// <summary>
        /// Récupère la version associée au logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        /// <returns></returns>
        public static String GetVersion(String nomLogiciel)
        {
            OracleTrans o = OracleTrans.getInstance;
            ExtendedReturnedScalar res = o.ExecuterSelectScalar(
                    "SELECT n_version FROM VERSION WHERE CD_VERSION = :1", -1, nomLogiciel);
            if (res.Result == null || res.Result == null || res.Result == DBNull.Value)
                return "";
            else
                return (String)res.Result;
        }

        /// <summary>
        /// Vérifie la version du logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        /// <param name="version"></param>
        public static Boolean CheckVersion(int codeLogiciel, String version)
        {
            OracleTrans o = OracleTrans.getInstance;
            return 
                Convert.ToInt32(o.ExecuterSelectScalar(
                    "SELECT count(*) FROM VERSION WHERE CD_LOGICIEL = :1 AND N_VERSION = :2", -1, codeLogiciel, version).Result) == 1;
        }

        /// <summary>
        /// Vérifie la version du logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        /// <param name="version"></param>
        public static Boolean CheckVersion(String nomLogiciel, String version)
        {
            OracleTrans o = OracleTrans.getInstance;
            return
                Convert.ToInt32(o.ExecuterSelectScalar(
                    "SELECT count(*) FROM VERSION WHERE CD_VERSION = :1 AND N_VERSION = :2", -1, nomLogiciel, version).Result) == 1;
        }

        #endregion

        #region LICENCES

        /// <summary>
        /// Nombre de licence pour un identifiant de clé
        /// </summary>
        /// <param name="codeLogiciel"></param>
        //public static int NbLicCle(int codeLogiciel)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    ExtendedReturnedScalar res = o.ExecuterSelectScalar("SELECT VALEUR FROM CELL WHERE CD_CELL = :1", -1, codeLogiciel);
        //    if (res.Result != null && res.Result != DBNull.Value)
        //    {
        //        String valeur = Crypte((String)res.Result, false);

        //        String codeCellule = valeur.Substring(6, 2);
        //        int nbLicence = int.Parse(valeur.Substring(16, 5));
        //        return nbLicence;
        //    }
        //    else
        //        return 0;
        //}

        /// <summary>
        /// Nombre de licence pour un logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        private static int NbLicCleLogiciel(int codeLogiciel)
        {
            return NbLicCleLogiciel(codeLogiciel, -1);
        }

        /// <summary>
        /// Nombre de licence pour un logiciel
        /// </summary>
        /// <param name="codeLogiciel"></param>
        private static int NbLicCleLogiciel(int codeLogiciel, int transac)
        {
            OracleTrans o = OracleTrans.getInstance;
            ExtendedReturnedScalar res = o.ExecuterSelectScalar(
                "SELECT CELL.VALEUR FROM CELL, VERSION WHERE CELL.CD_CELL = VERSION.CD_CELL AND VERSION.CD_LOGICIEL = :1", transac, codeLogiciel);
            if (res.Result != null && res.Result != DBNull.Value)
            {
                String valeur = Crypte((String)res.Result, false);

                String codeCellule = valeur.Substring(6, 2);
                int nbLicence = int.Parse(valeur.Substring(16, 5));
                return nbLicence;
            }
            else
                return 0;
        }

        /// <summary>
        /// Récupère l'id client de la clé
        /// </summary>
        /// <param name="codeLogiciel"></param>
        //private static int IdClientCle() //int cdCell
        //{
        //    int cdCellIdClient = 56;

        //    try
        //    {
        //        OracleTrans o = OracleTrans.getInstance;
        //        ExtendedReturnedScalar res = o.ExecuterSelectScalar("SELECT VALEUR FROM CELL WHERE CD_CELL = :1", -1, cdCellIdClient);
        //        if (res.Result != null && res.Result != DBNull.Value)
        //        {
        //            String valeur = Crypte((String)res.Result, false);

        //            String codeCellule = valeur.Substring(6, 2);
        //            int code = Convert.ToInt32(valeur.Substring(16, 5));
        //            return code;
        //        }
        //        else
        //            return -1;
        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //}


        //// Durée de référence (en seconde) pour purger les sessions opérateur (si délai inactivité > à cette valeur, alors purge)
        //private const int _DUREE_INACTIVITE = 10;
        

        ///// <summary>
        ///// Log la connexion d'un opérateur à un logiciel
        ///// </summary>
        //public static String LogOperateur(int cdPlaAffRess, int cdLogiciel, int cdExtLogFct)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    int transac = o.DebutTransaction();
        //    Boolean res = true;

        //    try
        //    {
        //        // Purge des sessions existantes qui dépassent le délai d'inactivité
        //        res = res && PurgerLogOperateur(cdLogiciel, cdExtLogFct,_DUREE_INACTIVITE);

        //        // - Récupération du nombre de connectés
        //        ExtendedReturnedScalar resultOpeCon = o.ExecuterSelectScalar(
        //            " SELECT COUNT(*) as NB_OPE_CON " +
        //            " FROM EXT_LOG_OPE_LOG " + 
        //            " WHERE CD_LOGICIEL = :1 " +
        //            " AND NVL(ACTIF, 0) = 1 ", 
        //            transac, cdLogiciel);

        //        if (resultOpeCon.Result == null)
        //            throw new Exception("Impossible de récupérer le nombre d'utilisateur connectés. " + (resultOpeCon.OracleException != null ? resultOpeCon.OracleException.Message : ""));
        //        else
        //        {
        //            // - Comparaison avec la clé
        //            // - nombre de licences sur la clé
        //            // (si cd_logiciel = 10 et cd_ext_log_fct = 7, alors eCynaps pointage, test avec cd_logiciel = 5 (CAB) parceque pas de clé spécifique à eCynaps pointage pour le moment)
        //            int nbLicAuto = NbLicCleLogiciel(cdLogiciel == 10 && cdExtLogFct == 7 ? 5 : cdLogiciel, transac);
        //            // - nombre de licences majoré
        //            int nbLicPlus = Convert.ToInt32(Math.Round(nbLicAuto * 0.10));
        //            int nbLicAutoMaj = nbLicAuto + Convert.ToInt32(Math.Round(nbLicAuto * 0.10));
        //            // - nombre de connectés + tentative courante
        //            int nbOpeCon = Convert.ToInt32(resultOpeCon.Result) + 1;
        //            // - comparaison nombre de connecté + tentative courante / nombre de licences sur clé + 10%
        //            if ( nbOpeCon > nbLicAutoMaj)
        //                throw new Exception(String.Format("Nombre de licences autorisé atteint ({0}/({1} + {2})). ", nbOpeCon, nbLicAuto, nbLicPlus));

        //            // OK, création d'un ID de session
        //            String sessionId = Guid.NewGuid().ToString();

        //            // - OK, log ou maj du log de l'opérateur
        //            //////////////////////////////////////////
        //            // A REMPLACER PAR INSERT!
        //            //////////////////////////////////////////
        //            ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
        //                        //" MERGE   " +
        //                        //"       INTO EXT_LOG_OPE_LOG t1   " +
        //                        //" USING  " +
        //                        //"   (    " +
        //                        ////"       SELECT    " +
        //                        ////"           EXT_LOG_OPE_LOG.CD_PLA_AFF_RESS,  " +
        //                        ////"           EXT_LOG_OPE_LOG.CD_LOGICIEL  " +
        //                        ////"       FROM " +
        //                        ////"           EXT_LOG_OPE_LOG " +
        //                        ////"       WHERE " +
        //                        ////"           EXT_LOG_OPE_LOG.CD_PLA_AFF_RESS = :1 " +
        //                        ////"       AND EXT_LOG_OPE_LOG.CD_LOGICIEL = :2 " +

        //                        //"         SELECT " +
        //                        //"              :1 as CD_PLA_AFF_RESS, " +
        //                        //"              :2 as CD_LOGICIEL, " +
        //                        //"              :3 as CD_EXT_LOG_FCT, " +
        //                        //"              :4 as SESSION_ID " +
        //                        //"         FROM DUAL " +

        //                        //"   ) t2 " +

        //                        //" ON ( " +
        //                        //"       t1.CD_PLA_AFF_RESS = t2.CD_PLA_AFF_RESS " +
        //                        //"   AND t1.CD_LOGICIEL = t2.CD_LOGICIEL " +
        //                        //"   AND t1.CD_EXT_LOG_FCT = t2.CD_EXT_LOG_FCT " +
        //                        //"   AND t1.SESSION_ID = t1.SESSION_ID " +                               
        //                        //" ) " +

        //                        //" WHEN MATCHED THEN     " +
        //                        //"   UPDATE SET " +
        //                        //"       t1.DATE_MAJ = SYSDATE, " +
        //                        //"       t1.ACTIF = 1 " +

        //                        //" WHEN NOT MATCHED THEN  " +
        //                        //"   INSERT " +
        //                        //"       (CD_EXT_LOG_OPE_LOG, CD_PLA_AFF_RESS, CD_LOGICIEL, CD_EXT_LOG_FCT, SESSION_ID, DATE_CREAT, DATE_MAJ, ACTIF) " +
        //                        //"   VALUES " +
        //                        //"       (SEQ_EXT_LOG_OPE_LOG.NEXTVAL, t2.CD_PLA_AFF_RESS, t2.CD_LOGICIEL, t2.CD_EXT_LOG_FCT, t2.SESSION_ID, SYSDATE, SYSDATE, 1)",
        //                        " INSERT INTO EXT_LOG_OPE_LOG " +
        //                        "        (CD_EXT_LOG_OPE_LOG, CD_PLA_AFF_RESS, CD_LOGICIEL, CD_EXT_LOG_FCT, SESSION_ID, DATE_CREAT, DATE_MAJ, ACTIF) " +
        //                        " VALUES (SEQ_EXT_LOG_OPE_LOG.NEXTVAL, :1, :2, :3, :4, SYSDATE, SYSDATE, 1)",
        //                        transac,
        //                        cdPlaAffRess, cdLogiciel, cdExtLogFct, sessionId);

        //            res = res && resultLogOpe.ErrCode == 0;

        //            if (!res) throw new Exception("Impossible d'enregistrer la session opérateur. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));

        //            if (res)
        //            {
        //                o.RollBack(transac);
        //                //o.Commit(transac);
        //                return sessionId;
        //            }
        //            else
        //            {
        //                o.RollBack(transac);
        //                return "";
        //            }                                        
        //        }
                        
        //    }
        //    catch (Exception ex)
        //    {
        //        o.RollBack(transac);
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Unlog la connexion d'un opérateur à un logiciel
        ///// </summary>
        //public static Boolean UnlogOperateur(int cdPlaAffRess, int cdLogiciel, int cdExtLogFct, String sessionId)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    int transac = o.DebutTransaction();
        //    Boolean res = true;

        //    try
        //    {
        //        ExtendedReturnedUpdate result = OracleTrans.getInstance.ExecuterUpdate(
        //            " DELETE FROM EXT_LOG_OPE_LOG WHERE CD_PLA_AFF_RESS = :1 AND CD_LOGICIEL = :2 AND CD_EXT_LOG_FCT = :3 AND SESSION_ID = :4 ",
        //            -1,
        //            cdPlaAffRess, cdLogiciel, cdExtLogFct, sessionId);
                
        //        res = res && result.ErrCode == 0;

        //        if (!res) throw new Exception("Impossible d'enregistrer la déconnexion opérateur. " + (result.OracleException != null ? result.OracleException.Message : ""));

        //        if (res)
        //            o.RollBack(transac);
        //        //o.Commit(transac);
        //        else
        //            o.RollBack(transac);

        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        o.RollBack(transac);
        //        throw ex;
        //    }
        //}


        ///// <summary>
        ///// Mise à jour de l'activité de la connexion d'un opérateur à un logiciel
        ///// </summary>
        //public static Boolean MajActiviteLogOperateur(int cdPlaAffRess, int cdLogiciel, int cdExtLogFct, String sessionId)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    int transac = o.DebutTransaction();
        //    Boolean res = true;

        //    try
        //    {            
        //        // Vérifie la présence en base du log opérateur
        //        try
        //        {
        //            res = res &&
        //                Convert.ToInt32(o.ExecuterSelectScalar(
        //                        "SELECT count(*) FROM EXT_LOG_OPE_LOG " +
        //                        " WHERE CD_PLA_AFF_RESS = :1 " +
        //                        "   AND CD_LOGICIEL = :2 " +
        //                        "   AND CD_EXT_LOG_FCT = :3" +
        //                        "   AND SESSION_ID = :4 ",
        //                        transac,
        //                        cdPlaAffRess, cdLogiciel, cdExtLogFct, sessionId).Result) > 0;
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Impossible de retrouver la session opérateur. ");
        //        }                

        //        if (res)
        //        {
        //            ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
        //                        " UPDATE EXT_LOG_OPE_LOG SET " +
        //                        "   DATE_MAJ = SYSDATE, " +
        //                        "   ACTIF = 1 " +
        //                        " WHERE CD_PLA_AFF_RESS = :1 " +
        //                        "   AND CD_LOGICIEL = :2 " +
        //                        "   AND CD_EXT_LOG_FCT = :3" +
        //                        "   AND SESSION_ID = :4 ",
        //                        transac,
        //                        cdPlaAffRess, cdLogiciel, cdExtLogFct, sessionId);

        //            res = res && resultLogOpe.ErrCode == 0;

        //            if (!res) throw new Exception("Impossible de mettre à jour l'activité de la connexion opérateur. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));

        //            if (res)
        //                o.RollBack(transac);
        //                //o.Commit(transac);
        //            else
        //                o.RollBack(transac);

        //            return res;
        //        }
        //        else
        //            return false;

        //    }
        //    catch (Exception ex)
        //    {
        //        o.RollBack(transac);
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Purge des logs opérateur > durée
        ///// </summary>
        //private static Boolean PurgerLogOperateur(int cdLogiciel, int cdExtLogFct, int dureeSecondes)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    int transac = o.DebutTransaction();
        //    Boolean res = true;

        //    try
        //    {
        //        res = PurgerLogOperateur(cdLogiciel, cdExtLogFct, dureeSecondes, transac);

        //        if (res)
        //            o.Commit(transac);
        //        else
        //            o.RollBack(transac);

        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        o.RollBack(transac);
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Purge des logs opérateur > durée
        ///// </summary>
        //private static Boolean PurgerLogOperateur(int cdLogiciel, int cdExtLogFct, int dureeSecondes, int transac)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
            
        //    Boolean res = true;

        //    try
        //    {
        //        // Purge à la durée + une minute
        //        //dureeSecondes += 60;
        //        dureeSecondes += 5;

        //        ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
        //                    " DELETE FROM EXT_LOG_OPE_LOG WHERE CD_LOGICIEL = :1 AND CD_EXT_LOG_FCT = :2 AND (SYSDATE - DATE_MAJ) > (:3 / 60 / 60 / 24) ",
        //                    transac,
        //                    cdLogiciel, cdExtLogFct, dureeSecondes);

        //        res = res && resultLogOpe.ErrCode == 0;

        //        if (!res) throw new Exception("Impossible de mettre à jour l'activité de la connexion opérateur. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));

        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        




        #endregion

        #region SESSION CLE UTILSATEUR LOGICIEL


        // Durée de référence (en seconde) pour purger les sessions opérateur (si délai inactivité > à cette valeur, alors purge)
        private const int _DUREE_INACTIVITE = 60;
        private const int _FREQUENCE_PURGE = 300;   // 5 min
        private static Boolean _COMMIT = true;
        private static Object LOCK = new Object();
        private static DateTime _dateDernierePurge = DateTime.MinValue;



        public static Boolean TableSessionOk()
        {
            ExtendedReturnedSelect r = OracleTrans.getInstance.ExecuterSelect("SELECT 1 FROM ALL_TABLES WHERE UPPER(TABLE_NAME) = 'LOGICIEL_SESSIONS'");
            return r.ErrCode == 0 && r.Data != null && r.Data.Rows.Count > 0;
        }


        /// <summary>
        /// Enregistrement d'une nouvelle session d'utilisation à un logiciel et vérification de la clé associée
        /// </summary>
        public static Boolean CreerNouvelleSessionCle(int cdLogiciel, string sessionId, string infos)
        {

            lock (LOCK) 
            {
                if (DateTime.Now.Subtract(_dateDernierePurge).TotalSeconds > _FREQUENCE_PURGE)
                {
                    try
                    {
                        _dateDernierePurge = DateTime.Now;

                        // Purge des sessions existantes qui dépassent le délai d'inactivité
                        PurgerSessionsCle(cdLogiciel, _DUREE_INACTIVITE);                        
                    }
                    catch (Exception) { }
                }                
            }            

            OracleTrans o = OracleTrans.getInstance;
            int transac = o.DebutTransaction();
            Boolean res = true;

            try
            {

                // Test si session existe déjà
                Boolean existsSession = false;
                if (sessionId != "")
                {
                    ExtendedReturnedScalar resultSessionCourante = o.ExecuterSelectScalar(
                        " SELECT COUNT(*)" +
                        " FROM LOGICIEL_SESSIONS " +
                        " WHERE CD_LOGICIEL = :1 " +
                        " AND SESSION_ID = :2",
                        transac, cdLogiciel, sessionId);

                    if (Convert.ToInt32(resultSessionCourante.Result) > 0)
                    {
                        existsSession = true;
                        Boolean sessionAMAJ = false;

                        // SI DATE_MAJ session courante > DUREE_INACTIVITE => SESSION NON ACTIVE => test clé
                        ExtendedReturnedScalar resultSessionCouranteActive = o.ExecuterSelectScalar(
                            " SELECT CASE WHEN (SYSDATE - DATE_MAJ) < (:2 / 60 / 60 / 24) THEN 1 ELSE 0 END as SESSION_ACTIVE " +
                            " FROM LOGICIEL_SESSIONS " +
                            " WHERE CD_LOGICIEL = :1 " +
                            " AND SESSION_ID = :3",
                            transac, cdLogiciel, _DUREE_INACTIVITE, sessionId);

                        // Si session non active -> test clé
                        if (Convert.ToInt32(resultSessionCouranteActive.Result) == 0)
                        {
                            sessionAMAJ = TestCle(cdLogiciel, sessionId, _DUREE_INACTIVITE, transac);
                        }
                        else
                            // Sinon mise à jour activité session
                            sessionAMAJ = true;
                        
                        if (sessionAMAJ)
                        {
                            //MajActiviteSessionCle(cdLogiciel, sessionId, transac);
                            ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
                                        " UPDATE LOGICIEL_SESSIONS SET " +
                                        "   DATE_MAJ = SYSDATE, " +
                                        "   DUREE_ACTIVITE = Round((DATE_MAJ - DATE_CREAT) * 24 * 60, 2) " + // EN MINUTES
                                        " WHERE CD_LOGICIEL = :1 " +
                                        "   AND SESSION_ID = :2 ",
                            transac,
                            cdLogiciel, sessionId);

                            res = res && resultLogOpe.ErrCode == 0;

                            if (!res) throw new Exception("Impossible de mettre à jour l'activité de la session d'utilisation. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));
                        }                        
                    }
                    else
                    {
                        existsSession = false;
                    }
                                        
                    if (!existsSession)
                    {
                        res = res && TestCle(cdLogiciel, null, _DUREE_INACTIVITE, transac);

                        if (res)
                        {
                            // - OK, nouvelle session
                            ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
                                        " INSERT INTO LOGICIEL_SESSIONS " +
                                        "        (CD_LOGICIEL_SESSIONS, CD_LOGICIEL, SESSION_ID, INFOS, DATE_CREAT, DATE_MAJ, DUREE_ACTIVITE) " +
                                        " VALUES (SEQ_LOGICIEL_SESSIONS.NEXTVAL, :1, :2, :3, SYSDATE, SYSDATE, 0)",
                                        transac,
                                        cdLogiciel, sessionId, infos);

                            res = res && resultLogOpe.ErrCode == 0;

                            if (!res)
                                throw new Exception("Impossible d'enregistrer la session d'utilisation. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));
                        }
                    }

                    if (res)
                    {
                        if (_COMMIT)
                            o.Commit(transac);
                        else
                            o.RollBack(transac);

                        return res;
                    }
                    else
                    {
                        o.RollBack(transac);
                        return false;
                    }
                }                
                else
                {
                    o.RollBack(transac);
                    return false;
                }
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }                        
        }

        /// <summary>
        /// Suppression de la session d'utilisation du logiciel
        /// </summary>
        public static Boolean SupprimerSessionCle(int cdLogiciel, String sessionId)
        {
            
            OracleTrans o = OracleTrans.getInstance;
            int transac = o.DebutTransaction();
            Boolean res = true;

            try
            {
                ExtendedReturnedUpdate result = OracleTrans.getInstance.ExecuterUpdate(
                    " DELETE FROM LOGICIEL_SESSIONS WHERE CD_LOGICIEL = :1 AND SESSION_ID = :2 ",
                    -1,
                    cdLogiciel, sessionId);

                res = res && result.ErrCode == 0;

                if (!res) throw new Exception("Impossible de supprimer la session utilisateur. " + (result.OracleException != null ? result.OracleException.Message : ""));

                if (res)
                {
                    if (_COMMIT)
                        o.Commit(transac);
                    else
                        o.RollBack(transac);   
                }
                else
                    o.RollBack(transac);

                return res;
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }
        }
        
        ///// <summary>
        ///// Mise à jour de l'activité de session d'utilisation d'un logiciel
        ///// </summary>
        //public static Boolean MajActiviteSessionCle(int cdLogiciel, String sessionId)
        //{
        //    lock (LOCK)
        //    {
        //        if (DateTime.Now.Subtract(_dateDernierePurge).TotalSeconds < 10)
        //        {
        //            try
        //            {
        //                // Purge des sessions existantes qui dépassent le délai d'inactivité
        //                PurgerSessionsCle(cdLogiciel, _DUREE_INACTIVITE);
        //                _dateDernierePurge = DateTime.Now;
        //            }
        //            catch (Exception) { }
        //        }
        //    }
            
        //    OracleTrans o = OracleTrans.getInstance;
        //    int transac = o.DebutTransaction();
        //    Boolean res = true;

        //    // Vérifie la présence en base du log opérateur
        //    try
        //    {
        //        res = res && MajActiviteSessionCle(cdLogiciel, sessionId, transac);

        //        if (res)
        //        {
        //            if (_COMMIT)
        //                o.Commit(transac);
        //            else
        //                o.RollBack(transac);
        //        }
        //        else
        //            o.RollBack(transac);

        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        o.RollBack(transac);
        //        throw ex;
        //    }            
        //}

        ///// <summary>
        ///// Mise à jour de l'activité de session d'utilisation d'un logiciel
        ///// </summary>
        //private static Boolean MajActiviteSessionCle(int cdLogiciel, String sessionId, int transac)
        //{
        //    OracleTrans o = OracleTrans.getInstance;
        //    Boolean res = true;

        //    try
        //    {
        //        // Vérifie la présence en base du log opérateur
        //        try
        //        {
        //            res = res &&
        //                Convert.ToInt32(o.ExecuterSelectScalar(
        //                        "SELECT count(*) FROM LOGICIEL_SESSIONS " +
        //                        " WHERE CD_LOGICIEL = :1 " +
        //                        "   AND SESSION_ID = :2 ",
        //                        transac,
        //                        cdLogiciel, sessionId).Result) > 0;

        //            if (!res)
        //                return false;

        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Impossible de retrouver la session d'utilisation. ");
        //        }

        //        if (res)
        //        {
        //            ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
        //                        " UPDATE LOGICIEL_SESSIONS SET " +
        //                        "   DATE_MAJ = SYSDATE, " +
        //                        "   DUREE_ACTIVITE = Round((DATE_MAJ - DATE_CREAT) * 24 * 60, 2) " + // EN MINUTES
        //                        " WHERE CD_LOGICIEL = :1 " +
        //                        "   AND SESSION_ID = :2 ",
        //                        transac,
        //                        cdLogiciel, sessionId);

        //            res = res && resultLogOpe.ErrCode == 0;

        //            if (!res) throw new Exception("Impossible de mettre à jour l'activité de la session d'utilisation. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));

        //            return res;
        //        }
        //        else
        //        {
        //            return false;
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Purge des logs opérateur > durée
        /// </summary>
        private static Boolean PurgerSessionsCle(int cdLogiciel, int dureeSecondes)
        {
            OracleTrans o = OracleTrans.getInstance;
            int transac = o.DebutTransaction();
            Boolean res = true;

            try
            {
                res = PurgerSessionsCle(cdLogiciel, dureeSecondes, transac);

                if (res)
                {
                    if (_COMMIT)
                        o.Commit(transac);
                    else
                        o.RollBack(transac);   
                }
                else
                    o.RollBack(transac);

                return res;

            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }
            
        }

        /// <summary>
        /// Purge des logs opérateur > durée
        /// </summary>
        private static Boolean PurgerSessionsCle(int cdLogiciel, int dureeSecondes, int transac)
        {
            OracleTrans o = OracleTrans.getInstance;

            Boolean res = true;

            try
            {
                // Purge à la durée + une minute
                dureeSecondes += 60;
                
                ExtendedReturnedUpdate resultLogOpe = o.ExecuterUpdate(
                            " DELETE FROM LOGICIEL_SESSIONS WHERE (SYSDATE - DATE_MAJ) > (:1 / 60 / 60 / 24) ", //CD_LOGICIEL = :1 AND 
                            transac,
                            dureeSecondes);

                res = res && resultLogOpe.ErrCode == 0;

                if (!res) throw new Exception("Impossible de purger les sessions d'utilisation. " + (resultLogOpe.OracleException != null ? resultLogOpe.OracleException.Message : ""));

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static Boolean TestCle(int cdLogiciel, String sessionID, int dureeSecondes, int transac)
        {
            OracleTrans o = OracleTrans.getInstance;

            ExtendedReturnedScalar resultOpeCon = o.ExecuterSelectScalar(
                           " SELECT COUNT(*) as NB_OPE_CON " +
                           " FROM LOGICIEL_SESSIONS " +
                           " WHERE CD_LOGICIEL = :1 " +
                           " AND (SYSDATE - DATE_MAJ) < (:2 / 60 / 60 / 24) " +
                           (sessionID != null && sessionID != "" ? " AND TRIM(SESSION_ID) <> '" + sessionID.Trim() + "'" : ""),
                           transac, cdLogiciel, _DUREE_INACTIVITE);


            if (resultOpeCon.Result == null)
                throw new Exception("Impossible de récupérer le nombre d'utilisateur connectés. " + (resultOpeCon.OracleException != null ? resultOpeCon.OracleException.Message : ""));
            else
            {
                // - Comparaison avec la clé
                // - nombre de licences sur la clé
                // (si cd_logiciel = 10 et cd_ext_log_fct = 7, alors eCynaps pointage, test avec cd_logiciel = 5 (CAB) parceque pas de clé spécifique à eCynaps pointage pour le moment)
                int nbLicAuto = NbLicCleLogiciel(cdLogiciel, transac);
                // - nombre de licences majoré
                int nbLicPlus = Convert.ToInt32(Math.Round(nbLicAuto * 0.10));
                int nbLicAutoMaj = nbLicAuto + Convert.ToInt32(Math.Round(nbLicAuto * 0.10));
                // - nombre de connectés
                int nbOpeCon = Convert.ToInt32(resultOpeCon.Result);
                // - comparaison nombre de connecté + tentative courante / nombre de licences sur clé + 10%
                ////////////////
                // TEST
                //nbLicAutoMaj = 2;
                ////////////////
                /// TODO: Ajouter contrôle sur licences clé
                // ERREUR LICENCE
                //if (nbOpeCon >= nbLicAutoMaj)
                //    throw new Exception(String.Format("Nombre de licences autorisé atteint ({0}/({1} + {2})). ", nbOpeCon, nbLicAuto, nbLicPlus));
                //else
                //    return true;                
                return true;
            }

        }
        
        public static ExtendedReturnedSelect GetSessionsCle(int cdLogiciel)
        {
            return OracleTrans.getInstance.ExecuterSelect(
                " SELECT LOGICIEL_SESSIONS.*, " +
                " SYSDATE as DATE_NOW, " +
                " CASE WHEN (SYSDATE - DATE_MAJ) < (:2 / 60 / 60 / 24) THEN 1 ELSE 0 END as ACTIVE " +
                " FROM LOGICIEL_SESSIONS WHERE CD_LOGICIEL = :1 ", -1, cdLogiciel, _DUREE_INACTIVITE);
        }

        public static int GetNbLicLogiciel(int cdLogiciel)
        {
            return NbLicCleLogiciel(cdLogiciel);
        }

        #endregion

        #region MODULE

        /// <summary>
        /// Teste si un module est activé ou non sur la clé (ne fonctionne qu'avec cd_logiciel = 40)
        /// </summary>
        /// <param name="cdLogiciel">code logiciel (helios / helios II = 40)</param>
        /// <param name="cdModule">code module</param>
        /// <returns>
        ///     "0" ou "1" si on cherche une activation de module
        ///     "" si erreur
        /// </returns>
        public static string TestCleModule(int cdLogiciel, int cdModule)
        {
            int cellAdd;
            int module = cdModule;


            switch (cdLogiciel)
            {
                case 51:    // HELIOS
                    // Pour Hélios on a une cellule par module	
                    return "";
                case 40:    // HELIOS II
                    if (cdModule >= 1 && cdModule <= 16)
                    {
                        cellAdd = cdLogiciel + 7 + 1;                        
                    }
                    else if (cdModule >= 17 && cdModule <= 32)
                    {
                        cellAdd = cdLogiciel + 7 + 2;
                        module = cdModule - 16;
                    }
                    else if (cdModule >= 33 && cdModule <= 48)
                    {
                        cellAdd = cdLogiciel + 7 + 3;
                        module = cdModule - 32;
                    }
                    else if (cdModule >= 49 && cdModule <= 64)
                    {
                        cellAdd = cdLogiciel + 7 + 4;
                        module = cdModule - 48;
                    }
                    else if (cdModule >= 65 && cdModule <= 80)
                    {
                        cellAdd = cdLogiciel + 7 + 5;
                        module = cdModule - 64;
                    }
                    else if (cdModule >= 81 && cdModule <= 96)
                    {
                        cellAdd = cdLogiciel + 7 + 6;
                        module = cdModule - 80;
                    }
                    else if (cdModule >= 97 && cdModule <= 112)
                    {
                        cellAdd = cdLogiciel + 7 + 7;
                        module = cdModule - 96;
                    }
                    else
                    {
                        cellAdd = 0;
                    }
                    break;
                default:
                    return "";
            }

            if (module > 0)
            {
                //int cellCode = int32.Convert((cellAdd - 7).ToString().PadLeft(2, ' '));
                int cellCode = cellAdd - 7;

                String check = "";
                ExtendedReturnedScalar returnCheck = OracleTrans.getInstance.ExecuterSelectScalar("SELECT VALEUR FROM CELL WHERE CD_CELL = :1", -1, cellCode);
                if (returnCheck.Result != null && returnCheck.Result != DBNull.Value)
                    check = Convert.ToString(returnCheck.Result);

                if (check != "")
                {
                    check = Crypte(check, false);

                    String cdCell, valeur;
                    cdCell = check.Substring(6, 2);
                    valeur = check.Substring(16, 5);

                    try
                    {
                        if (Convert.ToInt32(cdCell) == cellCode)
                        {
                            int retour = Convert.ToInt32(valeur);
                            int reste = 0;
                            for (int i = 1; i <= module; i++)
                            {
                                reste = retour % 2;
                                retour = retour / 2;
                            }

                            return reste.ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception) 
                    {
                        return "";
                    }
                }
                else
                    return "";
            }
            else
                return "";            
        }
        
        #endregion

        /// <summary>
        /// Crypte ou décrypte une chaine de caractère
        /// </summary>
        /// <param name="as_ligne"></param>
        /// <param name="ab_crypte">false: décrypte, true: crypte</param>
        public static string Crypte(String as_ligne, Boolean ab_crypte)
        {
            String ls_cle = "2456752465";

            int li_cle;
            char lc_cle;
            string ls_retour = "";
            int li_indexCalcul;

            for (int i = 0; i < as_ligne.Length; i++)
            {
                li_indexCalcul = i + 1;
                // - Crypte le caracteres
                li_cle = int.Parse(ls_cle[(li_indexCalcul % 9)].ToString());
                if (ab_crypte)
                {
                    if ((li_indexCalcul % 2) == 0) li_cle = -li_cle;
                }
                else
                {
                    if ((li_indexCalcul % 2) == 1) li_cle = -li_cle;
                }

                lc_cle = (char)(((int)as_ligne[i]) + li_cle);
                ls_retour += lc_cle.ToString();
            }


            return ls_retour;            
        }

    }
}
