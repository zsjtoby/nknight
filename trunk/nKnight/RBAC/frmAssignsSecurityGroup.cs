using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using nKnight.RBAC.SecurityLayer;
using nKnight.RBACD.DataLayer;

namespace nKnight
{
    namespace RBAC
    {
        public partial class frmAssignsSecurityGroup : Form
        {

            DataLayer dbl = null;
            List<User> uInfo = null;
            List<RBACD.DatalayerDef.sSecurityGroups> sgInfo = null;
            RBACD.DatalayerDef.sSecurityGroupAssigns usrScuGruAgnInfo = new RBACD.DatalayerDef.sSecurityGroupAssigns();
            List<String> sgId = new List<string>();

            //ListViewItem lvwItem = null;

            public frmAssignsSecurityGroup(DataLayer pRbacd)
            {
                dbl = pRbacd;
                if ((!SecurityPrincipal.IsRBACInitialized) && (SecurityPrincipal.IsRBACAuthenticated)) { throw new Exception("RBAC system is not activated..."); } // Check if the RBAC systm is initialize or not
                if (pRbacd == null) { throw new Exception("RBAC data layer is not activated"); } //Check RBAC datalayer is valid or not
                uInfo = dbl.RetrieveUsers();
                sgInfo = dbl.RetrieveSecurityGroup();
                if ((uInfo == null) || (uInfo.Count == 0)) { throw new Exception("User data is not ready"); }
                if ((sgInfo == null) || (sgInfo.Count == 0)) { throw new Exception("Security Group data is not ready"); }

                InitializeComponent();
                Bitmap bmp = Resources.Blue4;
                this.BackgroundImage = (Image)bmp;
                //grpAssign.BackgroundImage = (Image)bmp;
            }

            private void frmAssignsSecurityGroup_Load(object sender, EventArgs e)
            {
                foreach (User user in uInfo)
                {
                    ListViewItem lvwItem = lvwUser.Items.Add(user.UserName);
                    lvwItem.SubItems.Add(user.UserId);

                }

                foreach (RBACD.DatalayerDef.sSecurityGroups securityGrp in sgInfo)
                {
                    ListViewItem lvwItem = lvwSecurityGroup.Items.Add(securityGrp.Name);
                    lvwItem.SubItems.Add(securityGrp.SecurityGroupID);

                }
            }

            private void lvwUser_Click(object sender, EventArgs e)
            {
                lblMessage.Text = "";
                //unselect all items in security group
                foreach (ListViewItem lvi in lvwSecurityGroup.Items)
                {
                    lvi.Selected = false;
                }
                if (lvwUser.SelectedIndices.Count > 0)
                {
                    //String uId = lvwUser.Items[lvwUser.SelectedIndices[0]].SubItems[1].Text;
                    int uIndex = lvwUser.SelectedIndices[0];

                    User u = uInfo[uIndex];
                    //MessageBox.Show(uId);
                    usrScuGruAgnInfo.UserId = u.UserId;
                }

                usrScuGruAgnInfo = dbl.RetrieveAssingedSecurityGroup(usrScuGruAgnInfo);

                foreach (String sgId in usrScuGruAgnInfo.SecurityGroupId)
                {
                    foreach (ListViewItem lvi in lvwSecurityGroup.Items)
                    {
                        if (lvi.SubItems[1].Text == sgId)
                        {

                            lvi.Selected = true;
                            lvwSecurityGroup.Select();
                        }
                    }
                }
            }

            private void btnSave_Click(object sender, EventArgs e)
            {

                if (lvwSecurityGroup.SelectedIndices.Count > 0)
                {

                    foreach (int i in lvwSecurityGroup.SelectedIndices)
                    {
                        RBACD.DatalayerDef.sSecurityGroups sg = sgInfo[i];
                        //MessageBox.Show(sg.Name);
                        sgId.Add(sg.SecurityGroupID);

                    }
                    usrScuGruAgnInfo.SecurityGroupId = sgId;

                }



                if (dbl.SaveSecurityGroupsAssings(usrScuGruAgnInfo))
                {
                    lblMessage.Text = "Data saved successfully";
                    //MessageBox.Show("Data is saved");
                }
                else
                {
                    lblMessage.Text = "Error while saving the details";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

            private void lvwUser_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

            private void lvwUser_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            private void lvwUser_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwUser.Columns[0].Width != 175)
                {
                    lvwUser.Columns[0].Width = 175;
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
                if (lvwSecurityGroup.Columns[0].Width != 180)
                {
                    lvwSecurityGroup.Columns[0].Width = 180;
                }
            }
        }
    }
}