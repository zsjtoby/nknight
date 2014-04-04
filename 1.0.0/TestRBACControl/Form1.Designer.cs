using nKnight.RBACControl;
namespace TestRBACControl
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.nKnightTextBox1 = new nKnight.RBACControl.nKnightTextBox();
            this.nKnightRadioButton1 = new nKnight.RBACControl.nKnightRadioButton();
            this.nKnightMaskedTextBox1 = new nKnight.RBACControl.nKnightMaskedTextBox();
            this.nKnightLinkLabel1 = new nKnight.RBACControl.nKnightLinkLabel();
            this.nKnightGridView1 = new nKnight.RBACControl.nKnightGridView();
            this.nKnightDateTimePicker1 = new nKnight.RBACControl.nKnightDateTimePicker();
            this.nKnightCombo1 = new nKnight.RBACControl.nKnightCombo();
            this.nKnightCheckListBox1 = new nKnight.RBACControl.nKnightCheckListBox();
            this.nKnightCheckBox1 = new nKnight.RBACControl.nKnightCheckBox();
            this.nKnightButton1 = new nKnight.RBACControl.nKnightButton();
            this.rbacLinkLabel1 = new nKnight.RBACControl.nKnightLinkLabel();
            this.rbacCheckListBox1 = new nKnight.RBACControl.nKnightCheckListBox();
            this.rbacTextBox1 = new nKnight.RBACControl.nKnightTextBox();
            this.rbacRadioButton1 = new nKnight.RBACControl.nKnightRadioButton();
            this.rbacMaskedTextBox1 = new nKnight.RBACControl.nKnightMaskedTextBox();
            this.rbacCombo1 = new nKnight.RBACControl.nKnightCombo();
            this.rbacCheckBox1 = new nKnight.RBACControl.nKnightCheckBox();
            this.rbacButton1 = new nKnight.RBACControl.nKnightButton();
            this.nKnightRadioButton2 = new nKnight.RBACControl.nKnightRadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nKnightGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(163, 307);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(146, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker1_Validating);
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(36, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(505, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 256);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(134, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(25, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nKnightTextBox1
            // 
            this.nKnightTextBox1.GroupUniqueID = "c20d22d3-e1fb-46a9-90d6-5ef3bc128e63";
            this.nKnightTextBox1.Location = new System.Drawing.Point(334, 444);
            this.nKnightTextBox1.Name = "nKnightTextBox1";
            this.nKnightTextBox1.Size = new System.Drawing.Size(119, 20);
            this.nKnightTextBox1.TabIndex = 24;
            this.nKnightTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nKnightTextBox1_KeyPress);
            // 
            // nKnightRadioButton1
            // 
            this.nKnightRadioButton1.AutoSize = true;
            this.nKnightRadioButton1.GroupUniqueID = "a4c24130-2395-4654-8708-0ef817ddccd5";
            this.nKnightRadioButton1.Location = new System.Drawing.Point(209, 356);
            this.nKnightRadioButton1.Name = "nKnightRadioButton1";
            this.nKnightRadioButton1.Size = new System.Drawing.Size(126, 17);
            this.nKnightRadioButton1.TabIndex = 23;
            this.nKnightRadioButton1.TabStop = true;
            this.nKnightRadioButton1.Text = "nKnightRadioButton1";
            this.nKnightRadioButton1.UseVisualStyleBackColor = true;
            this.nKnightRadioButton1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nKnightRadioButton1_KeyPress);
            // 
            // nKnightMaskedTextBox1
            // 
            this.nKnightMaskedTextBox1.GroupUniqueID = "34ba8fc0-5263-41d1-9ae4-8033f19a7c91";
            this.nKnightMaskedTextBox1.Location = new System.Drawing.Point(178, 458);
            this.nKnightMaskedTextBox1.Mask = "00/00/0000 90:00";
            this.nKnightMaskedTextBox1.Name = "nKnightMaskedTextBox1";
            this.nKnightMaskedTextBox1.Size = new System.Drawing.Size(99, 20);
            this.nKnightMaskedTextBox1.TabIndex = 22;
            this.nKnightMaskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.nKnightMaskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nKnightMaskedTextBox1_KeyPress);
            // 
            // nKnightLinkLabel1
            // 
            this.nKnightLinkLabel1.AutoSize = true;
            this.nKnightLinkLabel1.GroupUniqueID = "14e5b3bc-2576-4c44-9dae-03ac59dcfe1b";
            this.nKnightLinkLabel1.Location = new System.Drawing.Point(196, 415);
            this.nKnightLinkLabel1.Name = "nKnightLinkLabel1";
            this.nKnightLinkLabel1.Size = new System.Drawing.Size(95, 13);
            this.nKnightLinkLabel1.TabIndex = 21;
            this.nKnightLinkLabel1.TabStop = true;
            this.nKnightLinkLabel1.Text = "nKnightLinkLabel1";
            // 
            // nKnightGridView1
            // 
            this.nKnightGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nKnightGridView1.GroupUniqueID = "0db45f18-7814-43fc-9330-f276ea4b3309";
            this.nKnightGridView1.Location = new System.Drawing.Point(12, 351);
            this.nKnightGridView1.Name = "nKnightGridView1";
            this.nKnightGridView1.Size = new System.Drawing.Size(42, 150);
            this.nKnightGridView1.TabIndex = 20;
            this.nKnightGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.nKnightGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.nKnightGridView1_CellContentClick);
            // 
            // nKnightDateTimePicker1
            // 
            this.nKnightDateTimePicker1.GroupUniqueID = "3ffa7d97-2d77-48d9-a71e-84bfb982f1b6";
            this.nKnightDateTimePicker1.Location = new System.Drawing.Point(395, 147);
            this.nKnightDateTimePicker1.Name = "nKnightDateTimePicker1";
            this.nKnightDateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.nKnightDateTimePicker1.TabIndex = 19;
            this.nKnightDateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.nKnightDateTimePicker1_Validating);
            // 
            // nKnightCombo1
            // 
            this.nKnightCombo1.FormattingEnabled = true;
            this.nKnightCombo1.GroupUniqueID = "7028a506-ac05-4b67-b73d-69ecc31896f7";
            this.nKnightCombo1.Location = new System.Drawing.Point(515, 108);
            this.nKnightCombo1.Name = "nKnightCombo1";
            this.nKnightCombo1.Size = new System.Drawing.Size(121, 21);
            this.nKnightCombo1.TabIndex = 18;
            // 
            // nKnightCheckListBox1
            // 
            this.nKnightCheckListBox1.FormattingEnabled = true;
            this.nKnightCheckListBox1.GroupUniqueID = "7c4d0754-c565-4927-bce4-3ebb74763e19";
            this.nKnightCheckListBox1.Location = new System.Drawing.Point(354, 36);
            this.nKnightCheckListBox1.Name = "nKnightCheckListBox1";
            this.nKnightCheckListBox1.Size = new System.Drawing.Size(120, 94);
            this.nKnightCheckListBox1.TabIndex = 17;
            // 
            // nKnightCheckBox1
            // 
            this.nKnightCheckBox1.AutoSize = true;
            this.nKnightCheckBox1.GroupUniqueID = "3701c0cb-8fb8-433a-82f2-bb81b0bcd87a";
            this.nKnightCheckBox1.Location = new System.Drawing.Point(505, 74);
            this.nKnightCheckBox1.Name = "nKnightCheckBox1";
            this.nKnightCheckBox1.Size = new System.Drawing.Size(117, 17);
            this.nKnightCheckBox1.TabIndex = 16;
            this.nKnightCheckBox1.Text = "nKnightCheckBox1";
            this.nKnightCheckBox1.UseVisualStyleBackColor = true;
            // 
            // nKnightButton1
            // 
            this.nKnightButton1.GroupUniqueID = "1704a300-66ef-4e1a-9da0-72c550034529";
            this.nKnightButton1.Location = new System.Drawing.Point(505, 23);
            this.nKnightButton1.Name = "nKnightButton1";
            this.nKnightButton1.Size = new System.Drawing.Size(100, 30);
            this.nKnightButton1.TabIndex = 15;
            this.nKnightButton1.Text = "nKnightButton1";
            this.nKnightButton1.UseVisualStyleBackColor = true;
            this.nKnightButton1.Click += new System.EventHandler(this.nKnightButton1_Click);
            // 
            // rbacLinkLabel1
            // 
            this.rbacLinkLabel1.AutoSize = true;
            this.rbacLinkLabel1.GroupUniqueID = "c42e202d-3324-46bb-8277-8f7f68080e95";
            this.rbacLinkLabel1.Location = new System.Drawing.Point(96, 88);
            this.rbacLinkLabel1.Name = "rbacLinkLabel1";
            this.rbacLinkLabel1.Size = new System.Drawing.Size(80, 13);
            this.rbacLinkLabel1.TabIndex = 12;
            this.rbacLinkLabel1.TabStop = true;
            this.rbacLinkLabel1.Text = "rbacLinkLabel1";
            this.rbacLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.rbacLinkLabel1_LinkClicked);
            // 
            // rbacCheckListBox1
            // 
            this.rbacCheckListBox1.CheckOnClick = true;
            this.rbacCheckListBox1.FormattingEnabled = true;
            this.rbacCheckListBox1.GroupUniqueID = "f95b4130-fcbe-4381-89f5-898c74aa984b";
            this.rbacCheckListBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.rbacCheckListBox1.Location = new System.Drawing.Point(12, 207);
            this.rbacCheckListBox1.Name = "rbacCheckListBox1";
            this.rbacCheckListBox1.Size = new System.Drawing.Size(120, 94);
            this.rbacCheckListBox1.TabIndex = 10;
            this.rbacCheckListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rbacCheckListBox1_ItemCheck);
            // 
            // rbacTextBox1
            // 
            this.rbacTextBox1.GroupUniqueID = "7569dd94-c970-46c7-bddc-a510fdd112c9";
            this.rbacTextBox1.Location = new System.Drawing.Point(209, 264);
            this.rbacTextBox1.Name = "rbacTextBox1";
            this.rbacTextBox1.Size = new System.Drawing.Size(100, 20);
            this.rbacTextBox1.TabIndex = 8;
            // 
            // rbacRadioButton1
            // 
            this.rbacRadioButton1.AutoSize = true;
            this.rbacRadioButton1.GroupUniqueID = "41505e22-aa89-4bb3-a698-60fc516b913d";
            this.rbacRadioButton1.Location = new System.Drawing.Point(354, 294);
            this.rbacRadioButton1.Name = "rbacRadioButton1";
            this.rbacRadioButton1.Size = new System.Drawing.Size(111, 17);
            this.rbacRadioButton1.TabIndex = 7;
            this.rbacRadioButton1.TabStop = true;
            this.rbacRadioButton1.Text = "rbacRadioButton1";
            this.rbacRadioButton1.UseVisualStyleBackColor = true;
            this.rbacRadioButton1.Click += new System.EventHandler(this.rbacRadioButton1_Click);
            // 
            // rbacMaskedTextBox1
            // 
            this.rbacMaskedTextBox1.GroupUniqueID = "cf23f9b5-0f6a-4502-85ea-577a3c8b423f";
            this.rbacMaskedTextBox1.Location = new System.Drawing.Point(209, 40);
            this.rbacMaskedTextBox1.Name = "rbacMaskedTextBox1";
            this.rbacMaskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.rbacMaskedTextBox1.TabIndex = 6;
            // 
            // rbacCombo1
            // 
            this.rbacCombo1.FormattingEnabled = true;
            this.rbacCombo1.GroupUniqueID = "7e8aceb0-4f54-4802-82ac-30b47a7bf6e0";
            this.rbacCombo1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.rbacCombo1.Location = new System.Drawing.Point(36, 132);
            this.rbacCombo1.Name = "rbacCombo1";
            this.rbacCombo1.Size = new System.Drawing.Size(121, 21);
            this.rbacCombo1.TabIndex = 5;
            this.rbacCombo1.SelectionChangeCommitted += new System.EventHandler(this.rbacCombo1_SelectionChangeCommitted);
            // 
            // rbacCheckBox1
            // 
            this.rbacCheckBox1.AutoSize = true;
            this.rbacCheckBox1.GroupUniqueID = "0511da01-ab76-4988-9ed4-a9382702d32f";
            this.rbacCheckBox1.Location = new System.Drawing.Point(246, 158);
            this.rbacCheckBox1.Name = "rbacCheckBox1";
            this.rbacCheckBox1.Size = new System.Drawing.Size(102, 17);
            this.rbacCheckBox1.TabIndex = 4;
            this.rbacCheckBox1.Text = "rbacCheckBox1";
            this.rbacCheckBox1.UseVisualStyleBackColor = true;
            this.rbacCheckBox1.Click += new System.EventHandler(this.rbacCheckBox1_Click);
            // 
            // rbacButton1
            // 
            this.rbacButton1.GroupUniqueID = "f22d5a14-11e3-495f-aecd-4c57c0154c2a";
            this.rbacButton1.Location = new System.Drawing.Point(246, 107);
            this.rbacButton1.Name = "rbacButton1";
            this.rbacButton1.Size = new System.Drawing.Size(75, 23);
            this.rbacButton1.TabIndex = 3;
            this.rbacButton1.Text = "rbacButton1";
            this.rbacButton1.UseVisualStyleBackColor = true;
            this.rbacButton1.Click += new System.EventHandler(this.rbacButton1_Click);
            // 
            // nKnightRadioButton2
            // 
            this.nKnightRadioButton2.AutoSize = true;
            this.nKnightRadioButton2.GroupUniqueID = "12345";
            this.nKnightRadioButton2.Location = new System.Drawing.Point(60, 368);
            this.nKnightRadioButton2.Name = "nKnightRadioButton2";
            this.nKnightRadioButton2.Size = new System.Drawing.Size(126, 17);
            this.nKnightRadioButton2.TabIndex = 25;
            this.nKnightRadioButton2.TabStop = true;
            this.nKnightRadioButton2.Text = "nKnightRadioButton2";
            this.nKnightRadioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 520);
            this.Controls.Add(this.nKnightRadioButton2);
            this.Controls.Add(this.nKnightTextBox1);
            this.Controls.Add(this.nKnightRadioButton1);
            this.Controls.Add(this.nKnightMaskedTextBox1);
            this.Controls.Add(this.nKnightLinkLabel1);
            this.Controls.Add(this.nKnightGridView1);
            this.Controls.Add(this.nKnightDateTimePicker1);
            this.Controls.Add(this.nKnightCombo1);
            this.Controls.Add(this.nKnightCheckListBox1);
            this.Controls.Add(this.nKnightCheckBox1);
            this.Controls.Add(this.nKnightButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbacLinkLabel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rbacCheckListBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.rbacTextBox1);
            this.Controls.Add(this.rbacRadioButton1);
            this.Controls.Add(this.rbacMaskedTextBox1);
            this.Controls.Add(this.rbacCombo1);
            this.Controls.Add(this.rbacCheckBox1);
            this.Controls.Add(this.rbacButton1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nKnightGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private nKnightButton rbacButton1;
        private nKnightCheckBox rbacCheckBox1;
        private nKnightCombo rbacCombo1;
        private nKnightMaskedTextBox rbacMaskedTextBox1;
        private nKnightRadioButton rbacRadioButton1;
        private nKnightTextBox rbacTextBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private nKnightCheckListBox rbacCheckListBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private nKnightLinkLabel rbacLinkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private nKnightButton nKnightButton1;
        private nKnightCheckBox nKnightCheckBox1;
        private nKnightCheckListBox nKnightCheckListBox1;
        private nKnightCombo nKnightCombo1;
        private nKnightDateTimePicker nKnightDateTimePicker1;
        private nKnightGridView nKnightGridView1;
        private nKnightLinkLabel nKnightLinkLabel1;
        private nKnightMaskedTextBox nKnightMaskedTextBox1;
        private nKnightRadioButton nKnightRadioButton1;
        private nKnightTextBox nKnightTextBox1;
        private nKnightRadioButton nKnightRadioButton2;
    }
}