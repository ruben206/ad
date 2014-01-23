using System;

namespace Serpis.Ad
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			saveAction.Activated += delegate {
				
			};
		}
		public string Nombre {
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;}
		}
		public Gtk.Action SaveAction{
			get{return saveAction;}
		}
		
	}
}
