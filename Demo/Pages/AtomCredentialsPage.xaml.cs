using System;
using System.Collections.Generic;
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
    /// Interaction logic for AtomCredentialsPage.xaml
    /// </summary>
    public partial class AtomCredentialsPage : BasePage
    {
        public AtomCredentialsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UUID) && (String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password)))
            {
                ShowError("Either provide UUID or Username & Password.");
            }
            else
            {
                this.Navigate(new ConnectionPage());
            }
        }
    }
}