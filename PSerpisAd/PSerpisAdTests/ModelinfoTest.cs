using System;
using NUnit.Framework;
using System.Reflection;

namespace Serpis.Ad
{
	internal class ModelinfoFoo {
		[Key]
		public int Id {get;set;}
		[Field]
		public string Nombre {get;set;}
	}
	
	internal class ModelinfoBar {
		[Key]
		public int Id {get;set;}
		[Field]
		public string Nombre {get;set;}
		[Field]
		public decimal precio {get;set;}
	}
	
	[TestFixture()]
	public class ModelinfoTest
	{
		[Test()]
		public void TableName ()
		{
			Modelinfo modelinfo = new Modelinfo(typeof(MdelinfoFoo));
			Assert.AreEqual("modelinfofoo",modelinfo.TableName);
		}
		
		[Test]
		public void keyPropertyInfo(){
			Modelinfo modelinfo = new Modelinfo(typeof(MdelinfoFoo));
			Assert.IsNotNull(modelinfo.keyPropertyInfo);
			Assert.AreEqual("Id", modelinfo.keyPropertyInfo.Name);
		}
		[Test]
		public void KeyName(){
			Modelinfo modelinfo = new Modelinfo(typeof(MdelinfoFoo));
			Assert.AreEqual("Id", modelinfo.KeyName);
		}
		[Test]
		public void FieldPropertyInfos(){
			Modelinfo modelinfo = new Modelinfo(typeof(MdelinfoFoo));
			PropertyInfo[] fieldPropertyInfos = modelinfo.FieldPropertyInfos;
			Assert.AreEqual(1, fieldPropertyInfos.Length);
			
			modelinfo = new Modelinfo(typeof(ModelinfoBar));
			fieldPropertyInfos = modelinfo.FieldPropertyInfos;
			Assert.AreEqual(1, fieldPropertyInfos.Length);
		}
		
		[Test]
		public vois FieldNames(){
			Modelinfo modelinfo = ModelInfoStore.Get(typeof(ModelinfoFoo));
			string[] fieldNames = modelinfo.FieldNames;
			Assert.AreEqual(1, fieldNames.Length);
			Assert.Contains("Nombre", fieldNames);
			
			Modelinfo = ModelInfoStore.Get(typeof(ModelinfoBar));
		}
	}
}

