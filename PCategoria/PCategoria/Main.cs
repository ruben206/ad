using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PCategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			App.Instance.DbConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
			Categoria categoria = Categoria.Load("2");
			categoria.Nombre = DateTime.Now.ToString ();
			Categoria.Save(categoria);
		}
	}
	public class Categoria
	{
//		public int Id {
//			get; 
//			set; 
//		}
//
//		public string Nombre {
//			get;
//			set;
//		}
		private int id;
	
		public int Id {
			get {
				return this.id;
			}
			set {
				id = value;
			}
			
		}
		private string nombre;

		public string Nombre {
			get {
				return this.nombre;
			}
			set {
				nombre = value;
			}
		}
		public static Categoria Load(string id){
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = "select nombre from categoria where id=" + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); 
			
			Categoria categoria = new Categoria();
			categoria.Id = int.Parse (id);
			categoria.Nombre = dataReader["nombre"].ToString();
			
			dataReader.Close ();
			return categoria;
		}
	}
}
