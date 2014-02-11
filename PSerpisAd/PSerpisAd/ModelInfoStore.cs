using System;
using System.Collections.Generic;
namespace Serpis.Ad
{
	public static class ModelInfoStore
	{
		private static Dictionary<Type, Modelinfo> modelInfos = new Dictionary<Type, Modelinfo>();
		public static Modelinfo Get(Type type) {
			if(modelInfos.ContainsKey(type))
				modelInfos[type] = new Modelinfo(type);
				return modelInfos[type];
		}
	}
}

