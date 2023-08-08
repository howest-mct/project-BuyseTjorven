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

        private async void btnGoBack_Clicked(object sender, EventArgs e)
        {
            //dit is om eer kaartje aan te maken. Deze code moet hier dus weg en naar de nieuwe pagina...
            ColumnItems columnItems = new ColumnItems() { name="apitest"};
            await BookRepository.AddITemAsync(columnItems,MyBoard.id);
        }

        private void btnUpdateColumn_Clicked(object sender, EventArgs e)
        {
            //de geklikte column de value van kunnen  veranderen ---) je moet wel weten wa het orgineel was om de formatting te kunnen doen.
            //je kan de wel ophalen (zelfde methode als bij selecteren board etc
        }
    }
}