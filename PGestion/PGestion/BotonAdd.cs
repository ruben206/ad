using System;
using Gtk;
using System.Data;

namespace PGestion
{
	public partial class BotonAdd : Gtk.Window
	{
		public BotonAdd () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			botonAceptar.Clicked+=delegate{
				IDbCommand.DbCommand = AppDomain.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = String.Format("");
			};
		}
	}
}

