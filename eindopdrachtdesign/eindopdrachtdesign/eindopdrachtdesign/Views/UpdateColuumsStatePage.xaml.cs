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
        }

        private void btnCancel_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnSave_Clicked_1(object sender, EventArgs e)
        {
            
            Board board = Myboard;
            Item item = SelectedItem;
            Column_value value = SelectedValue;
            await BookRepository.UpdateITemAsync(item, board.id, value, "Ermee bezig");
            Navigation.PopAsync();
        }
    }
}