using Atom.BPC;
using Atom.Core.Extensions;
using Atom.Core.Models;
using Atom.SDK.Core;
using Demo.Helpers;
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
    /// Interaction logic for ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : BasePage
    {
        private string _Log = string.Empty;
        public string Log
        {
            get { return _Log.Trim(); }
            set
            {
                _Log = value;
                NotifyOfPropertyChange(() => Log);
            }
        }

        private AtomBPCManager _BpcManager;

        private List<Package> _Packages;
        public List<Package> Packages
        {
            get { return _Packages; }
            set
            {
                _Packages = value;
                NotifyOfPropertyChange(() => Packages);
            }
        }

        private Package _Package;
        public Package Package
        {
            get { return _Package; }
            set
            {
                _Package = value;
                NotifyOfPropertyChange(() => Package);
            }
        }

        private List<Protocol> _Protocols;
        public List<Protocol> Protocols
        {
            get { return _Protocols; }
            set
            {
                _Protocols = value;
                NotifyOfPropertyChange(() => Protocols);
            }
        }

        private Protocol _Protocol;
        public Protocol Protocol
        {
            get { return _Protocol; }
            set
            {
                _Protocol = value;
                NotifyOfPropertyChange(() => Protocol);
            }
        }

        private List<Country> _Countries;
        public List<Country> Countries
        {
            get { return _Countries; }
            set
            {
                _Countries = value;
                NotifyOfPropertyChange(() => Countries);
            }
        }

        private Country _Country;
        public Country Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }

        public ConnectionPage()
        {
            InitializeComponent();
        }

        private async void InitializeBPC()
        {
            _BpcManager = AtomBPCHelper.GetManager(SecretKey).Result;
            Packages = await _BpcManager.GetPackages();
            Protocols = await _BpcManager.GetProtocols();
            Protocol = Protocols?.FirstOrDefault();
        }

        private void InitializeAtom()
        {
            AtomHelper.Initialize(SecretKey);
            AtomHelper.RegisterConnectedEvent(OnConnected);
            AtomHelper.RegisterDialErrorEvent(OnError);
            AtomHelper.RegisterStateChangedEvent(OnStateChanged);
            AtomHelper.RegisterDisconnectedEvent(onDisconnected);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InitializeBPC();
            InitializeAtom();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AtomHelper.Disconnect();
            if (String.IsNullOrWhiteSpace(UUID))
            {
                AtomHelper.SetCredentials(Username, Password);
            }
            else
            {
                AtomHelper.SetUUID(UUID);
            }
            AtomHelper.Connect(new Atom.SDK.Core.Models.VPNProperties(Country, Protocol));
        }

        private void onDisconnected(object sender, DisconnectedEventArgs e)
        {
            Log += $"{Environment.NewLine}Disconnected";
        }

        private void OnStateChanged(object sender, StateChangedEventArgs e)
        {
            Log += $"{Environment.NewLine}{e.State.ToString()}";
        }

        private void OnError(object sender, DialErrorEventArgs e)
        {
            Log += $"{Environment.NewLine}Error: {e.Message}";
        }

        private void OnConnected(object sender, ConnectedEventArgs e)
        {
            Log += $"{Environment.NewLine}Connected to --> Protocol: {e.ConnectionDetails?.Protocol?.ProtocolSlug} | Country: {e.ConnectionDetails?.Country}";
        }

        private async void comboPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Protocols = await _BpcManager.GetProtocolsByPackage(Package);
            Protocol = Protocols?.FirstOrDefault();
        }

        private async void comboProtocols_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Countries = await _BpcManager.GetCountriesByProtocol(Protocol);
            Countries = await Countries.PingAsync();
            Country = Countries?.FirstOrDefault();
        }

        private void Disconnect_Button_Click(object sender, RoutedEventArgs e)
        {
            AtomHelper.Initialize(SecretKey);
            AtomHelper.Disconnect();
        }
    }
}
