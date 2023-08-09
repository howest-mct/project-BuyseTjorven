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
using Xamarin.Essentials;

namespace eindopdrachtdesign
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Console.WriteLine("mainpageload done!!");
            //Console.WriteLine(Connectivity.NetworkAccess);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Connectivity.NetworkAccess.ToString() == "Internet")
            {
                LoadBoardsAsync();
            }
            else
            {
                Navigation.PushAsync(new NoNetworkPage());
            }
        }
        private async void LoadBoardsAsync()
        {
            int i = 0;
            Console.WriteLine("LoadAsync");
            GraphQlBoardsResponse boards;
            boards = await BookRepository.GetBoards();
            foreach(Board board in boards.data.boards)
            {
                Console.WriteLine(board.name);
                Console.WriteLine(board.id);
            }
            lvwBoards.ItemsSource = boards.data.boards;


        }


        private void lvwBoards_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwBoards.SelectedItem != null)
            {
                Board selected = (Board)lvwBoards.SelectedItem;
                Navigation.PushAsync(new ItemListPage(selected));
                //Deselecteren
                lvwBoards.SelectedItem = null;
            }
        }
    }

}
