
namespace CalculatorProject
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
            this.button2 = new System.Windows.Forms.Button();
            this.calculatorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrchid;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(96, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "K-MAP";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOrchid;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Location = new System.Drawing.Point(71, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quine-McCluskey";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // calculatorLabel
            // 
            this.calculatorLabel.AutoSize = true;
            this.calculatorLabel.BackColor = System.Drawing.Color.LightCyan;
            this.calculatorLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorLabel.ForeColor = System.Drawing.Color.Navy;
            this.calculatorLabel.Image = global::CalculatorProject.Properties.Resources.kisspng_computer_icons_calculator_cover_letter_font_calculator_icon_transparent_5b5ea8ace7c980_2488905815329302209494;
            this.calculatorLabel.Location = new System.Drawing.Point(165, 60);
            this.calculatorLabel.Name = "calculatorLabel";
            this.calculatorLabel.Size = new System.Drawing.Size(0, 38);
            this.calculatorLabel.TabIndex = 2;
            this.calculatorLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.calculatorLabel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(249, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 300);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label2.Location = new System.Drawing.Point(89, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "CALCULATOR";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::CalculatorProject.Properties.Resources.aesthetic_city_wallpaper_1024x768_wallpaper;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kmapButton;
        private System.Windows.Forms.Button quineButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label calculatorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}

