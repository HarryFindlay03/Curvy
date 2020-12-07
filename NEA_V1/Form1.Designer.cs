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
            this.txtBox_input = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.txt_xRange = new System.Windows.Forms.TextBox();
            this.txt_yRange = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_input
            // 
            this.txtBox_input.Location = new System.Drawing.Point(12, 12);
            this.txtBox_input.Name = "txtBox_input";
            this.txtBox_input.Size = new System.Drawing.Size(100, 20);
            this.txtBox_input.TabIndex = 0;
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
            this.txt_xRange.Location = new System.Drawing.Point(147, 12);
            this.txt_xRange.Name = "txt_xRange";
            this.txt_xRange.Size = new System.Drawing.Size(22, 20);
            this.txt_xRange.TabIndex = 3;
            this.txt_xRange.Text = "100";
            // 
            // txt_yRange
            // 
            this.txt_yRange.Location = new System.Drawing.Point(175, 12);
            this.txt_yRange.Name = "txt_yRange";
            this.txt_yRange.Size = new System.Drawing.Size(22, 20);
            this.txt_yRange.TabIndex = 4;
            this.txt_yRange.Text = "100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(212, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 426);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_yRange);
            this.Controls.Add(this.txt_xRange);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txtBox_input);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_input;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox txt_xRange;
        private System.Windows.Forms.TextBox txt_yRange;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

