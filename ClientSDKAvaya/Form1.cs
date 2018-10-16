using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avaya.ClientServices;
using ClientSDKAvaya;

namespace ClientSDKAvaya
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureSDK();

        }

        public void ConfigureSDK()
        {
            ClientConfiguration clientConfiguration = new ClientConfiguration("C:Avaya\avayaclientservices.txt", "TestApplication", "Avaya", "Windows", "1.0", "1", "Avaya");
            string userAgentInstanceId;

            userAgentInstanceId = Guid.NewGuid().ToString();
            clientConfiguration.UserAgentInstanceId = userAgentInstanceId;

            ApplicationClientDelegate clientDelegate = new ApplicationClientDelegate();
            Client client = new Client(configuration: clientConfiguration);
            client.UserCreated += new EventHandler<UserEventArgs>
                (clientDelegate.client_UserCreated);
            client.UserRemoved += new EventHandler<UserEventArgs>
                (clientDelegate.client_UserRemoved);
            client.ShutdownCompleted += new EventHandler
                (clientDelegate.client_ShutdownCompleted);
            UserConfiguration userConfiguration = new UserConfiguration();
            SipUserConfiguration sipConfiguration = userConfiguration.SipUserConfiguration;
            sipConfiguration.Enabled = true;
            sipConfiguration.UserId = "garcia76@avaya.com";   // Provided by your administrator
            sipConfiguration.Domain = "net.avaya.com"; // Provideds by your administrator
            SignalingServer signalingServer = new SignalingServer(Avaya.ClientServices.TransportType.Automatic ,
    "sip-na1.avaya.com", // Provided by your administrator 
    5061,         // Provided by your administrator 
    Avaya.ClientServices.FailbackPolicy.Automatic);                // Allow the Client SDK to manage failback
            sipConfiguration.ConnectionPolicy = new ConnectionPolicy(signalingServer);
            sipConfiguration.CredentialProvider = this;
            userConfiguration.SipUserConfiguration = sipConfiguration;

        }
    }
}
