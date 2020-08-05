using Libros.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Libros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLibro : ContentPage
    {
        private LibroManager manager;
        private Libro libro;
        public AddLibro(LibroManager manager,Libro libro = null)
        

        {
            InitializeComponent();
            this.libro = libro;
            this.manager = manager;
        }
       
        async public void OnSaveLibro(object sender, EventArgs e) 
        {
            await manager.Add(txtTitulo.Text, txtGenero.Text, txtAutor.Text);
            await DisplayAlert("Alert", "insertado correctamente", "OK");
        }
    }
}