using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nKnight.RBAC.SecurityLayer;
using System.Data.Odbc;
using nKnight.RBAC;
using nKnight.RBACD.DataLayer;

namespace TestRBACControl
{
    public partial class Form1 : Form
    {
        DataLayer dbl = null;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            rbacCombo1.SelectedIndex = 2;
            string conStr = "DRIVER={MySQL ODBC 5.1 Driver};SERVER=192.168.1.12;PORT=3306;DATABASE=RBAC;USER=root;PASSWORD=root;OPTION=3";
            IDbConnection con = (IDbConnection)new OdbcConnection(conStr);
            con.Open();

            try
            {
                //rbacButton1.GroupUniqueID = rbacButton1.GroupUniqueID;

                dbl = new DataLayer(con, DataLayer.DatabaseType.MySql);
                bool d = SecurityPrincipal.InitSecuritySystem(dbl, "Admin", "Admin");


                rbacButton1.oError += new nKnight.RBACControl.OnRBACButtonError(rbacButton1_oError);
                rbacTextBox1.oError +=new nKnight.RBACControl.OnTextBoxError(rbacTextBox1_oError);
                rbacCheckBox1.oError +=new nKnight.RBACControl.OnRBACCheckBoxError(rbacCheckBox1_oError);
                rbacMaskedTextBox1.oError +=new nKnight.RBACControl.OnRBACMaskedTextBoxError(rbacMaskedTextBox1_oError);
                rbacRadioButton1.oError +=new nKnight.RBACControl.OnRBACRadioButtonError(rbacRadioButton1_oError);
                rbacCombo1.oError +=new nKnight.RBACControl.OnRBACCComboError(rbacCombo1_oError);
                rbacCheckListBox1.oError +=new nKnight.RBACControl.OnRBACCheckListBoxError(rbacCheckListBox1_oError);
                rbacLinkLabel1.oError+=new nKnight.RBACControl.OnRBACLinkLabelError(rbacLinkLabel1_oError);
                nKnightDateTimePicker1.oError +=new nKnight.RBACControl.OnRBACDtPickerError(nKnightDateTimePicker1_oError);
                nKnightGridView1.oError +=new nKnight.RBACControl.OnRBACGridError(nKnightGridView1_oError);
                nKnightButton1.oError +=new nKnight.RBACControl.OnRBACButtonError(nKnightButton1_oError);
                nKnightRadioButton2.oError +=new nKnight.RBACControl.OnRBACRadioButtonError(nKnightRadioButton2_oError);
                //rbacButton1.Click += new EventHandler(rbacButton1_Click);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void nKnightRadioButton2_oError(nKnight.RBACControl.RadioButtonControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void nKnightDateTimePicker1_oError(nKnight.RBACControl.DTPickerControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void nKnightButton1_oError(nKnight.RBACControl.ButtonControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void nKnightGridView1_oError(nKnight.RBACControl.GridControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacLinkLabel1_oError(nKnight.RBACControl.LinkLabelControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacCombo1_oError(nKnight.RBACControl.ComboControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacCheckListBox1_oError(nKnight.RBACControl.CheckListBoxControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacRadioButton1_oError(nKnight.RBACControl.RadioButtonControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacMaskedTextBox1_oError(nKnight.RBACControl.MaskedTextBoxControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacCheckBox1_oError(nKnight.RBACControl.CheckBoxControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbacButton1_oError(nKnight.RBACControl.ButtonControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }
        private void rbacTextBox1_oError(nKnight.RBACControl.TextBoxControlEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }

        private void rbacTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            frmResources frmRe = new frmResources(dbl, path);
            frmRe.Show();
        }

        private void rbacCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbacCheckBox1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbacMaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbacRadioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rbacRadioButton2_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rbacCombo1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void rbacCombo1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void rbacCombo1_SelectedIndexChanging(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
                    
        }

        private void rbacCombo1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            MessageBox.Show("On close");
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }

        private void rbacCheckListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void rbacLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<User> lUser = new List<User>();
            User u = new User();
            u.A = "Subhajit";
            u.B = "Bhadury";
            lUser.Add(u);

            User u1 = new User();
            u1.A = "Rahul";
            u1.B = "Naskar";
            lUser.Add(u1);
            
            nKnightGridView1.DataSource = lUser;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCreateUser frmCrtUsr = new frmCreateUser(dbl);
            frmCrtUsr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCreateSecurityGroups frmCrtSecuGrou = new frmCreateSecurityGroups(dbl);
            frmCrtSecuGrou.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAssignsSecurityGroup frmAssSecuGrou = new frmAssignsSecurityGroup(dbl);
            frmAssSecuGrou.Show();
        }

        private void nKnightDateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void nKnightGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nKnightMaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void nKnightRadioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void nKnightTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void nKnightButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("In normal operating mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
    public class User
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}
