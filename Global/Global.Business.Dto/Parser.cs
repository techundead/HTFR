using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using System.Reflection;


namespace Global.Business.Dto
{
    public class Parser<T> where T : IEntity, new()
    {
        protected Dictionary<int, Action<T, IDataReader, int>> _setters = new Dictionary<int, Action<T, IDataReader, int>>();

        public class DefinitionPropriete
        {
            //public PropertyInfo ProprieteReflection { get; set; }
            //public Type TypeObjet { get; set; }
            public String Nom { get; set; }
            public Type Type { get; set; }
            public TypeCode TypeCode { get; set; }
            public String NomBase { get; set; }
            public int IndexDataReader { get; set; }
                        
        }

        //public abstract void GetIndexes(OracleDataReader dr);        
        //public abstract T Parse(OracleDataReader dr); 

        protected List<DefinitionPropriete> ListeProprietes = new List<DefinitionPropriete>();

        public virtual T Parse(IDataReader dr)
        {
            T o = new T();

            //foreach (DefinitionPropriete p in ListeProprietes)
            //{
            //    // METHODE 2
            //    ////PropertyInfo pReflection = typeof(Heure).GetProperty(p.Nom);
            //    //PropertyInfo pReflection = p.ProprieteReflection; //p.ProprieteReflection;

            //    //object value = null;
            //    //////value = p.IndexDataReader > -1 ? dr[p.IndexDataReader] : null;
            //    //value = p.IndexDataReader > -1 ? dr.GetValue(p.IndexDataReader) : null;

            //    //if (value != null && value != DBNull.Value)
            //    //    pReflection.SetValue(h, Convert.ChangeType(value, p.Type), null);
            //}

            // METHODE 1
            foreach (KeyValuePair<int, Action<T, IDataReader, int>> action in _setters)
            {
                action.Value(o, dr, action.Key);
            }

            return o;
        }

        public virtual void GetIndexes(IDataReader dr)
        {
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                DefinitionPropriete d = new DefinitionPropriete()
                {
                    //ProprieteReflection = p,
                    //TypeObjet = typeof(T),
                    Nom = p.Name,
                    NomBase = typeof(T).GetDbNameAttribute(p.Name),
                    Type = p.PropertyType,
                    TypeCode = Type.GetTypeCode(p.PropertyType),
                    IndexDataReader = dr.GetPropertyIndex(typeof(T), p.Name)
                };

                if (d.IndexDataReader > -1)
                    _setters.Add(d.IndexDataReader, CreateSetter(d));

                ListeProprietes.Add(d);
            }

        }

        protected virtual Action<T, IDataReader, int> CreateSetter(DefinitionPropriete d)
        {
            Type targetType = typeof(T);
            //Type targetType = d.TypeObjet;
            var targetinstance = Expression.Parameter(targetType, "targetinstance");

            ParameterExpression dataReader = Expression.Parameter(typeof(IDataReader), "dataReader");
            ParameterExpression indexDataReader = Expression.Parameter(typeof(int), "indexDataReader");

            MethodInfo methodeGet = null;

            // DataReader.MyGetXXXX: Récupération de la méthode d'extension 
            switch (d.TypeCode)
            {
                case TypeCode.Boolean: break;
                case TypeCode.Byte: break;
                case TypeCode.Char: break;
                case TypeCode.DBNull: break;
                case TypeCode.Empty: break;
                case TypeCode.Object: break;
                case TypeCode.SByte: break;
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64: break;


                case TypeCode.DateTime:
                    methodeGet = typeof(IDataReaderExtensionMethods).GetMethod("MyGetDateTime", BindingFlags.Public | BindingFlags.Static);
                    break;

                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double:
                    methodeGet = typeof(IDataReaderExtensionMethods).GetMethod("MyGetDecimal", BindingFlags.Public | BindingFlags.Static);
                    break;

                case TypeCode.Int16:
                case TypeCode.Int32:
                    methodeGet = typeof(IDataReaderExtensionMethods).GetMethod("MyGetInt32", BindingFlags.Public | BindingFlags.Static);
                    break;

                case TypeCode.Int64:
                    methodeGet = typeof(IDataReaderExtensionMethods).GetMethod("MyGetInt64", BindingFlags.Public | BindingFlags.Static);
                    break;

                case TypeCode.String:
                    methodeGet = typeof(IDataReaderExtensionMethods).GetMethod("MyGetString", BindingFlags.Public | BindingFlags.Static);
                    break;

                default:
                    break;
            }

            if (methodeGet == null)
                throw new Exception("Aucune méthode de type GetValue disponible pour la propriété " + d.Nom + " (" + d.NomBase + ", " + d.Type.ToString() + ")");

            // DataReader.MyGetXXXX(i): Définition de l'appel à la méthode 
            Expression getValue = Expression.Call(null, methodeGet, dataReader, indexDataReader);
            // object.TOTO : Définition de l'accès à la propriété de l'objet métier
            Expression propriete = Expression.Property(targetinstance, d.Nom);
            // object.TOTO = DataReader.MyGetXXXX(i): Assignation
            Expression assignation = Expression.Assign(propriete, getValue);
            
            
            var LambdaExpression = Expression.Lambda(typeof(Action<T, IDataReader, int>),
                                    assignation,
                                    targetinstance,
                                    dataReader,
                                    indexDataReader);

            return (Action<T, IDataReader, int>)LambdaExpression.Compile();


            /////////////////////////////////////////////////////////////////////////
            // AUTRE EXPRESSIONS
            //Expression.IfThen(NullCheckExpression, AssignExpression),
            //TypeBinaryExpression DBNullExpression = Expression.TypeIs(value, typeof(DBNull));
            //NullCheckExpression = Expression.IsFalse(Expression.Property(UnboxedSourceExpression, SourceType, "IsNull"));
            //NullCheckExpression = Expression.IsTrue(Expression.Property(UnboxedSourceExpression, SourceType, "HasValue"));
            //NullCheckExpression = Expression.IsFalse(DBNullExpression);

            // Assign the property value to property through a member binding
            //List<MemberBinding> bindings = new List<MemberBinding>();
            //MemberBinding binding = Expression.Bind(property, propertyValue);
            //bindings.Add(binding);

            // Create the initializer, which instantiates an instance of T and sets property values
            // using the member bindings we just created
            //Expression initializer = Expression.MemberInit(Expression.New(typeof(T)), bindings);

            // Create the lambda expression, which represents the complete delegate (r => initializer)
            //Expression<Func<IDataRecord, T>> lambda = Expression.Lambda<Func<IDataRecord, T>>(initializer, r);
            /////////////////////////////////////////////////////////////////////////

        }


    }


}
