using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eindopdrachtdesign.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindopdrachtdesign.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bookdetails : ContentPage
    {
        public Bookdetails(OpenBookDetail book)
        {
            this.BindingContext = book;
            this.Title = book.Title;
            InitializeComponent();
        }
    }
}