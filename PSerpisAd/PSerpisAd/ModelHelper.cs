using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Serpis.Ad
{
	public class ModelHelper
	{
		public static string GetSelect(Type type) {
			string keyName = null;
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
					keyName = propertyInfo.Name.ToLower ();
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldNames.Add (propertyInfo.Name.ToLower());
			}

			string tableName = type.Name.ToLower();

			return string.Format ("select {0} from {1} where {2}=",
			                      string.Join(", ", fieldNames), tableName, keyName);
		}

		public static object Load(Type type, string id) {
			Modelinfo modelInfo = ModelInfoStore.Get(type);
			IDbCommand selecComand = App.Instance.DbConnection.CreateCommand ();
			selecComand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selecComand.ExecuteReader();
			dataReader.Read();
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {	
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true)){
					object value = convert(id, propertyInfo.PropertyType);
					propertyInfo.SetValue(obj, value, null); 
				}
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true)){
					object value = convert(dataReader[propertyInfo.Name.ToLower()]);
					propertyInfo.SetValue(obj, value, null);
				}
			}
			dataReader.Close ();
			return obj;
		}
		private static object Convert (object value, Type type){
			return Convert.changeType (value, type);
		}
		
		private static string formatParameter (string field){
			return string.Format ("{0}=@{0}", field);
		}
		public static string GetUpdate(Type type){
			string keyParameter = null;
			List<string> fieldParameters = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
					keyParameter = formatParameter(propertyInfo.Name.ToLower);
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldParameters.Add (formatParameter(propertyInfo.Name.ToLower()));
			}
			
		}
	}
}