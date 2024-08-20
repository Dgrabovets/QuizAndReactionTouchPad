namespace Quiz_ReactionToucpad
{
    partial class ReactionEntryForm
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
            this.components = new System.ComponentModel.Container();
            this.OptTimer = new System.Windows.Forms.Timer(this.components);
            this.WaitTimer = new System.Windows.Forms.Timer(this.components);
            this.WarningLabel = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.RR_5 = new System.Windows.Forms.PictureBox();
            this.RR_4 = new System.Windows.Forms.PictureBox();
            this.RR_3 = new System.Windows.Forms.PictureBox();
            this.RR_2 = new System.Windows.Forms.PictureBox();
            this.RR_1 = new System.Windows.Forms.PictureBox();
            this.RL_5 = new System.Windows.Forms.PictureBox();
            this.RL_4 = new System.Windows.Forms.PictureBox();
            this.RL_3 = new System.Windows.Forms.PictureBox();
            this.RL_2 = new System.Windows.Forms.PictureBox();
            this.RL_1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RR_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_1)).BeginInit();
            this.SuspendLayout();
            // 
            // OptTimer
            // 
            this.OptTimer.Interval = 60000;
            this.OptTimer.Tick += new System.EventHandler(this.OptTimer_Tick);
            // 
            // WaitTimer
            // 
            this.WaitTimer.Interval = 1000;
            this.WaitTimer.Tick += new System.EventHandler(this.WaitTimer_Tick);
            // 
            // WarningLabel
            // 
            this.WarningLabel.BackColor = System.Drawing.Color.Transparent;
            this.WarningLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WarningLabel.FlatAppearance.BorderSize = 0;
            this.WarningLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.WarningLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.WarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WarningLabel.ForeColor = System.Drawing.Color.White;
            this.WarningLabel.Location = new System.Drawing.Point(360, 312);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(1144, 352);
            this.WarningLabel.TabIndex = 0;
            this.WarningLabel.Text = "Когда светофор загорится зеленым, нажмите кратковременно на педаль газа одним пал" +
    "ьцем.\r\n\r\n";
            this.WarningLabel.UseVisualStyleBackColor = false;
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Transparent;
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextButton.ForeColor = System.Drawing.Color.White;
            this.NextButton.Location = new System.Drawing.Point(528, 704);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(808, 144);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Далее";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // RR_5
            // 
            this.RR_5.BackColor = System.Drawing.Color.Transparent;
            this.RR_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_5.Location = new System.Drawing.Point(1704, 889);
            this.RR_5.Name = "RR_5";
            this.RR_5.Size = new System.Drawing.Size(200, 100);
            this.RR_5.TabIndex = 35;
            this.RR_5.TabStop = false;
            // 
            // RR_4
            // 
            this.RR_4.BackColor = System.Drawing.Color.Transparent;
            this.RR_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_4.Location = new System.Drawing.Point(1704, 728);
            this.RR_4.Name = "RR_4";
            this.RR_4.Size = new System.Drawing.Size(200, 100);
            this.RR_4.TabIndex = 34;
            this.RR_4.TabStop = false;
            // 
            // RR_3
            // 
            this.RR_3.BackColor = System.Drawing.Color.Transparent;
            this.RR_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_3.Location = new System.Drawing.Point(1704, 568);
            this.RR_3.Name = "RR_3";
            this.RR_3.Size = new System.Drawing.Size(200, 100);
            this.RR_3.TabIndex = 33;
            this.RR_3.TabStop = false;
            // 
            // RR_2
            // 
            this.RR_2.BackColor = System.Drawing.Color.Transparent;
            this.RR_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_2.Location = new System.Drawing.Point(1704, 403);
            this.RR_2.Name = "RR_2";
            this.RR_2.Size = new System.Drawing.Size(200, 100);
            this.RR_2.TabIndex = 32;
            this.RR_2.TabStop = false;
            // 
            // RR_1
            // 
            this.RR_1.BackColor = System.Drawing.Color.Transparent;
            this.RR_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_1.Location = new System.Drawing.Point(1704, 232);
            this.RR_1.Name = "RR_1";
            this.RR_1.Size = new System.Drawing.Size(200, 100);
            this.RR_1.TabIndex = 31;
            this.RR_1.TabStop = false;
            // 
            // RL_5
            // 
            this.RL_5.BackColor = System.Drawing.Color.Transparent;
            this.RL_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_5.Location = new System.Drawing.Point(8, 889);
            this.RL_5.Name = "RL_5";
            this.RL_5.Size = new System.Drawing.Size(200, 100);
            this.RL_5.TabIndex = 30;
            this.RL_5.TabStop = false;
            // 
            // RL_4
            // 
            this.RL_4.BackColor = System.Drawing.Color.Transparent;
            this.RL_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_4.Location = new System.Drawing.Point(8, 728);
            this.RL_4.Name = "RL_4";
            this.RL_4.Size = new System.Drawing.Size(200, 100);
            this.RL_4.TabIndex = 29;
            this.RL_4.TabStop = false;
            // 
            // RL_3
            // 
            this.RL_3.BackColor = System.Drawing.Color.Transparent;
            this.RL_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_3.Location = new System.Drawing.Point(8, 568);
            this.RL_3.Name = "RL_3";
            this.RL_3.Size = new System.Drawing.Size(200, 100);
            this.RL_3.TabIndex = 28;
            this.RL_3.TabStop = false;
            // 
            // RL_2
            // 
            this.RL_2.BackColor = System.Drawing.Color.Transparent;
            this.RL_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_2.Location = new System.Drawing.Point(8, 403);
            this.RL_2.Name = "RL_2";
            this.RL_2.Size = new System.Drawing.Size(200, 100);
            this.RL_2.TabIndex = 27;
            this.RL_2.TabStop = false;
            // 
            // RL_1
            // 
            this.RL_1.BackColor = System.Drawing.Color.Transparent;
            this.RL_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_1.Location = new System.Drawing.Point(8, 232);
            this.RL_1.Name = "RL_1";
            this.RL_1.Size = new System.Drawing.Size(200, 100);
            this.RL_1.TabIndex = 26;
            this.RL_1.TabStop = false;
            // 
            // ReactionEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.RR_5);
            this.Controls.Add(this.RR_4);
            this.Controls.Add(this.RR_3);
            this.Controls.Add(this.RR_2);
            this.Controls.Add(this.RR_1);
            this.Controls.Add(this.RL_5);
            this.Controls.Add(this.RL_4);
            this.Controls.Add(this.RL_3);
            this.Controls.Add(this.RL_2);
            this.Controls.Add(this.RL_1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.WarningLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReactionEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReactionEntryForm";
            ((System.ComponentModel.ISupportInitialize)(this.RR_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RR_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RL_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer OptTimer;
        private System.Windows.Forms.Timer WaitTimer;
        private System.Windows.Forms.Button WarningLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.PictureBox RR_5;
        private System.Windows.Forms.PictureBox RR_4;
        private System.Windows.Forms.PictureBox RR_3;
        private System.Windows.Forms.PictureBox RR_2;
        private System.Windows.Forms.PictureBox RR_1;
        private System.Windows.Forms.PictureBox RL_5;
        private System.Windows.Forms.PictureBox RL_4;
        private System.Windows.Forms.PictureBox RL_3;
        private System.Windows.Forms.PictureBox RL_2;
        private System.Windows.Forms.PictureBox RL_1;
    }
}