using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nKnight.RBAC.SecurityLayer;
using nKnight.RBACD.DataLayer;

namespace nKnight
{
    namespace RBAC
    {
        public partial class frmCreateSecurityGroups : Form
        {
            DataLayer dbl = null;
            RBACD.DatalayerDef.sSecurityGroups securityGroupInfo = new RBACD.DatalayerDef.sSecurityGroups();
            List<RBACD.DatalayerDef.sSecurityGroups> sgInfo = null;

            String mode = RBAC.Utils.Constants.SAVE;

            public frmCreateSecurityGroups(DataLayer pRbacd)
            {
                dbl = pRbacd;
                if ((!SecurityPrincipal.IsRBACInitialized) && (SecurityPrincipal.IsRBACAuthenticated)) { throw new Exception("RBAC system is not activated..."); } // Check if the RBAC systm is initialize or not
                if (pRbacd == null) { throw new Exception("RBAC data layer is not activated"); } //Check RBAC datalayer is valid or not
                InitializeComponent();
                lvwSecurityGroup.DoubleClick += new EventHandler(lvwSecurityGroup_DoubleClick);
            }

            private void frmCreateSecurityGroups_Load(object sender, EventArgs e)
            {

                sgInfo = dbl.RetrieveSecurityGroup();
                lvwSecurityGroup.Items.Clear();

                foreach (RBACD.DatalayerDef.sSecurityGroups securityGroup in sgInfo)
                {
                    ListViewItem lvwItem = lvwSecurityGroup.Items.Add(securityGroup.Name);
                    lvwItem.SubItems.Add(securityGroup.DisplayName);
                }
                Bitmap bmp = Resources.Blue4;
                this.BackgroundImage = (Image)bmp;
                //grpDetails.BackgroundImage = (Image)bmp;
                //grpInfo.BackgroundImage = (Image)bmp;
            }

            private void lvwSecurityGroup_DoubleClick(object sender, EventArgs e)
            {
                mode = RBAC.Utils.Constants.EDIT;

                if (lvwSecurityGroup.SelectedIndices.Count > 0)
                {

                    int uIndex = lvwSecurityGroup.SelectedIndices[0];

                    securityGroupInfo = sgInfo[uIndex];
                    txtName.Text = securityGroupInfo.Name;
                    txtDisplayName.Text = securityGroupInfo.DisplayName;

                }

            }


            private void btnSave_Click(object sender, EventArgs e)
            {
                if (txtName.Text == "" || txtDisplayName.Text == "")
                {
                    MessageBox.Show("Fill up the form");
                    return;
                }

                securityGroupInfo.Name = txtName.Text;
                securityGroupInfo.DisplayName = txtDisplayName.Text;

                if (mode == RBAC.Utils.Constants.SAVE)
                {
                    if (dbl.SaveSecurityGroups(securityGroupInfo))
                    {
                        //MessageBox.Show("Data is saved");
                        txtName.Text = "";
                        txtDisplayName.Text = "";

                        frmCreateSecurityGroups_Load(this, new EventArgs());

                    }
                }
                else if (mode == RBAC.Utils.Constants.EDIT)
                {

                    if (dbl.UpdateSecurityGroups(securityGroupInfo))
                    {

                        txtName.Text = "";
                        txtDisplayName.Text = "";

                        frmCreateSecurityGroups_Load(this, new EventArgs());

                    }
                    mode = RBAC.Utils.Constants.SAVE;
                }

            }

            private void lvwSecurityGroup_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
            {
                try
                {
                    System.Drawing.Drawing2D.LinearGradientBrush GradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.DarkBlue, Color.LightSkyBlue, 270);

                    e.Graphics.FillRectangle(GradientBrush, e.Bounds);

                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.LightSkyBlue), 2), e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 4, e.Bounds.Height + 5);

                    e.Graphics.DrawString(e.Header.Text, new Font("Tahoma", 9), new SolidBrush(Color.White), e.Bounds);
                }
                catch { }
            }

            private void lvwSecurityGroup_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
                    e.Graphics.DrawString(e.SubItem.Text, new Font("Tahoma", 8), new SolidBrush(Color.Black), e.Bounds);
                }
                else
                {
                    e.DrawBackground();
                    e.DrawText();
                }
            }

            private void lvwSecurityGroup_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwSecurityGroup.Columns[0].Width != 172)
                {
                    lvwSecurityGroup.Columns[0].Width = 172;
                }
                if (lvwSecurityGroup.Columns[1].Width != 175)
                {
                    lvwSecurityGroup.Columns[1].Width = 175;
                }
            }

            private void cmdClear_Click(object sender, EventArgs e)
            {
                txtName.Text = "";
                txtDisplayName.Text = "";
                mode = RBAC.Utils.Constants.SAVE;
                securityGroupInfo = new RBACD.DatalayerDef.sSecurityGroups();
            }
        }
    }
}