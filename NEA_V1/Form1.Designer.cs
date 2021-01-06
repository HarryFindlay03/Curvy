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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBox_input2 = new System.Windows.Forms.TextBox();
            this.txtBox_input3 = new System.Windows.Forms.TextBox();
            this.txtBox_input4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_input1
            // 
            this.txtBox_input1.Location = new System.Drawing.Point(12, 12);
            this.txtBox_input1.Name = "txtBox_input1";
            this.txtBox_input1.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input1.TabIndex = 0;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(12, 116);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 2;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // txt_xRange
            // 
            this.txt_xRange.Location = new System.Drawing.Point(139, 12);
            this.txt_xRange.Name = "txt_xRange";
            this.txt_xRange.Size = new System.Drawing.Size(30, 20);
            this.txt_xRange.TabIndex = 3;
            this.txt_xRange.Text = "1000";
            // 
            // txt_yRange
            // 
            this.txt_yRange.Location = new System.Drawing.Point(175, 12);
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
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(224, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(948, 740);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtBox_input2
            // 
            this.txtBox_input2.Location = new System.Drawing.Point(12, 38);
            this.txtBox_input2.Name = "txtBox_input2";
            this.txtBox_input2.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input2.TabIndex = 7;
            // 
            // txtBox_input3
            // 
            this.txtBox_input3.Location = new System.Drawing.Point(12, 64);
            this.txtBox_input3.Name = "txtBox_input3";
            this.txtBox_input3.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input3.TabIndex = 8;
            // 
            // txtBox_input4
            // 
            this.txtBox_input4.Location = new System.Drawing.Point(12, 90);
            this.txtBox_input4.Name = "txtBox_input4";
            this.txtBox_input4.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.txtBox_input4);
            this.Controls.Add(this.txtBox_input3);
            this.Controls.Add(this.txtBox_input2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_MousePos);
            this.Controls.Add(this.txt_yRange);
            this.Controls.Add(this.txt_xRange);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txtBox_input1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_input1;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox txt_xRange;
        private System.Windows.Forms.TextBox txt_yRange;
        private System.Windows.Forms.Label lbl_MousePos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBox_input2;
        private System.Windows.Forms.TextBox txtBox_input3;
        private System.Windows.Forms.TextBox txtBox_input4;
    }
}

