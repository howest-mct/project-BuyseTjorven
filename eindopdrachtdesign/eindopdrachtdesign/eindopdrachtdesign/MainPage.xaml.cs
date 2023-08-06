using eindopdrachtdesign.Models;
using eindopdrachtdesign.Repositories;
using eindopdrachtdesign.Views;
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
            Console.WriteLine("mainpageload done!!");
        }

        private async void LoadBooksAsync()
        {
            int i = 0;
            //OpenBookDetail book = await BookRepository.GetBook();
            //Console.WriteLine(book.PublishDate.ToString());
            //Console.WriteLine(book.Publishers[0].ToString());
            Console.WriteLine("LoadAsync");
            List<Boards> boards = new List<Boards>();
            boards = await BookRepository.GetBoards();
            Console.WriteLine("request gedaan");
            //paginatest.ItemsSource = await BookRepository.GetBooks();
        }

        private async void paginatest_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //stap 1 haal geselecteerde board op
            //Work selectedbook = (Work)paginatest.SelectedItem;
            //Bookdetails book = new Bookdetails();
            //OpenBookDetail book = await BookRepository.GetBookk(selectedbook.Key);
            //Console.WriteLine(book.Title);
            //Console.WriteLine(book.Description);
            Console.WriteLine("item_clicked");
            //stap 2 chach of selectboard niet null is
            //if (book != null)
            //{
                 //await Navigation.PushAsync(new Bookdetails(book));
            //}
            //paginatest.SelectedItem = null;
        }
    }
}
