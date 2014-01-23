using System;

namespace Serpis.Ad
{
	public delegate void CachinDiez();
	public delegate int CachinOnce(string s);
	
	public partial class CategoriaView : Gtk.Window
	{
		private System.Action saveActionDelegate;
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			CachinDiez cachinDiez = m2;
			
//			saveAction.Activated += delegate {
//				
//			};
		}
		
		private void m1(){
			Console.WriteLine(DateTime.Now);
		}
		
		private void m2(){
			Console.WriteLine("Hola desde m2");
		}
		
//		public Entry EntryNombre {
//			get{return entryNombre;}
//		}
		
		public string Nombre {
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;}
		}
//		public Gtk.Action SaveAction{
//			get{return saveAction;}
//		}
//		
	}
}
