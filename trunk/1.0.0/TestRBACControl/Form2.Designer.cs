using nKnight.RBACControl;
namespace TestRBACControl
{
    partial class Form2
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
            this.rbacButton2 = new nKnightButton();
            this.rbacButton1 = new nKnightButton();
            this.SuspendLayout();
            // 
            // rbacButton2
            // 
            this.rbacButton2.GroupUniqueID = "4aaf5984-db44-4303-8037-817401321992";
            this.rbacButton2.Location = new System.Drawing.Point(125, 72);
            this.rbacButton2.Name = "rbacButton2";
            this.rbacButton2.Size = new System.Drawing.Size(75, 23);
            this.rbacButton2.TabIndex = 1;
            this.rbacButton2.Text = "rbacButton2";
            this.rbacButton2.UseVisualStyleBackColor = true;
            // 
            // rbacButton1
            // 
            this.rbacButton1.GroupUniqueID = "c42e5e96-6cff-418a-b14a-87a4d738fd3c";
            this.rbacButton1.Location = new System.Drawing.Point(172, 147);
            this.rbacButton1.Name = "rbacButton1";
            this.rbacButton1.Size = new System.Drawing.Size(75, 23);
            this.rbacButton1.TabIndex = 0;
            this.rbacButton1.Text = "rbacButton1";
            this.rbacButton1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 540);
            this.Controls.Add(this.rbacButton2);
            this.Controls.Add(this.rbacButton1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private nKnightButton rbacButton1;
        private nKnightButton rbacButton2;
    }
}