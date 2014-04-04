using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using nKnight.RBACD.DatalayerDef;
using nKnight.RBACD.DataLayer;
using nKnight.RBAC.SecurityLayer;

namespace nKnight
{
    namespace RBAC
    {
        public partial class frmResourceRoleMapping : Form
        {
            private string assemblyPath = string.Empty;
            DataLayer Rbacd;
            List<RBACD.DatalayerDef.sRole> sRoleList = new List<RBACD.DatalayerDef.sRole>();
            List<RBACD.DatalayerDef.sResource> sResourceList = new List<RBACD.DatalayerDef.sResource>();
            bool shouldClose = false;
            public frmResourceRoleMapping(DataLayer pRbacd, string pAssemblyPath)
            {
                Rbacd = pRbacd;
                assemblyPath = pAssemblyPath;
                if ((!SecurityPrincipal.IsRBACInitialized) && (SecurityPrincipal.IsRBACAuthenticated)) { throw new Exception("RBAC system is not activated..."); } // Check if the RBAC systm is initialize or not
                if (pRbacd == null) { throw new Exception("RBAC data layer is not activated"); } //Check RBAC datalayer is valid or not
                sRoleList = Rbacd.GetAllRoles();
                sResourceList = Rbacd.GetAllResources();
                if ((sRoleList == null) || (sRoleList.Count == 0)) { throw new Exception("Role table is not ready"); }
                InitializeComponent();
                if ((sResourceList == null) || (sResourceList.Count == 0)) { shouldClose = true; }
                Bitmap bmp = Resources.Blue4;

                //lvwResources.BackgroundImage = (Image)bmp;
                //lvwRoles.BackgroundImage = (Image)bmp;
                this.BackgroundImage = (Image)bmp;
                grpResources.BackgroundImage = (Image)bmp;
                grpRoles.BackgroundImage = (Image)bmp;
            }

            private void LoadRoles()
            {
                if ((sRoleList != null) && (sRoleList.Count != 0))
                {
                    lvwRoles.Items.Clear();
                    foreach (sRole sr in sRoleList)
                    {
                        ListViewItem lvwItem = lvwRoles.Items.Add(sr.RoleName);
                        lvwItem.SubItems.Add(sr.RoleDescrition);
                        lvwItem.SubItems.Add(sr.RoleId);
                    }
                }
            }
            private void LoadResources()
            {
                if ((sResourceList != null) && (sResourceList.Count != 0))
                {
                    lvwResources.Items.Clear();
                    foreach (sResource sr in sResourceList)
                    {
                        ListViewItem lvwItem = lvwResources.Items.Add(sr.ResourceName);
                        lvwItem.SubItems.Add(sr.ResourceDescrition);
                        lvwItem.SubItems.Add(sr.ResourceParentName);
                        lvwItem.SubItems.Add(sr.ResourceId);
                    }
                }
            }

            private void frmResourceRoleMapping_Load(object sender, EventArgs e)
            {
                if (shouldClose) { frmResources frmRsc = new frmResources(Rbacd, assemblyPath); frmRsc.Show(); this.Close(); }
                LoadRoles();
                LoadResources();
            }
            /*
            private void Draw(DrawListViewColumnHeaderEventArgs e, Color ColumnBackColor)
            {
                e.Graphics.FillRectangle(new SolidBrush(ColumnBackColor), e.Bounds.X, 0, e.Bounds.Width - 1, e.Bounds.Height - 1);
                e.Graphics.DrawLine(new Pen(Color.Black), e.Bounds.X, 0, e.Bounds.X + e.Bounds.Width - 2, 0);
                e.Graphics.DrawLine(new Pen(Color.Black), e.Bounds.X + 1, e.Bounds.Height - 2, e.Bounds.X + e.Bounds.Width - 2, e.Bounds.Height - 2);
                e.Graphics.DrawLine(new Pen(Color.Black), e.Bounds.X + e.Bounds.Width - 2, 1, e.Bounds.X + e.Bounds.Width - 2, e.Bounds.Height - 2);
                using (Font headerFont = new Font("Book Antiqua", 8.25F, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds);
                }
            }
            */
            private void cmdMap_Click(object sender, EventArgs e)
            {
                string roleId = string.Empty;
                for (int j = 0; j < lvwRoles.Items.Count; j++)
                {
                    if (lvwRoles.Items[j].Selected)
                    {
                        roleId = lvwRoles.Items[j].SubItems[2].Text.ToString();
                    }
                }
                List<RBACD.DatalayerDef.sRoleResourceMap> lstMap = new List<sRoleResourceMap>();
                for (int i = 0; i < lvwResources.Items.Count; i++)
                {
                    if (lvwResources.Items[i].Selected)
                    {
                        RBACD.DatalayerDef.sRoleResourceMap map = new sRoleResourceMap();
                        map.ResourceId = lvwResources.Items[i].SubItems[3].Text.ToString();
                        map.RoleId = roleId;
                        lstMap.Add(map);
                    }
                }
                if (lstMap.Count > 0)
                {
                    if (!Rbacd.MapResourcesWithRoles(lstMap)) { lblMessage.Text = "Error while doing the operation....."; lblMessage.ForeColor = Color.Red; }
                    else { lblMessage.Text = "Role-resource mapping, successfully done....."; lblMessage.ForeColor = Color.LightGreen; }
                }
                else { lblMessage.Text = "Invalid mapping data...."; lblMessage.ForeColor = Color.Red; }
            }

