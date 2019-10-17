﻿using Atom.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for BPCCredentialsPage.xaml
    /// </summary>
    public partial class BPCCredentialsPage : BasePage, INotifyPropertyChanged
    {
        public BPCCredentialsPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = await AtomBPCHelper.GetManager(SecretKey);
                this.Navigate(new AtomCredentialsPage());
            }
            catch (AtomException ex)
            {
                ShowError(ex);
            }
        }
    }
}