namespace nKnight
{
    namespace RBAC
    {
        partial class frmCreateSecurityGroups
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateSecurityGroups));
                this.grpInfo = new System.Windows.Forms.GroupBox();
                this.txtDisplayName = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.txtName = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.grpDetails = new System.Windows.Forms.GroupBox();
                this.lvwSecurityGroup = new System.Windows.Forms.ListView();
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.btnSave = new System.Windows.Forms.Button();
                this.cmdClear = new System.Windows.Forms.Button();
                this.grpInfo.SuspendLayout();
                this.grpDetails.SuspendLayout();
                this.SuspendLayout();
                // 
                // grpInfo
                // 
                this.grpInfo.BackColor = System.Drawing.Color.Transparent;
                this.grpInfo.Controls.Add(this.txtDisplayName);
                this.grpInfo.Controls.Add(this.label2);
                this.grpInfo.Controls.Add(this.txtName);
                this.grpInfo.Controls.Add(this.label1);
                this.grpInfo.ForeColor = System.Drawing.Color.White;
                this.grpInfo.Location = new System.Drawing.Point(3, 6);
                this.grpInfo.Name = "grpInfo";
                this.grpInfo.Size = new System.Drawing.Size(365, 63);
                this.grpInfo.TabIndex = 0;
                this.grpInfo.TabStop = false;
                this.grpInfo.Text = "Security Group Info";
                // 
                // txtDisplayName
                // 
                this.txtDisplayName.Location = new System.Drawing.Point(244, 25);
                this.txtDisplayName.Name = "txtDisplayName";
                this.txtDisplayName.Size = new System.Drawing.Size(112, 20);
                this.txtDisplayName.TabIndex = 1;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.BackColor = System.Drawing.Color.Transparent;
                this.label2.ForeColor = System.Drawing.Color.White;
                this.label2.Location = new System.Drawing.Point(166, 28);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(72, 13);
                this.label2.TabIndex = 2;
                this.label2.Text = "Display Name";
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(48, 25);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(112, 20);
                this.txtName.TabIndex = 0;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.BackColor = System.Drawing.Color.Transparent;
                this.label1.ForeColor = System.Drawing.Color.White;
                this.label1.Location = new System.Drawing.Point(6, 28);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(35, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "Name";
                // 
                // grpDetails
                // 
                this.grpDetails.BackColor = System.Drawing.Color.Transparent;
                this.grpDetails.Controls.Add(this.lvwSecurityGroup);
                this.grpDetails.ForeColor = System.Drawing.Color.White;
                this.grpDetails.Location = new System.Drawing.Point(3, 104);
                this.grpDetails.Name = "grpDetails";
                this.grpDetails.Size = new System.Drawing.Size(365, 153);
                this.grpDetails.TabIndex = 1;
                this.grpDetails.TabStop = false;
                this.grpDetails.Text = "Security Group Details";
                // 
                // lvwSecurityGroup
                // 
                this.lvwSecurityGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
                this.lvwSecurityGroup.FullRowSelect = true;
                this.lvwSecurityGroup.GridLines = true;
                this.lvwSecurityGroup.HideSelection = false;
                this.lvwSecurityGroup.Location = new System.Drawing.Point(6, 20);
                this.lvwSecurityGroup.Name = "lvwSecurityGroup";
                this.lvwSecurityGroup.OwnerDraw = true;
                this.lvwSecurityGroup.ShowItemToolTips = true;
                this.lvwSecurityGroup.Size = new System.Drawing.Size(352, 127);
                this.lvwSecurityGroup.TabIndex = 4;
                this.lvwSecurityGroup.UseCompatibleStateImageBehavior = false;
                this.lvwSecurityGroup.View = System.Windows.Forms.View.Details;
                this.lvwSecurityGroup.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwSecurityGroup_DrawColumnHeader);
                this.lvwSecurityGroup.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwSecurityGroup_ColumnWidthChanged);
                this.lvwSecurityGroup.DoubleClick += new System.EventHandler(this.lvwSecurityGroup_DoubleClick);
                this.lvwSecurityGroup.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwSecurityGroup_DrawSubItem);
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "Security Group Name";
                this.columnHeader1.Width = 172;
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "Display Name";
                this.columnHeader2.Width = 175;
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(200, 75);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(81, 23);
                this.btnSave.TabIndex = 2;
                this.btnSave.Text = "Save";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // cmdClear
                // 
                this.cmdClear.Location = new System.Drawing.Point(287, 75);
                this.cmdClear.Name = "cmdClear";
                this.cmdClear.Size = new System.Drawing.Size(81, 23);
                this.cmdClear.TabIndex = 3;
                this.cmdClear.Text = "Clear";
                this.cmdClear.UseVisualStyleBackColor = true;
                this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
                // 
                // frmCreateSecurityGroups
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(371, 260);
                this.Controls.Add(this.cmdClear);
                this.Controls.Add(this.btnSave);
                this.Controls.Add(this.grpDetails);
                this.Controls.Add(this.grpInfo);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "frmCreateSecurityGroups";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Create Security Groups";
                this.Load += new System.EventHandler(this.frmCreateSecurityGroups_Load);
                this.grpInfo.ResumeLayout(false);
                this.grpInfo.PerformLayout();
                this.grpDetails.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.GroupBox grpInfo;
            private System.Windows.Forms.GroupBox grpDetails;
            private System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.TextBox txtDisplayName;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox txtName;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ListView lvwSecurityGroup;
            private System.Windows.Forms.ColumnHeader columnHeader1;
            private System.Windows.Forms.ColumnHeader columnHeader2;
            private System.Windows.Forms.Button cmdClear;
        }
    }
}