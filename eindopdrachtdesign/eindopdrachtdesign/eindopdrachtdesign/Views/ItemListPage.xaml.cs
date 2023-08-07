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

            List<Column_value> columns = await BookRepository.GetColumn_ValuesAsync("1243926851", MyBoard.id);
            foreach(Column_value column in columns)
            {
                Console.WriteLine(column.title);
            }

        }
    }
}