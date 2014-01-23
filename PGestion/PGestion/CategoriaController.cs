using System;

namespace Serpis.Ad
{
	public class CategoriaController
	{
		private Categoria categoria;
		private CategoriaView categoriaView;
		public CategoriaController (Categoria categoria, CategoriaView categoriaView)
		{
			this.categoria = categoria;
			this.categoriaView = categoriaView;
			categoriaView.Nombre = categoria.Nombre;
			
			categoriaView.SaveAction.Activated += delegate{
				saveActionHandler ();
			};
		}
		
		private void saveActionHandler(){
			categoria.Nombre = categoriaView.EntryNombre.Text;
			Categoria.Save(categoria);
			categoriaView.Destroy ();
		}
	}
}

