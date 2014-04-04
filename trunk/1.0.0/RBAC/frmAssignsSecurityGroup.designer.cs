namespace nKnight
{
    namespace RBAC
    {
        partial class frmAssignsSecurityGroup
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignsSecurityGroup));
                this.btnSave = new System.Windows.Forms.Button();
                this.lblMessage = new System.Windows.Forms.Label();
                this.lvwUser = new System.Windows.Forms.ListView();
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.lvwSecurityGroup = new System.Windows.Forms.ListView();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.grpAssign = new System.Windows.Forms.GroupBox();
                this.grpAssign.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnSave
                // 
                this.btnSave.BackColor = System.Drawing.SystemColors.Control;
                this.btnSave.Location = new System.Drawing.Point(325, 319);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(78, 23);
                this.btnSave.TabIndex = 1;
                this.btnSave.Text = "Map";
                this.btnSave.UseVisualStyleBackColor = false;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // lblMessage
                // 
                this.lblMessage.AutoSize = true;
                this.lblMessage.BackColor = System.Drawing.Color.Transparent;
                this.lblMessage.Location = new System.Drawing.Point(8, 325);
                this.lblMessage.Name = "lblMessage";
                this.lblMessage.Size = new System.Drawing.Size(0, 13);
                this.lblMessage.TabIndex = 2;
                // 
                // lvwUser
                // 
                this.lvwUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
                this.lvwUser.FullRowSelect = true;
                this.lvwUser.GridLines = true;
                this.lvwUser.HideSelection = false;
                this.lvwUser.Location = new System.Drawing.Point(7, 19);
                this.lvwUser.MultiSelect = false;
                this.lvwUser.Name = "lvwUser";
                this.lvwUser.OwnerDraw = true;
                this.lvwUser.ShowItemToolTips = true;
                this.lvwUser.Size = new System.Drawing.Size(181, 283);
                this.lvwUser.TabIndex = 2;
                this.lvwUser.UseCompatibleStateImageBehavior = false;
                this.lvwUser.View = System.Windows.Forms.View.Details;
                this.lvwUser.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwUser_DrawColumnHeader);
                this.lvwUser.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwUser_ColumnWidthChanged);
                this.lvwUser.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwUser_DrawSubItem);
                this.lvwUser.Click += new System.EventHandler(this.lvwUser_Click);
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "User name";
                this.columnHeader1.Width = 175;
                // 
                // lvwSecurityGroup
                // 
                this.lvwSecurityGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
                this.lvwSecurityGroup.FullRowSelect = true;
                this.lvwSecurityGroup.GridLines = true;
                this.lvwSecurityGroup.Location = new System.Drawing.Point(204, 19);
                this.lvwSecurityGroup.Name = "lvwSecurityGroup";
                this.lvwSecurityGroup.OwnerDraw = true;
                this.lvwSecurityGroup.ShowItemToolTips = true;
                this.lvwSecurityGroup.Size = new System.Drawing.Size(185, 283);
                this.lvwSecurityGroup.TabIndex = 3;
                this.lvwSecurityGroup.UseCompatibleStateImageBehavior = false;
                this.lvwSecurityGroup.View = System.Windows.Forms.View.Details;
                this.lvwSecurityGroup.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwSecurityGroup_DrawColumnHeader);
                this.lvwSecurityGroup.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwSecurityGroup_ColumnWidthChanged);
                this.lvwSecurityGroup.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwSecurityGroup_DrawSubItem);
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "Security Group";
                this.columnHeader2.Width = 180;
                // 
                // grpAssign
                // 
                this.grpAssign.BackColor = System.Drawing.Color.Transparent;
                this.grpAssign.Controls.Add(this.lvwSecurityGroup);
                this.grpAssign.Controls.Add(this.lvwUser);
                this.grpAssign.ForeColor = System.Drawing.Color.White;
                this.grpAssign.Location = new System.Drawing.Point(4, 5);
                this.grpAssign.Name = "grpAssign";
                this.grpAssign.Size = new System.Drawing.Size(399, 308);
                this.grpAssign.TabIndex = 0;
                this.grpAssign.TabStop = false;
                this.grpAssign.Text = "Assign Security Group";
                // 
                // frmAssignsSecurityGroup
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(407, 347);
                this.Controls.Add(this.lblMessage);
                this.Controls.Add(this.btnSave);
                this.Controls.Add(this.grpAssign);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmAssignsSecurityGroup";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "User & Security Group Mapping";
                this.Load += new System.EventHandler(this.frmAssignsSecurityGroup_Load);
                this.grpAssign.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.Label lblMessage;
            private System.Windows.Forms.ListView lvwUser;
            private System.Windows.Forms.ColumnHeader columnHeader1;
            private System.Windows.Forms.ListView lvwSecurityGroup;
            private System.Windows.Forms.ColumnHeader columnHeader2;
            private System.Windows.Forms.GroupBox grpAssign;
        }
    }
}