using System;

namespace Serpis.Ad
{
	public class CategoriaController
	{
		public CategoriaController (Categoria categoria, CategoriaView categoriaView)
		{
			categoriaView.EntryNombre.Text = categoria.Nombre;
			
			categoriaView.SaveAction.Activated += delegate{
				categoria.Nombre = categoriaView.EntryNombre.Text;
				Categoria.Save(categoria);
				categoriaView.Destroy ();
			};
		}
	}
}

