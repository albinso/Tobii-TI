namespace TobiiGUI
{
    partial class SelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
            this.clickComboBox = new System.Windows.Forms.ComboBox();
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bleComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.scanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clickComboBox
            // 
            this.clickComboBox.FormattingEnabled = true;
            this.clickComboBox.Location = new System.Drawing.Point(575, 46);
            this.clickComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.clickComboBox.Name = "clickComboBox";
            this.clickComboBox.Size = new System.Drawing.Size(227, 24);
            this.clickComboBox.TabIndex = 0;
            this.clickComboBox.SelectedIndexChanged += new System.EventHandler(this.clickComboBox_SelectedIndexChanged);
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(575, 110);
            this.deviceComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(227, 24);
            this.deviceComboBox.TabIndex = 1;
            this.deviceComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceCombox_SelectedIndexChanged);
            // 
            // functionComboBox
            // 
            this.functionComboBox.FormattingEnabled = true;
            this.functionComboBox.Location = new System.Drawing.Point(575, 167);
            this.functionComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(227, 24);
            this.functionComboBox.TabIndex = 2;
            this.functionComboBox.SelectedIndexChanged += new System.EventHandler(this.functionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(572, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "1. Click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(572, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(572, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. Function";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(637, 211);
            this.commitButton.Margin = new System.Windows.Forms.Padding(2);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(98, 31);
            this.commitButton.TabIndex = 6;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // bleComboBox
            // 
            this.bleComboBox.FormattingEnabled = true;
            this.bleComboBox.Location = new System.Drawing.Point(27, 122);
            this.bleComboBox.Name = "bleComboBox";
            this.bleComboBox.Size = new System.Drawing.Size(234, 24);
            this.bleComboBox.TabIndex = 7;
            this.bleComboBox.SelectedIndexChanged += new System.EventHandler(this.bleComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(89, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "BLE Button";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(330, 211);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(181, 11);
            this.progressBar.TabIndex = 9;
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(94, 152);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(98, 30);
            this.scanButton.TabIndex = 10;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TobiiGUI.Properties.Resources.bg_red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 253);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bleComboBox);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.functionComboBox);
            this.Controls.Add(this.deviceComboBox);
            this.Controls.Add(this.clickComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SelectionForm";
            this.Text = "BLE Manager";
            this.Load += new System.EventHandler(this.SelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clickComboBox;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox bleComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button scanButton;

    }
}

