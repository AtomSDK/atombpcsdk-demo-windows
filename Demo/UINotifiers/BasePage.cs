using Atom.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Demo
{
    public class BasePage : Page, INotifyPropertyChanged
    {

        private string _SecretKey = string.Empty;
        private string _UUID = string.Empty;
        private string _Username = string.Empty;
        private string _Password = string.Empty;

        /// <summary>
        /// Atom Secret Key
        /// </summary>
        public string SecretKey
        {
            get { return _SecretKey.Trim(); }
            set
            {
                _SecretKey = value;
                NotifyOfPropertyChange(() => SecretKey);
            }
        }
        /// <summary>
        /// UUID for Atom user authentication
        /// </summary>
        public string UUID
        {
            get { return _UUID.Trim(); }
            set
            {
                _UUID = value;
                NotifyOfPropertyChange(() => UUID);
            }
        }
        /// <summary>
        /// Username for Atom user authentication
        /// </summary>
        public string Username
        {
            get { return _Username.Trim(); }
            set
            {
                _Username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        /// <summary>
        /// Password for Atom user authentication
        /// </summary>
        public string Password
        {
            get { return _Password.Trim(); }
            set
            {
                _Password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="exp">The property expression.</param>
        protected virtual void NotifyOfPropertyChange<T>(Expression<Func<T>> exp)
        {
            try
            {
                string name = ((LambdaExpression)exp).Body.ToString().Split('.').Last();
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            catch { }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        protected virtual void NotifyOfPropertyChange(string name)
        {
            try
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            catch { }
        }

        protected void Navigate(BasePage page)
        {
            page.SecretKey = this.SecretKey;
            page.UUID = this.UUID;
            page.Username = this.Username;
            page.Password = this.Password;
            this.NavigationService.Navigate(page);
        }
        protected void ShowError(AtomException ex)
        {
            ShowError(ex.Message);
        }

        protected void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
