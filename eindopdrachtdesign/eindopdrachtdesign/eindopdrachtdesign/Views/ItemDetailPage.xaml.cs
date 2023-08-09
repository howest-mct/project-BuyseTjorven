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
            //ShowColumsFromItem();
            lblListName.Text = selected.name;
        }
        //standaardmethode die wij aanpassen zodat data word geupdate na popasync
        protected override void OnAppearing()
        {
            base.OnAppearing();
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
            //dit is om eer kaartje aan te maken. Deze code moet hier dus weg en naar de nieuwe pagina...
            //ColumnItems columnItems = new ColumnItems() { name="apitest"};
            //await BookRepository.AddITemAsync(columnItems,MyBoard.id);

            //de juiste code
            Navigation.PopAsync();
        }

        private async void btnUpdateColumn_Clicked(object sender, EventArgs e)
        {
            Column_value value = (sender as Button).BindingContext as Column_value;
            switch (value.id)
            {
                case "person":
                    await Navigation.PushAsync(new UpdateColumsPersonPAge(MyBoard, selectedItem, value));
                    break;
                case "date":
                    await Navigation.PushAsync(new UpdateColumnsPage(MyBoard, selectedItem, value));
                    break;
                case "status":
                    await Navigation.PushAsync(new UpdateColuumsStatePage(MyBoard, selectedItem, value));
                    break;
            }
        }
    }
}