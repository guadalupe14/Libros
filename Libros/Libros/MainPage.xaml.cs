using Libros.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Libros
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IList<Libro> libros = new ObservableCollection<Libro>();
        private LibroManager manager = new LibroManager();

        public MainPage()
        {
            BindingContext = libros;
            InitializeComponent();
        }
        async public void OnRefresh(object sender, EventArgs e)
        {
            var librosCollection = await manager.GetAll();
            foreach(Libro libro in librosCollection)
            {
                if (libros.All(t => t.Id != libro.Id ))
                {
                    libros.Add(libro);
                }
            }
        }

        async public void OnAddLibro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLibro(manager));

        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }




    }
}



