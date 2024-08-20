namespace Quiz_ReactionToucpad
{
    partial class ReactionForm
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
            this.ReactionTimer = new System.Windows.Forms.Timer(this.components);
            this.MLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.WaitTimer = new System.Windows.Forms.Timer(this.components);
            this.OptTimer = new System.Windows.Forms.Timer(this.components);
            this.PedalButton = new System.Windows.Forms.PictureBox();
            this.RoadLightPictureBox = new System.Windows.Forms.PictureBox();
            this.ResultTextLabel = new System.Windows.Forms.Label();
            this.RetryButton = new System.Windows.Forms.Button();
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
            this.RegularTimer = new System.Windows.Forms.Timer(this.components);
            this.OddTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PedalButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadLightPictureBox)).BeginInit();
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
            // ReactionTimer
            // 
            this.ReactionTimer.Interval = 1;
            // 
            // MLabel
            // 
            this.MLabel.AutoSize = true;
            this.MLabel.BackColor = System.Drawing.Color.Transparent;
            this.MLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MLabel.ForeColor = System.Drawing.Color.White;
            this.MLabel.Location = new System.Drawing.Point(1275, -13);
            this.MLabel.Name = "MLabel";
            this.MLabel.Size = new System.Drawing.Size(589, 153);
            this.MLabel.TabIndex = 7;
            this.MLabel.Text = "00.00.00";
            this.MLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.ForeColor = System.Drawing.Color.White;
            this.ResultLabel.Location = new System.Drawing.Point(1160, 344);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(292, 76);
            this.ResultLabel.TabIndex = 24;
            this.ResultLabel.Text = "00.00.00";
            this.ResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ResultLabel.Visible = false;
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.Transparent;
            this.QuitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuitButton.Location = new System.Drawing.Point(12, 968);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(300, 100);
            this.QuitButton.TabIndex = 27;
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // WaitTimer
            // 
            this.WaitTimer.Interval = 1000;
            this.WaitTimer.Tick += new System.EventHandler(this.WaitTimer_Tick);
            // 
            // OptTimer
            // 
            this.OptTimer.Interval = 60000;
            this.OptTimer.Tick += new System.EventHandler(this.OptTimer_Tick);
            // 
            // PedalButton
            // 
            this.PedalButton.BackColor = System.Drawing.Color.Transparent;
            this.PedalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PedalButton.Location = new System.Drawing.Point(1339, 423);
            this.PedalButton.Name = "PedalButton";
            this.PedalButton.Size = new System.Drawing.Size(447, 596);
            this.PedalButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PedalButton.TabIndex = 28;
            this.PedalButton.TabStop = false;
            this.PedalButton.Click += new System.EventHandler(this.PedalButton_Click);
            // 
            // RoadLightPictureBox
            // 
            this.RoadLightPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.RoadLightPictureBox.Location = new System.Drawing.Point(604, 423);
            this.RoadLightPictureBox.Name = "RoadLightPictureBox";
            this.RoadLightPictureBox.Size = new System.Drawing.Size(619, 596);
            this.RoadLightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RoadLightPictureBox.TabIndex = 0;
            this.RoadLightPictureBox.TabStop = false;
            // 
            // ResultTextLabel
            // 
            this.ResultTextLabel.AutoSize = true;
            this.ResultTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResultTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ResultTextLabel.Location = new System.Drawing.Point(512, 344);
            this.ResultTextLabel.Name = "ResultTextLabel";
            this.ResultTextLabel.Size = new System.Drawing.Size(628, 76);
            this.ResultTextLabel.TabIndex = 25;
            this.ResultTextLabel.Text = "Лучший результат:";
            this.ResultTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ResultTextLabel.Visible = false;
            // 
            // RetryButton
            // 
            this.RetryButton.BackColor = System.Drawing.Color.Transparent;
            this.RetryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RetryButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.RetryButton.FlatAppearance.BorderSize = 0;
            this.RetryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RetryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RetryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RetryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RetryButton.ForeColor = System.Drawing.Color.Black;
            this.RetryButton.Location = new System.Drawing.Point(699, 474);
            this.RetryButton.Name = "RetryButton";
            this.RetryButton.Size = new System.Drawing.Size(485, 150);
            this.RetryButton.TabIndex = 54;
            this.RetryButton.UseVisualStyleBackColor = false;
            this.RetryButton.Visible = false;
            this.RetryButton.Click += new System.EventHandler(this.RetryButton_Click);
            // 
            // RR_5
            // 
            this.RR_5.BackColor = System.Drawing.Color.Transparent;
            this.RR_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_5.Location = new System.Drawing.Point(1708, 805);
            this.RR_5.Name = "RR_5";
            this.RR_5.Size = new System.Drawing.Size(200, 100);
            this.RR_5.TabIndex = 64;
            this.RR_5.TabStop = false;
            // 
            // RR_4
            // 
            this.RR_4.BackColor = System.Drawing.Color.Transparent;
            this.RR_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_4.Location = new System.Drawing.Point(1708, 644);
            this.RR_4.Name = "RR_4";
            this.RR_4.Size = new System.Drawing.Size(200, 100);
            this.RR_4.TabIndex = 63;
            this.RR_4.TabStop = false;
            // 
            // RR_3
            // 
            this.RR_3.BackColor = System.Drawing.Color.Transparent;
            this.RR_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_3.Location = new System.Drawing.Point(1708, 484);
            this.RR_3.Name = "RR_3";
            this.RR_3.Size = new System.Drawing.Size(200, 100);
            this.RR_3.TabIndex = 62;
            this.RR_3.TabStop = false;
            // 
            // RR_2
            // 
            this.RR_2.BackColor = System.Drawing.Color.Transparent;
            this.RR_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_2.Location = new System.Drawing.Point(1708, 319);
            this.RR_2.Name = "RR_2";
            this.RR_2.Size = new System.Drawing.Size(200, 100);
            this.RR_2.TabIndex = 61;
            this.RR_2.TabStop = false;
            // 
            // RR_1
            // 
            this.RR_1.BackColor = System.Drawing.Color.Transparent;
            this.RR_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RR_1.Location = new System.Drawing.Point(1708, 148);
            this.RR_1.Name = "RR_1";
            this.RR_1.Size = new System.Drawing.Size(200, 100);
            this.RR_1.TabIndex = 60;
            this.RR_1.TabStop = false;
            // 
            // RL_5
            // 
            this.RL_5.BackColor = System.Drawing.Color.Transparent;
            this.RL_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_5.Location = new System.Drawing.Point(12, 805);
            this.RL_5.Name = "RL_5";
            this.RL_5.Size = new System.Drawing.Size(200, 100);
            this.RL_5.TabIndex = 59;
            this.RL_5.TabStop = false;
            // 
            // RL_4
            // 
            this.RL_4.BackColor = System.Drawing.Color.Transparent;
            this.RL_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_4.Location = new System.Drawing.Point(12, 644);
            this.RL_4.Name = "RL_4";
            this.RL_4.Size = new System.Drawing.Size(200, 100);
            this.RL_4.TabIndex = 58;
            this.RL_4.TabStop = false;
            // 
            // RL_3
            // 
            this.RL_3.BackColor = System.Drawing.Color.Transparent;
            this.RL_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_3.Location = new System.Drawing.Point(12, 484);
            this.RL_3.Name = "RL_3";
            this.RL_3.Size = new System.Drawing.Size(200, 100);
            this.RL_3.TabIndex = 57;
            this.RL_3.TabStop = false;
            // 
            // RL_2
            // 
            this.RL_2.BackColor = System.Drawing.Color.Transparent;
            this.RL_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_2.Location = new System.Drawing.Point(12, 319);
            this.RL_2.Name = "RL_2";
            this.RL_2.Size = new System.Drawing.Size(200, 100);
            this.RL_2.TabIndex = 56;
            this.RL_2.TabStop = false;
            // 
            // RL_1
            // 
            this.RL_1.BackColor = System.Drawing.Color.Transparent;
            this.RL_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RL_1.Location = new System.Drawing.Point(12, 148);
            this.RL_1.Name = "RL_1";
            this.RL_1.Size = new System.Drawing.Size(200, 100);
            this.RL_1.TabIndex = 55;
            this.RL_1.TabStop = false;
            // 
            // RegularTimer
            // 
            this.RegularTimer.Interval = 300;
            this.RegularTimer.Tick += new System.EventHandler(this.RegularTimer_Tick);
            // 
            // OddTimer
            // 
            this.OddTimer.Interval = 300;
            this.OddTimer.Tick += new System.EventHandler(this.OddTimer_Tick);
            // 
            // ReactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.Controls.Add(this.RetryButton);
            this.Controls.Add(this.PedalButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ResultTextLabel);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.MLabel);
            this.Controls.Add(this.RoadLightPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReactionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ReactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PedalButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadLightPictureBox)).EndInit();
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ReactionTimer;
        private System.Windows.Forms.Label MLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Timer WaitTimer;
        private System.Windows.Forms.Timer OptTimer;
        private System.Windows.Forms.PictureBox PedalButton;
        private System.Windows.Forms.PictureBox RoadLightPictureBox;
        private System.Windows.Forms.Label ResultTextLabel;
        private System.Windows.Forms.Button RetryButton;
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
        private System.Windows.Forms.Timer RegularTimer;
        private System.Windows.Forms.Timer OddTimer;
    }
}