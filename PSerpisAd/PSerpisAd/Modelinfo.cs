using System;
using System.Reflection;

namespace Serpis.Ad
{
	public class Modelinfo
	{
		private Type type;
		public Modelinfo (Type type)
		{
			this.type = type;
			tableName = type.Name.ToLower();
			
			
			fieldPropertyInfos = new List<PropertyInfo>();
			FieldNames = new List<string>();
			
			foreach (PropertyInfo propertyInfo in type.GetProperties())
				if (propertyInfo.IsDefined(typeof(keyAttribute), true)){
					keyPropertyInfo = propertyInfo;
					KeyName = propertyInfo.Name.ToLower();	
			}else if (propertyInfo.IsDefined (typeof(FieldeAttribute), true)){
				fieldPropertyInfos.Add (propertyInfo);
				fieldNames.Add (propertyInfo.Name.ToLower());
				
			}
		}
		
		private string tableName;
		public string TableName {get {return tableName;}}
		private PropertyInfo keyPropertyInfo;
		public PropertyInfo KeyPropertyInfo {get {return keyPropertyInfo;}}
		private string KeyName;
		public string keyName {get {return KeyName;}}
		
		private List<PropertyInfo> fieldPropertyInfos;
		public PropertyInfo[] FieldPropertyInfo {get {return fieldPropertyInfos.toArray();}}
		
		private List<string> fieldNames;
		public string[] FieldNames {get {return null;}}
		
		
	}
}

