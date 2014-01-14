using System;

namespace PGestion
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView (string id) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			IDbComand selectDbCommand = AppDomain.Instance.DbConnection.CreateComand ();
			selectDbCommand.CommandText = "select nombre from categoria";
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read();
			entryNombre.Text = dataReader["Nombre"].ToString();
			dataReader.Close ();
			saveAction.Activated += delegate{
				IDbCommand updateCommand = App.Instance.DbConnection.CreateCommand ();
				updateDbCommand.CommandText = "updatecategoria set nombre=@nombre where id=" + id;
//				IdbDataParameter nombreDbDataParameter = updateDbCommand.CreateParameter ();
//				nombreDbDataParameter.ParameterName = "nombre";
//				nombreDbDataParamater.Value = entryNombre.Text;
//				updateDbCommand.Parameters.Add(nombreDbDataParameter);
				DbCommandUtil.AddParameter (updateDbCommand, "nombre", entryNombre.Text);
				updateDbCommand.ExecuteNonQuery ();
				
				Destroy ();
			};
		}
	}
}
