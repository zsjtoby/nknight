namespace nKnight
{
    namespace RBAC
    {
        partial class frmCreateUser
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateUser));
                this.label1 = new System.Windows.Forms.Label();
                this.txtUserName = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.txtPassword = new System.Windows.Forms.TextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.txtFirstName = new System.Windows.Forms.TextBox();
                this.label4 = new System.Windows.Forms.Label();
                this.txtLastName = new System.Windows.Forms.TextBox();
                this.label5 = new System.Windows.Forms.Label();
                this.txtCitizenship = new System.Windows.Forms.TextBox();
                this.btnSave = new System.Windows.Forms.Button();
                this.grpDetails = new System.Windows.Forms.GroupBox();
                this.lvwCreateUser = new System.Windows.Forms.ListView();
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.grpInfo = new System.Windows.Forms.GroupBox();
                this.txtConfPassword = new System.Windows.Forms.TextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.cmdClear = new System.Windows.Forms.Button();
                this.grpDetails.SuspendLayout();
                this.grpInfo.SuspendLayout();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.BackColor = System.Drawing.Color.Transparent;
                this.label1.ForeColor = System.Drawing.Color.White;
                this.label1.Location = new System.Drawing.Point(303, 46);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(43, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "User ID";
                // 
                // txtUserName
                // 
                this.txtUserName.Location = new System.Drawing.Point(351, 43);
                this.txtUserName.Name = "txtUserName";
                this.txtUserName.Size = new System.Drawing.Size(167, 20);
                this.txtUserName.TabIndex = 3;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.BackColor = System.Drawing.Color.Transparent;
                this.label2.ForeColor = System.Drawing.Color.White;
                this.label2.Location = new System.Drawing.Point(10, 75);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(53, 13);
                this.label2.TabIndex = 2;
                this.label2.Text = "Password";
                // 
                // txtPassword
                // 
                this.txtPassword.Location = new System.Drawing.Point(69, 69);
                this.txtPassword.Name = "txtPassword";
                this.txtPassword.PasswordChar = '*';
                this.txtPassword.Size = new System.Drawing.Size(180, 20);
                this.txtPassword.TabIndex = 4;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.BackColor = System.Drawing.Color.Transparent;
                this.label3.ForeColor = System.Drawing.Color.White;
                this.label3.Location = new System.Drawing.Point(6, 18);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(55, 13);
                this.label3.TabIndex = 4;
                this.label3.Text = "First name";
                // 
                // txtFirstName
                // 
                this.txtFirstName.Location = new System.Drawing.Point(69, 17);
                this.txtFirstName.Name = "txtFirstName";
                this.txtFirstName.Size = new System.Drawing.Size(180, 20);
                this.txtFirstName.TabIndex = 0;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.BackColor = System.Drawing.Color.Transparent;
                this.label4.ForeColor = System.Drawing.Color.White;
                this.label4.Location = new System.Drawing.Point(290, 17);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(56, 13);
                this.label4.TabIndex = 6;
                this.label4.Text = "Last name";
                // 
                // txtLastName
                // 
                this.txtLastName.Location = new System.Drawing.Point(352, 14);
                this.txtLastName.Name = "txtLastName";
                this.txtLastName.Size = new System.Drawing.Size(166, 20);
                this.txtLastName.TabIndex = 1;
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.BackColor = System.Drawing.Color.Transparent;
                this.label5.ForeColor = System.Drawing.Color.White;
                this.label5.Location = new System.Drawing.Point(4, 46);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(57, 13);
                this.label5.TabIndex = 8;
                this.label5.Text = "Citizenship";
                // 
                // txtCitizenship
                // 
                this.txtCitizenship.Location = new System.Drawing.Point(69, 43);
                this.txtCitizenship.Name = "txtCitizenship";
                this.txtCitizenship.Size = new System.Drawing.Size(180, 20);
                this.txtCitizenship.TabIndex = 2;
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(384, 124);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(76, 23);
                this.btnSave.TabIndex = 6;
                this.btnSave.Text = "Save";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // grpDetails
                // 
                this.grpDetails.BackColor = System.Drawing.Color.Transparent;
                this.grpDetails.Controls.Add(this.lvwCreateUser);
                this.grpDetails.ForeColor = System.Drawing.Color.White;
                this.grpDetails.Location = new System.Drawing.Point(6, 153);
                this.grpDetails.Name = "grpDetails";
                this.grpDetails.Size = new System.Drawing.Size(538, 202);
                this.grpDetails.TabIndex = 12;
                this.grpDetails.TabStop = false;
                this.grpDetails.Text = "User Details";
                // 
                // lvwCreateUser
                // 
                this.lvwCreateUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
                this.lvwCreateUser.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lvwCreateUser.FullRowSelect = true;
                this.lvwCreateUser.GridLines = true;
                this.lvwCreateUser.Location = new System.Drawing.Point(3, 16);
                this.lvwCreateUser.Name = "lvwCreateUser";
                this.lvwCreateUser.OwnerDraw = true;
                this.lvwCreateUser.ShowItemToolTips = true;
                this.lvwCreateUser.Size = new System.Drawing.Size(532, 183);
                this.lvwCreateUser.TabIndex = 8;
                this.lvwCreateUser.UseCompatibleStateImageBehavior = false;
                this.lvwCreateUser.View = System.Windows.Forms.View.Details;
                this.lvwCreateUser.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwCreateUser_DrawColumnHeader);
                this.lvwCreateUser.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwCreateUser_ColumnWidthChanged);
                this.lvwCreateUser.DoubleClick += new System.EventHandler(this.lvwCreateUser_DoubleClick);
                this.lvwCreateUser.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwCreateUser_DrawSubItem);
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "User Name";
                this.columnHeader1.Width = 85;
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "Password";
                this.columnHeader2.Width = 85;
                // 
                // columnHeader3
                // 
                this.columnHeader3.Text = "First Name";
                this.columnHeader3.Width = 85;
                // 
                // columnHeader4
                // 
                this.columnHeader4.Text = "Last Name";
                this.columnHeader4.Width = 85;
                // 
                // columnHeader5
                // 
                this.columnHeader5.Text = "Citizenship";
                this.columnHeader5.Width = 85;
                // 
                // grpInfo
                // 
                this.grpInfo.Controls.Add(this.label1);
                this.grpInfo.Controls.Add(this.txtConfPassword);
                this.grpInfo.Controls.Add(this.label6);
                this.grpInfo.Controls.Add(this.label2);
                this.grpInfo.Controls.Add(this.txtUserName);
                this.grpInfo.Controls.Add(this.txtCitizenship);
                this.grpInfo.Controls.Add(this.label5);
                this.grpInfo.Controls.Add(this.txtPassword);
                this.grpInfo.Controls.Add(this.label3);
                this.grpInfo.Controls.Add(this.txtLastName);
                this.grpInfo.Controls.Add(this.txtFirstName);
                this.grpInfo.Controls.Add(this.label4);
                this.grpInfo.ForeColor = System.Drawing.Color.White;
                this.grpInfo.Location = new System.Drawing.Point(6, 12);
                this.grpInfo.Name = "grpInfo";
                this.grpInfo.Size = new System.Drawing.Size(538, 106);
                this.grpInfo.TabIndex = 13;
                this.grpInfo.TabStop = false;
                this.grpInfo.Text = "User Info";
                // 
                // txtConfPassword
                // 
                this.txtConfPassword.Location = new System.Drawing.Point(351, 72);
                this.txtConfPassword.Name = "txtConfPassword";
                this.txtConfPassword.PasswordChar = '*';
                this.txtConfPassword.Size = new System.Drawing.Size(167, 20);
                this.txtConfPassword.TabIndex = 5;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.BackColor = System.Drawing.Color.Transparent;
                this.label6.ForeColor = System.Drawing.Color.White;
                this.label6.Location = new System.Drawing.Point(255, 75);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(91, 13);
                this.label6.TabIndex = 2;
                this.label6.Text = "Confirm Password";
                // 
                // cmdClear
                // 
                this.cmdClear.Location = new System.Drawing.Point(468, 124);
                this.cmdClear.Name = "cmdClear";
                this.cmdClear.Size = new System.Drawing.Size(76, 23);
                this.cmdClear.TabIndex = 7;
                this.cmdClear.Text = "Clear";
                this.cmdClear.UseVisualStyleBackColor = true;
                this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
                // 
                // frmCreateUser
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(549, 360);
                this.Controls.Add(this.grpInfo);
                this.Controls.Add(this.grpDetails);
                this.Controls.Add(this.cmdClear);
                this.Controls.Add(this.btnSave);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmCreateUser";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Create User";
                this.Load += new System.EventHandler(this.frmCreateUser_Load);
                this.grpDetails.ResumeLayout(false);
                this.grpInfo.ResumeLayout(false);
                this.grpInfo.PerformLayout();
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox txtUserName;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox txtPassword;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.TextBox txtFirstName;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.TextBox txtLastName;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.TextBox txtCitizenship;
            private System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.GroupBox grpDetails;
            private System.Windows.Forms.GroupBox grpInfo;
            private System.Windows.Forms.ListView lvwCreateUser;
            private System.Windows.Forms.ColumnHeader columnHeader1;
            private System.Windows.Forms.ColumnHeader columnHeader2;
            private System.Windows.Forms.ColumnHeader columnHeader3;
            private System.Windows.Forms.ColumnHeader columnHeader4;
            private System.Windows.Forms.ColumnHeader columnHeader5;
            private System.Windows.Forms.Button cmdClear;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.TextBox txtConfPassword;
        }
    }
}