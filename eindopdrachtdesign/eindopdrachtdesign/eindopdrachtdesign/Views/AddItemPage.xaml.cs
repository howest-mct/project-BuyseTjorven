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
    public partial class AddItemPage : ContentPage
    {
        public Board Myboard  { get; set; }
        public AddItemPage(Models.Board myBoard)
        {
            InitializeComponent();
            Myboard = myBoard;

            lblBoard.Text = myBoard.name;
            Title = "Add a new item";
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            //opslaan nieuw item.
            string name = editName.Text;
            ColumnItems columnitem = new ColumnItems();

            columnitem.name = name;

            await BookRepository.AddITemAsync(columnitem, Myboard.id);
            Navigation.PopAsync();
        }
    }
}