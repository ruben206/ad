using System;

namespace Serpis.Ad
{
	public class ModelHelper
	{
		public static string GetSelect(Type type){
			string keyName;
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties ()){
				if (propertyInfo.IsDefined (typeof(keyAttribute), true))
					keyName = propertyInfo.Name;
				else if(propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldNames.Add (propertyInfo.Name);
				
				
			}
			string tableName = type.Name.ToLower();
			return string.Format ("select{0} from {1} where {2} = ",
			                      string.Join(", ", fieldNames),
			                      tableName, keyName);
		}
		public static object Load(Type type, string id){
			object obj = Activator.CreateInstance(type);
			PropertyInfo propertyInfo = type.GetProperty("Nombre");
			propertyInfo.SetValue(obj, "El nombre que yo quiera", null);
			return obj;
		}
		public static void Save(object obj){
			
		}
	}
}

