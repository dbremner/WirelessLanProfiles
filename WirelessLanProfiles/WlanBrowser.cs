//Samples written by Chris Lewis

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WlanNative;

namespace WirelessLanProfiles
{
    public partial class WlanBrowser : Form
    {
        public WlanBrowser( )
        {
            InitializeComponent( );
            cbInterfaces.DisplayMember = "Description";
            cbProfiles.DisplayMember = "ProfileName";
            cbNetworks.DisplayMember = "SSID";

        }

        #region Non Event Code
        WlanNative.WlanNative native = null;

        void HideTabs( )
        {
            if (tabControl.Visible) tabControl.Visible = false;
        }

        void ShowTabs( )
        {
            if (!tabControl.Visible) tabControl.Visible = true;
        }

        void RefreshInterfaces( )
        {
            try
            {
                if (native == null)
                {
                    native = new WlanNative.WlanNative( );
                }
                cbInterfaces.DataSource = native.GetInterfaces( );
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }

        void RefreshProfiles( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    cbProfiles.DataSource = i.GetProfiles( );
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }

        void ConnectTempProfile( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    i.Connect(tbTmpProfile.Text);
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void SetEAPProfile( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
                    if(p != null)
                    {
                        string xmlText = tbEAPXML.Text;
                        if (string.IsNullOrEmpty(xmlText)) return;
                        i.SetProfileEAPXmlUserData(p.ProfileName, xmlText, true);
                    }
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void EditProfile( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
                    if(p != null)
                    {
                        i.ShowEditProfileDialog(p, Handle);
                    }
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void ConnectProfile( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
                    if (p != null)
                    {
                        i.Connect(p);
                    }
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void Disconnect()
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    i.Disconnect( );
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }

        void SetProfile()
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
                    if (p != null)
                    {
                        string xml = tbProfileXML.Text;
                        if(!string.IsNullOrWhiteSpace(xml))
                        {
                            i.SetProfile(p, xml);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }

        void ResetProfile()
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
                    if (p != null)
                    {
                        tbProfileXML.Text = i.GetProfile(p);
                    }
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }
        void UIError(Exception ex)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(( ) => UIError(ex)));
            }
            else MessageBox.Show(string.Format("Unexpected error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void RefreshNetworks()
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    cbNetworks.DataSource = i.GetAvailableNetworks(true, true);
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void ShowNetwork()
        {
            try
            {
                WlanNetwork n = cbNetworks.SelectedItem as WlanNetwork;
                if (n != null)
                {
                    pgNetwork.SelectedObject = n;   
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }


        void Rescan( )
        {
            try
            {
                WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
                if (i != null)
                {
                    i.ScanForNetworks( );
                }
            }
            catch (Exception ex)
            {
                UIError(ex);
            }
        }

        void NotifyMe()
        {
            try
            {
                native.NotificationReceived += NotificationCallback;
                native.RegisterForAllNotifications(true);
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }
        void DontNotifyMe()
        {
            try
            {
                native.NotificationReceived -= NotificationCallback;
                native.UnregisterForNotifications( );
            }
            catch (Exception ex)
            {
                UIError(ex);
            }

        }

        void NotificationCallback(ValueType rawNetInterface, String source, int code, int size, IntPtr buffer)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(( ) => NotificationCallback(rawNetInterface, source, code, size, buffer)));
            }
            else
            {
                try
                {
                    Guid netInterface = (Guid)rawNetInterface;
                    StringBuilder message = new StringBuilder( );
                    message.Append("Notification received from ");
                    message.Append(source);
                    message.Append(" on interface \"");
                    List<WlanInterface> interfaces = cbInterfaces.DataSource as List<WlanInterface>;
                    if (interfaces == null)
                    {
                        message.Append(rawNetInterface.ToString( ));
                    }
                    else
                    {
                        WlanInterface iface = interfaces.FirstOrDefault((x) => ((Guid)x.InterfaceGuid).Equals(rawNetInterface));
                        if (iface != null)
                        {
                            message.Append(iface.Description);
                        }
                        else
                        {
                            message.Append(rawNetInterface.ToString( ));
                        }
                    }
                    message.Append("\" with code ");
                    message.Append(code);
                    message.Append(" and ");
                    message.Append(size);
                    message.Append(" bytes at ");
                    message.AppendFormat("0x{0:x}", buffer.ToInt64( ));
                    message.Append(".");
                    MessageBox.Show(message.ToString( ), "WLAN Change Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch(Exception ex)
                {
                    UIError(ex);
                }
            }
        }
        #endregion
        private void splitContainer6_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            WlanInterface i = cbInterfaces.SelectedItem as WlanInterface;
            if (i != null)
            {
                ShowTabs( );
                pgState.SelectedObject = i;
                pgProf.SelectedObject = null;
                cbProfiles.DataSource = null;
                RefreshProfiles( );
            }
            else HideTabs( );
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshInterfaces( );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectTempProfile( );
        }

        private void btnProfilesRefresh_Click(object sender, EventArgs e)
        {
            RefreshProfiles( );
        }

        private void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            WlanProfile p = cbProfiles.SelectedItem as WlanProfile;
            if(p != null)
            {
                pgProf.SelectedObject = p;
                ResetProfile( );
            }
        }

        private void btnSetEAP_Click(object sender, EventArgs e)
        {
            SetEAPProfile( );
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProfile( );
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProfile( );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetEAPProfile( );
        }

        private void btnSetProfile_Click(object sender, EventArgs e)
        {
            SetProfile( );
        }

        private void btnResetProfile_Click(object sender, EventArgs e)
        {
            ResetProfile( );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshNetworks( );
        }

        private void cbNetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNetwork( );
        }

        private void tbEAPXML_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectProfile( );
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect( );
        }

        private void cbNotifyChanges_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNotifyChanges.Checked)
            {
                //Accept change notifications
                NotifyMe( );
            }
            else
            {
                //Dont accept change notifications
                DontNotifyMe( );
            }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            Rescan( );
        }
    }
}
