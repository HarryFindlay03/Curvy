namespace NEA_V1
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
            this.txtBox_input1 = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.txt_xRange = new System.Windows.Forms.TextBox();
            this.txt_yRange = new System.Windows.Forms.TextBox();
            this.lbl_MousePos = new System.Windows.Forms.Label();
            this.btn_integrate = new System.Windows.Forms.Button();
            this.txt_lim1 = new System.Windows.Forms.TextBox();
            this.txt_lim2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBox_input1
            // 
            this.txtBox_input1.Location = new System.Drawing.Point(12, 12);
            this.txtBox_input1.Name = "txtBox_input1";
            this.txtBox_input1.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input1.TabIndex = 0;
            this.txtBox_input1.Text = "x^2";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(12, 38);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 2;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // txt_xRange
            // 
            this.txt_xRange.Location = new System.Drawing.Point(118, 12);
            this.txt_xRange.Name = "txt_xRange";
            this.txt_xRange.Size = new System.Drawing.Size(30, 20);
            this.txt_xRange.TabIndex = 3;
            this.txt_xRange.Text = "1000";
            // 
            // txt_yRange
            // 
            this.txt_yRange.Location = new System.Drawing.Point(154, 12);
            this.txt_yRange.Name = "txt_yRange";
            this.txt_yRange.Size = new System.Drawing.Size(29, 20);
            this.txt_yRange.TabIndex = 4;
            this.txt_yRange.Text = "1000";
            // 
            // lbl_MousePos
            // 
            this.lbl_MousePos.AutoSize = true;
            this.lbl_MousePos.Location = new System.Drawing.Point(9, 739);
            this.lbl_MousePos.Name = "lbl_MousePos";
            this.lbl_MousePos.Size = new System.Drawing.Size(57, 13);
            this.lbl_MousePos.TabIndex = 5;
            this.lbl_MousePos.Text = "MousePos";
            // 
            // btn_integrate
            // 
            this.btn_integrate.Location = new System.Drawing.Point(12, 76);
            this.btn_integrate.Name = "btn_integrate";
            this.btn_integrate.Size = new System.Drawing.Size(75, 23);
            this.btn_integrate.TabIndex = 10;
            this.btn_integrate.Text = "Integrate";
            this.btn_integrate.UseVisualStyleBackColor = true;
            this.btn_integrate.Click += new System.EventHandler(this.btn_integrate_Click);
            // 
            // txt_lim1
            // 
            this.txt_lim1.Location = new System.Drawing.Point(93, 79);
            this.txt_lim1.Name = "txt_lim1";
            this.txt_lim1.Size = new System.Drawing.Size(29, 20);
            this.txt_lim1.TabIndex = 11;
            // 
            // txt_lim2
            // 
            this.txt_lim2.Location = new System.Drawing.Point(128, 79);
            this.txt_lim2.Name = "txt_lim2";
            this.txt_lim2.Size = new System.Drawing.Size(29, 20);
            this.txt_lim2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.txt_lim2);
            this.Controls.Add(this.txt_lim1);
            this.Controls.Add(this.btn_integrate);
            this.Controls.Add(this.lbl_MousePos);
            this.Controls.Add(this.txt_yRange);
            this.Controls.Add(this.txt_xRange);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txtBox_input1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_input1;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox txt_xRange;
        private System.Windows.Forms.TextBox txt_yRange;
        private System.Windows.Forms.Label lbl_MousePos;
        private System.Windows.Forms.Button btn_integrate;
        private System.Windows.Forms.TextBox txt_lim1;
        private System.Windows.Forms.TextBox txt_lim2;
    }
}

