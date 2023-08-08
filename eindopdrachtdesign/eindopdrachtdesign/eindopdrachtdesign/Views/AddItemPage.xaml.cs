using eindopdrachtdesign.Models;
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
        }
    }
}