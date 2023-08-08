using eindopdrachtdesign.Models;
using eindopdrachtdesign.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindopdrachtdesign.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemListPage : ContentPage
    {
        public Board MyBoard { get; set; }
        public ItemListPage(Models.Board selected)
        {
            InitializeComponent();
            MyBoard = selected;
            ShowItemsFromBoard();
        }
        private async void ShowItemsFromBoard()
        {
            List<Item> items = await BookRepository.GetItemsAsync(MyBoard.id);
            foreach (Item item in items)
            {
                Console.WriteLine(item.name);
            }
            lvwTrelloLists.ItemsSource = items;

        }

        private void lvwTrelloLists_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwTrelloLists.SelectedItem != null)
            {
                Item selected = (Item)lvwTrelloLists.SelectedItem;
                Console.WriteLine("myboard id test");
                Console.WriteLine(MyBoard.id);
                Navigation.PushAsync(new ItemDetailPage(selected,MyBoard));
                //Deselecteren
                lvwTrelloLists.SelectedItem = null;
            }
        }

        private void btnGoBack_Clicked(object sender, EventArgs e)
        {

        }

        private void lvwTrelloLists_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}