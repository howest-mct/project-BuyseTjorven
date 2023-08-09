﻿using eindopdrachtdesign.Models;
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
    public partial class UpdateColumsPersonPAge : ContentPage
    {
        public Board Myboard { get; set; }
        public Item SelectedItem { get; set; }
        public Column_value SelectedValue { get; set; }
        public UpdateColumsPersonPAge(Board board, Item item, Column_value value)
        {
            Myboard = board;
            SelectedItem = item;
            SelectedValue = value;
            InitializeComponent();
            //method maken die de huidige waarden klaarzet?
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Board board = Myboard;
            Item item = SelectedItem;
            Column_value value = SelectedValue;
            await BookRepository.UpdateITemAsync(item, board.id, value, "");
            Navigation.PopAsync();

        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}