            private void lvwRoles_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void ClearResourceSelection()
            {
                for (int j = 0; j < lvwResources.Items.Count; j++)
                {
                    if (lvwResources.Items[j].Selected)
                    {
                        lvwResources.Items[j].Selected = false;
                    }
                }
            }

            private void SelectResources()
            {
                List<RBACD.DatalayerDef.sRoleResourceMap> mapList = new List<RBACD.DatalayerDef.sRoleResourceMap>();
                for (int j = 0; j < lvwRoles.Items.Count; j++)
                {
                    if (lvwRoles.Items[j].Selected)
                    {
                        string roleId = lvwRoles.Items[j].SubItems[2].Text.ToString();
                        mapList = Rbacd.GetMappedResources(roleId); //Get all the resources against a role id
                    }
                }
                if (mapList.Count > 0)
                {
                    for (int j = 0; j < lvwResources.Items.Count; j++) // loop through all the items in resource list
                    {
                        foreach (RBACD.DatalayerDef.sRoleResourceMap map in mapList)
                        {
                            if (lvwResources.Items[j].SubItems[3].Text.ToString() == map.ResourceId) // If match found, select it
                            {
                                lvwResources.Items[j].Selected = true;
                            }
                        }
                    }
                }
            }

            private void lvwRoles_Click(object sender, EventArgs e)
            {
                lblMessage.Text = string.Empty;
                ClearResourceSelection();
                SelectResources();
            }

            private void lvwResources_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

            private void lvwResources_DrawItem(object sender, DrawListViewItemEventArgs e)
            {
                /*
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
                }
                e.Graphics.DrawString(e.Item.Text, new Font("Tahoma", 8), new SolidBrush(Color.Black), e.Bounds);
                 */
            }
            void lvwResources_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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


            private void lvwResources_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwResources.Columns[0].Width != 110)
                {
                    lvwResources.Columns[0].Width = 110;
                }
                if (lvwResources.Columns[1].Width != 150)
                {
                    lvwResources.Columns[1].Width = 150;
                }
                if (lvwResources.Columns[2].Width != 90)
                {
                    lvwResources.Columns[2].Width = 90;
                }
                if (lvwResources.Columns[3].Width != 220)
                {
                    lvwResources.Columns[3].Width = 220;
                }
            }

            private void lvwRoles_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

            private void lvwRoles_DrawItem(object sender, DrawListViewItemEventArgs e)
            {
                /*
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
                }
                if (!RoleLoaded)
                {
                    e.Graphics.DrawString(e.Item.Text, new Font("Tahoma", 8), new SolidBrush(Color.Black), e.Bounds);
                }
                if (e.ItemIndex == sRoleList.Count - 1)
                {
                    RoleLoaded = true;
                }
                 */
            }

            private void lvwRoles_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            private void lvwRoles_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwRoles.Columns[0].Width != 100)
                {
                    lvwRoles.Columns[0].Width = 100;
                }
                if (lvwRoles.Columns[1].Width != 130)
                {
                    lvwRoles.Columns[1].Width = 130;
                }
                if (lvwRoles.Columns[2].Width != 0)
                {
                    lvwRoles.Columns[2].Width = 0;
                }
            }
        }
    }
}