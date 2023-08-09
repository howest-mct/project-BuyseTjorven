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

            lblBoard.Text = "Geef de naam van het nieuwe item in";
            Title = "Item toevoegen aan " + myBoard.name;
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            //opslaan nieuw item.
            string name = editName.Text;
            if(editName.Text != null)
            {
                Item columnitem = new Item();

                columnitem.name = name;

                await BookRepository.AddITemAsync(columnitem, Myboard.id);
                Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Fout", "Geen naam opgegeven", "OK");
            }
        }
    }
}