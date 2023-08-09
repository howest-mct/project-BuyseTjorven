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
    public partial class UpdateColumnsPage : ContentPage
    {
        public Board Myboard { get; set; }
        public Item SelectedItem { get; set; }
        public Column_value SelectedValue { get; set; }
        public UpdateColumnsPage(Board board, Item item, Column_value value)
        {
            Myboard = board;
            SelectedItem = item;
            SelectedValue = value;
            InitializeComponent();
            Title = "datum aanpassen";
            //method maken die de huidige waarden klaarzet?
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Board board = Myboard;
            Item item = SelectedItem;
            Column_value value = SelectedValue;
            string date = editName.Text;
            DateTime dt;
            DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dt);

            if (dt == DateTime.MinValue) {
                //error weergeven
                lblBoard.Text = "Ongeldige datum ingegeven";
            }
            else
            {
                await BookRepository.UpdateITemAsync(item, board.id, value, date);
                Navigation.PopAsync();
            }

        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}