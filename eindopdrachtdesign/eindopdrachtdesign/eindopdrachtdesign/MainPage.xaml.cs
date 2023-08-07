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
            LoadBoardsAsync();
            Console.WriteLine("mainpageload done!!");
        }

        private async void LoadBoardsAsync()
        {
            int i = 0;
            Console.WriteLine("LoadAsync");
            GraphQlBoardsResponse boards;
            boards = await BookRepository.GetBoards();
            foreach(Board board in boards.data.board)
            {
                Console.WriteLine(board.name);
                Console.WriteLine(board.id);
            }
            lvwBoards.ItemsSource = boards.data.board;
            
            Board test = boards.data.board[0];
            List<Item> items = await BookRepository.GetItemsAsync(test.id);
            foreach(Item item in items)
            {
                Console.WriteLine(item.name);
            }
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
