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
            //de geklikte column de value van kunnen  veranderen ---) je moet wel weten wa het orgineel was om de formatting te kunnen doen.
            Board board = MyBoard;
            Item item = selectedItem;
            ColumnItems columnitem = new ColumnItems();
            columnitem.id = item.id;
            if(lvwCards.SelectedItem != null)//probleem als ze op update klikken niet perse dit geselecteerd? wss iets met groupen fzo
            {
                Column_value value = (Column_value)lvwCards.SelectedItem;
                Console.WriteLine(value.text);
                //Navigation.PushAsync(new ItemListPage(selected));  //iets da er ongeveer zo uitziet xD //pagina moet nog gemaakt worden //op andere pagina moeten deze dingen + de nieuw ingestelde waarde dan worden verstuurd naar functie.
                await BookRepository.UpdateITemAsync(columnitem, MyBoard.id, value, "2024-05-15");
                lvwCards.SelectedItem = null;
            }
        }
    }
}