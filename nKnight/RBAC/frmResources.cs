using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using nKnight.RBAC;
using nKnight.RBAC.SecurityLayer;
using nKnight.RBACD.DataLayer;

namespace nKnight
{
    namespace RBAC
    {
        public partial class frmResources : Form
        {
            private string assemblyPath = string.Empty;
            List<System.Windows.Forms.Form> results = new List<Form>();
            List<RBACD.DatalayerDef.sResource> rcsList = new List<RBACD.DatalayerDef.sResource>();
            DataLayer Rbacd;
            List<RBACD.DatalayerDef.sRole> sRoleList = new List<RBACD.DatalayerDef.sRole>();
            List<RBACD.DatalayerDef.sResource> sResourceList = new List<RBACD.DatalayerDef.sResource>();
            /// <summary>
            /// Constructor with assembly path parameter to find all the RBAC resources used in the assembly
            /// </summary>
            /// <param name="pAssemblyPath"></param>
            public frmResources(DataLayer pRbacd, string pAssemblyPath)
            {
                Rbacd = pRbacd;
                if ((!SecurityPrincipal.IsRBACInitialized) && (SecurityPrincipal.IsRBACAuthenticated)) { throw new Exception("RBAC system is not activated..."); } // Check if the RBAC systm is initialize or not
                if (pRbacd == null) { throw new Exception("RBAC data layer is not activated"); } //Check RBAC datalayer is valid or not
                if (!File.Exists(pAssemblyPath)) { throw new Exception("Assembly not found"); } //Check that provided assembly path is valid or not
                sRoleList = Rbacd.GetAllRoles();
                sResourceList = Rbacd.GetAllResources();
                assemblyPath = pAssemblyPath;
                if ((sRoleList == null) || (sRoleList.Count == 0)) { throw new Exception("Role table is not ready"); }
                Rbacd = pRbacd;//Initialize a member variable
                InitializeComponent();

                Bitmap bmp = Resources.Blue4;
                this.BackgroundImage = (Image)bmp;
                grpResources.BackgroundImage = (Image)bmp;
                grpForms.BackgroundImage = (Image)bmp;
            }

            private void frmResources_Load(object sender, EventArgs e)
            {
                LoadForms();
                LoadAllControlsIntoList();
                if (lvwForms.Items.Count > 0)
                {
                    //lvwForms.Focus();
                    lvwForms.Items[0].Selected = true;
                }
            }
            /// <summary>
            /// List All the forms used in the assembly
            /// </summary>
            private void LoadForms()
            {
                results = Utils.GetChildren(assemblyPath).ToList();
                lvwForms.Items.Clear();
                foreach (Form f in results)
                {
                    ListViewItem lvwItem = lvwForms.Items.Add(f.Name);
                    lvwItem.SubItems.Add(f.Text);
                }
            }
            /// <summary>
            /// Load all the controls, when user click a form. This will load only RBAC controls
            /// </summary>
            /// <param name="pFormName"></param>
            private void LoadControls(string pFormName)
            {
                foreach (Form f in results)
                {
                    if (pFormName == f.Name) //If parameter form name matches.
                    {
                        lvwResources.Items.Clear();
                        foreach (Control c in f.Controls) //Loop through all the controls
                        {
                            Type t = c.GetType();
                            PropertyInfo[] properties = t.GetProperties(); //Get all the properties associated with the RBAC controls
                            foreach (PropertyInfo property in properties)
                            {
                                if (property.Name == "GroupUniqueID")
                                {
                                    ListViewItem lvwItem = lvwResources.Items.Add(c.Name);
                                    lvwItem.SubItems.Add(t.Name);
                                    lvwItem.SubItems.Add(property.GetValue(c, null).ToString());
                                }
                            }
                        }
                    }
                }
            }
            /// <summary>
            /// Load all the controls used in an assembly. This will load only RBAC controls
            /// </summary>
            /// <param name="pFormName"></param>
            private void LoadAllControlsIntoList()
            {
                if (rcsList != null) { rcsList.Clear(); }
                foreach (Form f in results)
                {
                    foreach (Control c in f.Controls) //Loop through all the controls
                    {
                        Type t = c.GetType();
                        PropertyInfo[] properties = t.GetProperties(); //Get all the properties associated with the RBAC controls
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.Name == "GroupUniqueID")
                            {
                                RBACD.DatalayerDef.sResource rcs = new RBACD.DatalayerDef.sResource();
                                rcs.ResourceId = property.GetValue(c, null).ToString();
                                rcs.ResourceName = c.Name;
                                rcs.ResourceDescrition = t.Name;
                                rcs.ResourceParentName = f.Name;
                                rcsList.Add(rcs); //Load all resources into a list for database saving
                            }
                        }
                    }
                }
            }

            private void cmdSave_Click(object sender, EventArgs e)
            {
                if (Rbacd.SaveResources(rcsList)) { this.Close(); frmResourceRoleMapping frmMap = new frmResourceRoleMapping(Rbacd, assemblyPath); frmMap.Show(); }
                else { MessageBox.Show("Error while saving the resource table....."); }
            }

            private void cmdClose_Click(object sender, EventArgs e)
            {
                sResourceList = Rbacd.GetAllResources();
                //If resource table is not empty then role resource map form will be opened, else close the whole operation.
                if (sResourceList.Count > 0) { this.Close(); frmResourceRoleMapping frmMap = new frmResourceRoleMapping(Rbacd, assemblyPath); frmMap.Show(); }
                else { this.Close(); }
            }

            private void lvwForms_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (lvwForms.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = lvwForms.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    string name = lvwForms.Items[intselectedindex].Text;
                    LoadControls(name);
                }
            }

            private void lvwForms_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

            private void lvwForms_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            private void lvwResources_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            private void lvwForms_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwForms.Columns[0].Width != 114)
                {
                    lvwForms.Columns[0].Width = 114;
                }

            }

            private void lvwResources_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
            {
                if (lvwResources.Columns[0].Width != 90)
                {
                    lvwResources.Columns[0].Width = 90;
                }
                if (lvwResources.Columns[1].Width != 120)
                {
                    lvwResources.Columns[1].Width = 120;
                }
                if (lvwResources.Columns[2].Width != 240)
                {
                    lvwResources.Columns[2].Width = 240;
                }
            }
        }
    }
}