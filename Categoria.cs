using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
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
		public static void Save(Categoria categoria){
				IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand ();
				updateDbCommand.CommandText = "update categoria set nombre=@nombre where id=" + id;
				DbCommandUtil.AddParameter (updateDbCommand, "nombre", entryNombre.Text);
				updateDbCommand.ExecuteNonQuery ();
		}
	}
}

