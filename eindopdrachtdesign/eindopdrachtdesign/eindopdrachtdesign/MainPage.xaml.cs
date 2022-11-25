using eindopdrachtdesign.Models;
using eindopdrachtdesign.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eindopdrachtdesign
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadBooksAsync();
            Console.WriteLine("huh");
        }

        private async void LoadBooksAsync()
        {
            //OpenBookDetail book = await BookRepository.GetBook();
            //Console.WriteLine(book.PublishDate.ToString());
            //Console.WriteLine(book.Publishers[0].ToString());
            Console.WriteLine("ja?");
            paginatest.ItemsSource = await BookRepository.GetBooks();
        }

        private void paginatest_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
