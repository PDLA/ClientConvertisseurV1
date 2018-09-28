﻿using ClientConvertisseurV1.Controller;
using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        private async void ActionGetData()
        {
            WSService Service = WSService.GetInstance();
            var result = await Service.GetAllDeviseAsync();
            this.CBDevise.DataContext = new List<Devise>(result);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            ConvertisseurController.GetInstance().SelectedDevise = cmb.SelectedItem as Devise;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtConvert_Click(object sender, RoutedEventArgs e)
        {
            double result = ConvertisseurController.GetInstance().Convert().Result;
            TBoResult.Text = result.ToString();
        }

        private void TBoEuro_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtb = sender as TextBox;
            string text = txtb.Text.Replace(',', '.');
            ConvertisseurController.GetInstance().Montant = text;
        }
    }
}
