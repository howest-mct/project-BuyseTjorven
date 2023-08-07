using eindopdrachtdesign.Models;
using eindopdrachtdesign.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindopdrachtdesign.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public Board MyBoard { get; set; }
        public Item selectedItem { get; set; }
        public ItemDetailPage(Models.Item selected, Models.Board Myboard)
        {
            MyBoard = Myboard;
            selectedItem = selected;
            InitializeComponent();
            ShowColumsFromItem();
        }

        private async void ShowColumsFromItem()
        {
            List<Column_value> colums = await BookRepository.GetColumn_ValuesAsync(MyBoard.id, selectedItem.id);
            foreach (Column_value value in colums)
            {
                Console.WriteLine(value.title);
            }
            //lvwTrelloLists.ItemsSource = items;
            lvwCards.ItemsSource = colums;

        }

        private void btnGoBack_Clicked(object sender, EventArgs e)
        {

        }
    }
}