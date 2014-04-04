using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nKnight.RBACD.DataLayer;
using nKnight.RBAC.SecurityLayer;
using System.Data.OleDb;
using System.Data.Odbc;


namespace nKnight
{
    namespace RBAC
    {
        public partial class frmCreateUser : Form
        {
            DataLayer dbl = null;
            RBACD.DatalayerDef.sUser userInfo = new RBACD.DatalayerDef.sUser();
            List<RBACD.DatalayerDef.sUser> userList = null;


            String mode = RBAC.Utils.Constants.SAVE;

            public frmCreateUser(DataLayer pRbacd)
            {
                dbl = pRbacd;
                if ((!SecurityPrincipal.IsRBACInitialized) && (SecurityPrincipal.IsRBACAuthenticated)) { throw new Exception("RBAC system is not activated..."); } // Check if the RBAC systm is initialize or not
                if (pRbacd == null) { throw new Exception("RBAC data layer is not activated"); } //Check RBAC datalayer is valid or not
                InitializeComponent();
                lvwCreateUser.DoubleClick += new EventHandler(lvwCreateUser_DoubleClick);

            }
            private void frmCreateUser_Load(object sender, EventArgs e)
            {
                userList = dbl.GetAllUser();
                lvwCreateUser.Items.Clear();
                foreach (RBACD.DatalayerDef.sUser user in userList)
                {
                    ListViewItem lvwItem = lvwCreateUser.Items.Add(user.UserName);
                    lvwItem.SubItems.Add(user.Password);
                    lvwItem.SubItems.Add(user.FirstName);
                    lvwItem.SubItems.Add(user.LastName);
                    lvwItem.SubItems.Add(user.Citizenship);

                }
                Bitmap bmp = Resources.Blue4;
                this.BackgroundImage = (Image)bmp;
                grpInfo.BackgroundImage = (Image)bmp;
                //grpDetails.BackgroundImage = (Image)bmp;
            }

            private void lvwCreateUser_DoubleClick(object sender, EventArgs e)
            {
                mode = RBAC.Utils.Constants.EDIT;

                if (lvwCreateUser.SelectedIndices.Count > 0)
                {


                    int uIndex = lvwCreateUser.SelectedIndices[0];

                    userInfo = userList[uIndex];
                    txtUserName.Text = userInfo.UserName;
                    txtPassword.Text = userInfo.Password;
                    txtConfPassword.Text = userInfo.Password;
                    txtFirstName.Text = userInfo.FirstName;
                    txtLastName.Text = userInfo.LastName;
                    txtCitizenship.Text = userInfo.Citizenship;
                }
            }


            private void btnSave_Click(object sender, EventArgs e)
            {
                if (txtFirstName.Text.Trim() == "")
                {
                    MessageBox.Show("First name field can not be left blank");
                    txtFirstName.Focus();
                    return;
                }
                if (txtLastName.Text.Trim() == "")
                {
                    MessageBox.Show("Last name field can not be left blank");
                    txtLastName.Focus();
                    return;
                }
                if (txtCitizenship.Text.Trim() == "")
                {
                    MessageBox.Show("Citizenship field can not be left blank");
                    txtCitizenship.Focus();
                    return;
                }
                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("User Id field can not be left blank");
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Password field can not be left blank");
                    txtPassword.Focus();
                    return;
                }
                if (txtConfPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Confirm password field can not be left blank");
                    txtConfPassword.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() != txtConfPassword.Text.Trim())
                {
                    MessageBox.Show("Incorrect password provided....");
                    txtPassword.Focus();
                    return;
                }
                userInfo.UserName = txtUserName.Text.Trim();
                userInfo.Password = txtPassword.Text.Trim();
                userInfo.FirstName = txtFirstName.Text.Trim();
                userInfo.LastName = txtLastName.Text.Trim();
                userInfo.Citizenship = txtCitizenship.Text.Trim();

                if (mode == RBAC.Utils.Constants.SAVE)
                {
                    if (dbl.SaveUser(userInfo))
                    {
                        //MessageBox.Show("Data is saved");
                        ClearFields();

                        frmCreateUser_Load(this, new EventArgs());


                    }
                }
                else if (mode == RBAC.Utils.Constants.EDIT)
                {
                    //MessageBox.Show("Edit");
                    //MessageBox.Show(userInfo.UserId);
                    if (dbl.UpdateUser(userInfo))
                    {

                        ClearFields();
                        frmCreateUser_Load(this, new EventArgs());


                    }
                    mode = RBAC.Utils.Constants.SAVE;
                }

            }

            private void ClearFields()
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtCitizenship.Text = "";
                txtConfPassword.Text = "";
            }

            private void lvwCreateUser_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

            private void lvwCreateUser_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            private void lvwCreateUser_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwCreateUser.Columns[0].Width != 85)
                {
                    lvwCreateUser.Columns[0].Width = 85;
                }
                if (lvwCreateUser.Columns[1].Width != 85)
                {
                    lvwCreateUser.Columns[1].Width = 85;
                }
                if (lvwCreateUser.Columns[2].Width != 130)
                {
                    lvwCreateUser.Columns[2].Width = 130;
                }
                if (lvwCreateUser.Columns[3].Width != 125)
                {
                    lvwCreateUser.Columns[3].Width = 125;
                }
                if (lvwCreateUser.Columns[4].Width != 103)
                {
                    lvwCreateUser.Columns[4].Width = 103;
                }
            }

            private void cmdClear_Click(object sender, EventArgs e)
            {
                ClearFields();
                mode = RBAC.Utils.Constants.SAVE;
                userInfo = new RBACD.DatalayerDef.sUser();
            }
        }
    }
}