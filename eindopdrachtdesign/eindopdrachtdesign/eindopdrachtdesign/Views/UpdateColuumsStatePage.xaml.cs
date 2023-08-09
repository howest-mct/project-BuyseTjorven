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
    public partial class UpdateColuumsStatePage : ContentPage
    {
        public Board Myboard { get; set; }
        public Item SelectedItem { get; set; }
        public Column_value SelectedValue { get; set; }
        public UpdateColuumsStatePage(Board board, Item item, Column_value value)
        {
            Myboard = board;
            SelectedItem = item;
            SelectedValue = value;
            InitializeComponent();
            //method maken die de huidige waarden klaarzet?
            Title = "Status aanpassen";
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            
            Board board = Myboard;
            Item item = SelectedItem;
            Column_value value = SelectedValue;
            //Console.WriteLine(state);
            if (namefrompicker.SelectedItem != null)
            {
                string state = namefrompicker.SelectedItem.ToString();
                await BookRepository.UpdateITemAsync(item, board.id, value, state);
                Navigation.PopAsync();
            }
            else
            {
                //lblBoard.Text = "Geen status ingegeven";
                await DisplayAlert("Fout", "Geen status geselecteerd", "OK");
            }
        }
    }
}