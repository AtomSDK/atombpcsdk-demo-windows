using Atom.SDK.Core;
using Atom.SDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Helpers
{
    /// <summary>
    /// A simple helper class for AtomManager
    /// </summary>
    public static class AtomHelper
    {
        /// <summary>
        /// Instance of AtomManager to be used for VPN connection
        /// </summary>
        private static AtomManager AtomManagerInstance { get; set; }

        /// <summary>
        /// Initializes a singleton of AtomManager
        /// </summary>
        /// <param name="secretKey">Key to be used for Initializing AtomManager instance</param>
        internal static void Initialize(string secretKey)
        {
            AtomManagerInstance = AtomManager.Initialize(secretKey);
        }

        /// <summary>
        /// Connect using AtomManager
        /// </summary>
        /// <param name="properties">Properties to be used for connection</param>
        internal static void Connect(Atom.SDK.Core.Models.VPNProperties properties)
        {
            AtomManagerInstance.Connect(properties);
        }

        /// <summary>
        /// Set Credentials to AtomManager
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        internal static void SetCredentials(string username, string password)
        {
            AtomManagerInstance.Credentials = new Atom.Core.Models.Credentials(username, password);
        }

        /// <summary>
        /// Set Credentials to AtomManager
        /// </summary>
        /// <param name="uuid">UUID</param>
        internal static void SetUUID(string uuid)
        {
            AtomManagerInstance.UUID = uuid;
        }

        /// <summary>
        /// Disconnects the VPN
        /// </summary>
        internal static void Disconnect()
        {
            if (AtomManagerInstance != null && AtomManagerInstance.GetCurrentVPNStatus() == Atom.SDK.Core.Enumerations.VPNStatus.CONNECTED)
            {
                AtomManagerInstance.Disconnect();
            }
        }

        /// <summary>
        /// Registers Connected Event
        /// </summary>
        /// <param name="onConnected">EventHandler for Connected event</param>
        internal static void RegisterConnectedEvent(EventHandler<ConnectedEventArgs> onConnected)
        {
            AtomManagerInstance.Connected += onConnected;
        }

        /// <summary>
        /// Registers Disconnected Event
        /// </summary>
        /// <param name="onConnect">EventHandler for Disconnected event</param>
        internal static void RegisterDisconnectedEvent(EventHandler<DisconnectedEventArgs> onDisconnected)
        {
            AtomManagerInstance.Disconnected += onDisconnected;
        }

        /// <summary>
        /// Registers DialError Event
        /// </summary>
        /// <param name="onConnect">EventHandler for DialError event</param>
        internal static void RegisterDialErrorEvent(EventHandler<DialErrorEventArgs> onDialError)
        {
            AtomManagerInstance.DialError += onDialError;
        }

        /// <summary>
        /// Registers StateChanged Event
        /// </summary>
        /// <param name="onConnect">EventHandler for StateChanged event</param>
        internal static void RegisterStateChangedEvent(EventHandler<StateChangedEventArgs> onStateChanged)
        {
            AtomManagerInstance.StateChanged += onStateChanged;
        }
    }
}
