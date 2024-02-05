namespace WindowsFormsApp2
{
    partial class TournamentMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentMenu));
            this.playerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.players_label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.casualRadioButton = new System.Windows.Forms.RadioButton();
            this.hardcoreRadioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // playerTextBox
            // 
            this.playerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTextBox.Location = new System.Drawing.Point(151, 49);
            this.playerTextBox.Name = "playerTextBox";
            this.playerTextBox.Size = new System.Drawing.Size(205, 26);
            this.playerTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Player:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Sitka Small", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(322, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, -6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tournament";
            // 
            // players_label
            // 
            this.players_label.AutoSize = true;
            this.players_label.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.players_label.Location = new System.Drawing.Point(12, 83);
            this.players_label.MaximumSize = new System.Drawing.Size(400, 140);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(64, 28);
            this.players_label.TabIndex = 4;
            this.players_label.Text = "None";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(397, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 59);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(317, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 59);
            this.button3.TabIndex = 6;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPlayerButton.Location = new System.Drawing.Point(362, 49);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(107, 26);
            this.addPlayerButton.TabIndex = 7;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gamemode:";
            // 
            // casualRadioButton
            // 
            this.casualRadioButton.AutoSize = true;
            this.casualRadioButton.Checked = true;
            this.casualRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casualRadioButton.Location = new System.Drawing.Point(161, 238);
            this.casualRadioButton.Name = "casualRadioButton";
            this.casualRadioButton.Size = new System.Drawing.Size(73, 20);
            this.casualRadioButton.TabIndex = 10;
            this.casualRadioButton.TabStop = true;
            this.casualRadioButton.Text = "Casual";
            this.casualRadioButton.UseVisualStyleBackColor = true;
            // 
            // hardcoreRadioButton1
            // 
            this.hardcoreRadioButton1.AutoSize = true;
            this.hardcoreRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardcoreRadioButton1.Location = new System.Drawing.Point(240, 239);
            this.hardcoreRadioButton1.Name = "hardcoreRadioButton1";
            this.hardcoreRadioButton1.Size = new System.Drawing.Size(90, 20);
            this.hardcoreRadioButton1.TabIndex = 11;
            this.hardcoreRadioButton1.Text = "Hardcore";
            this.hardcoreRadioButton1.UseVisualStyleBackColor = true;
            // 
            // TournamentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(481, 319);
            this.Controls.Add(this.hardcoreRadioButton1);
            this.Controls.Add(this.casualRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TournamentMenu";
            this.Text = "Tournament Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label players_label;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton casualRadioButton;
        private System.Windows.Forms.RadioButton hardcoreRadioButton1;
    }
}