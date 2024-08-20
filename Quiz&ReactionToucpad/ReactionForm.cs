using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
//using static System.Net.Mime.MediaTypeNames;

namespace Quiz_ReactionToucpad
{
    public partial class ReactionForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public ReactionForm(int globalQuestionIndexE, int globalQuestionIndexH)
        {
            InitializeComponent();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            WaitTimer.Start();
            OptTimer.Start();

            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Tap_gas.png");

            Blue = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb0.png");
            Red = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb1.png");

            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL"))
                {
                    control.BackgroundImage = Blue;
                    control.Parent = this;
                }
            }

            RegularTimer.Start();
            InvertRombsVisibility(1);

            QuitButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Knowledge0_1.png");
            PedalButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Gas0.png");
            RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again0.png");

            font.AddFontFile("C:\\Quiz&Reaction\\ProgramResources\\Fonts\\Oswald-Bold.ttf");

            MLabel.Font = new Font(font.Families[0], 100);
            ResultTextLabel.Font = new Font(font.Families[0], 40);
            ResultLabel.Font = new Font(font.Families[0], 80);
            this.globalQuestionIndexE = globalQuestionIndexE;
            this.globalQuestionIndexH = globalQuestionIndexH;
        }

        #region Global Variables
        int globalQuestionIndexE, globalQuestionIndexH;

        int PedalEnabled = 0;
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        int CheckFlag = 0;
        System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource();
        System.Threading.Thread thread;
        int WaitingSecondsCount = 0;
        Stopwatch stopwatch = new Stopwatch();
        int backgroundCount = 1;

        Image Blue, Red;
        PrivateFontCollection font = new PrivateFontCollection();
        int number = 1;
        int enableSwitch = 0;
        #endregion

        public void DrawCircle(int ColorFlag)
        {
            switch (ColorFlag)
            {
                case 0:
                    RoadLightPictureBox.Image = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Images\\2.png");
                    break;
                case 1:
                    RoadLightPictureBox.Image = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Images\\4.png");
                    break;
                case 2:
                    RoadLightPictureBox.Image = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Images\\5.png");
                    break;
                case 3:
                    RoadLightPictureBox.Image = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Images\\3.png");
                    break;
            }
        }

        private void ReactionForm_Load(object sender, EventArgs e)
        {
            DrawCircle(0);
            StartButtonHelper();
        }

        public string CheckBestResult(string M, string S, string F)
        {
            using (StreamReader reader = new StreamReader("C:\\Quiz&Reaction\\ReactionBestResult.txt"))
            {
                string line = reader.ReadToEnd();
                reader.Close();
                if (line == "" || line == " " || line == null)
                {
                    using (StreamWriter writer = new StreamWriter("C:\\Quiz&Reaction\\ReactionBestResult.txt", false))
                    {
                        writer.WriteLine($"{M}.{S}.{F}");
                    }

                    wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Win.mp3";
                    wplayer.controls.play();

                    return $"Новый рекорд -_{M}.{S}.{F}";
                }
                else
                {
                    int[] values = Array.ConvertAll(line.Split('.'), delegate (string s) { return int.Parse(s); });

                    if (
                        (values[0] == 0 && int.Parse(M) == 0 && values[1] == 0 && int.Parse(S) == 0 && int.Parse(F) < values[2]) ||
                        (values[0] == 0 && int.Parse(M) == 0 && values[1] != 0 && int.Parse(S) < values[1]) ||
                        (values[0] != 0 && int.Parse(M) < values[0]) 
                       )
                    {
                        using (StreamWriter writer = new StreamWriter("C:\\Quiz&Reaction\\ReactionBestResult.txt", false))
                        {
                            writer.WriteLine($"{M}.{S}.{F}");
                        }

                        wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Win.mp3";
                        wplayer.controls.play();

                        return $"Новый рекорд -_{M}.{S}.{F}";
                    }
                    else
                    {
                        wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Lose.mp3";
                        wplayer.controls.play();

                        return $"Лучший результат -_{line.Split('.')[0]}.{line.Split('.')[1]}.{line.Split('.')[2]}";
                    }
                }
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;

                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int QuitButtonLocation = QuitButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 20;
                int count = 0;

                borderTimer.Tick += new EventHandler(async (o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        QuitButton.Location = new Point(QuitButton.Location.X + 2, QuitButton.Location.Y);
                    }
                    else
                    {
                        QuitButton.Location = new Point(QuitButton.Location.X - 2, QuitButton.Location.Y);
                    }
                    if (QuitButton.Location.X == QuitButtonLocation)
                    {
                        borderTimer.Stop();
                        QuitButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Knowledge0_1.png");

                        await Task.Run(async () =>
                        {
                            thread = new System.Threading.Thread(OpenOpenningForm);
                            thread.SetApartmentState(System.Threading.ApartmentState.STA);
                            thread.Start();
                        });

                        await Task.Delay(500);

                        this.Close();
                    }
                });

                QuitButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Exit1_1.png");
                borderTimer.Start();
            }
        }

        public void OpenOpenningForm(object obj)
        {
            System.Windows.Forms.Application.Run(new OpenningForm(1, globalQuestionIndexE, globalQuestionIndexH));
        }

        private void OptTimer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            WaitingSecondsCount++;

            if (WaitingSecondsCount == 300)
            {
                this.Close();
                thread = new System.Threading.Thread(OpenOpenningForm);
                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();

                WaitTimer.Stop();
            }
        }

        private async void StartButtonHelper()
        {
            QuitButton.Visible = false;
            await System.Threading.Tasks.Task.Delay(400, cancellationTokenSource.Token);

            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Tap_gas.png");

            MLabel.Font = new Font(font.Families[0], 100);
            MLabel.Text = "00.00.00";

            RoadLightPictureBox.Visible = true;
            MLabel.Visible = true;
            MLabel.Location = new Point(1275, -13);

            QuitButton.Visible = false;

            ResultTextLabel.Visible = false;
            ResultLabel.Visible = false;

            PedalButton.Visible = true;

            Random rnd = new Random();


            DrawCircle(3);
            wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\TrafficLightSoundShort.mp3";
            wplayer.controls.play();

            int delay = rnd.Next(3, 4) * 1000;
            CheckFlag = 0;

            try
            {
                CheckFlag = 1;
                await System.Threading.Tasks.Task.Delay(delay, cancellationTokenSource.Token);
                DrawCircle(1);
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\TrafficLightSoundShort.mp3";
                wplayer.controls.play();
                await System.Threading.Tasks.Task.Delay(rnd.Next(3, 7) * 1000, cancellationTokenSource.Token);
                CheckFlag = 0;

                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\TrafficLightSoundLong.mp3";
                wplayer.controls.play();

                DrawCircle(2);

                ReactionTimer.Tick += new EventHandler((obj, evv) =>
                {
                    MLabel.Text = stopwatch.Elapsed.ToString("mm\\.ss\\.ff");
                });

                stopwatch = new Stopwatch();

                ReactionTimer.Start();
                stopwatch.Start();
            }
            catch (OperationCanceledException)
            {

            }
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;

                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int RetryButtonLocation = RetryButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 10;
                int count = 0;

                borderTimer.Tick += new EventHandler((o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        RetryButton.Location = new Point(RetryButton.Location.X - 2, RetryButton.Location.Y);
                    }
                    else
                    {
                        RetryButton.Location = new Point(RetryButton.Location.X + 2, RetryButton.Location.Y);
                    }
                    if (RetryButton.Location.X == RetryButtonLocation)
                    {
                        enableSwitch = 0;
                        RegularTimer.Start();
                        OddTimer.Stop();
                        borderTimer.Stop();
                        RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again0.png");

                        RetryButton.Visible = false;

                        StartButtonHelper();
                        InvertRombsVisibility(1);
                    }
                });

                RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again1.png");
                borderTimer.Start();
            }
        }

        private void RegularTimer_Tick(object sender, EventArgs e)
        {
            if (backgroundCount <= 5)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL"))
                    {
                        control.BackgroundImage = Blue;
                        if (control.Name == $"RR_{backgroundCount}" || control.Name == $"RL_{backgroundCount}")
                        {
                            control.BackgroundImage = Red;
                        }
                    }
                }

                backgroundCount++;
            }
            else { backgroundCount = 1; }
        }

        private void OddTimer_Tick(object sender, EventArgs e)
        {
            if (number == 1)
            {
                RL_1.BackgroundImage = Blue;
                RL_2.BackgroundImage = Red;
                RL_3.BackgroundImage = Blue;
                RL_4.BackgroundImage = Red;
                RL_5.BackgroundImage = Blue;

                RR_1.BackgroundImage = Red;
                RR_2.BackgroundImage = Blue;
                RR_3.BackgroundImage = Red;
                RR_4.BackgroundImage = Blue;
                RR_5.BackgroundImage = Red;

                number++;
            }
            else
            {
                RL_1.BackgroundImage = Red;
                RL_2.BackgroundImage = Blue;
                RL_3.BackgroundImage = Red;
                RL_4.BackgroundImage = Blue;
                RL_5.BackgroundImage = Red;

                RR_1.BackgroundImage = Blue;
                RR_2.BackgroundImage = Red;
                RR_3.BackgroundImage = Blue;
                RR_4.BackgroundImage = Red;
                RR_5.BackgroundImage = Blue;

                number = 1;
            }
        }

        public void InvertRombsVisibility(int flag)
        {
            switch (flag)
            {
                case 1:

                    foreach (Control control in this.Controls)
                    {
                        if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL")) { control.Visible = false; }
                    }

                    break;
                case 2:

                    foreach (Control control in this.Controls)
                    {
                        if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL")) { control.Visible = true; }
                    }

                    break;
            }
        }

        private void PedalButton_Click(object sender, EventArgs e)
        {
            wplayer = new WindowsMediaPlayer();
            wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
            wplayer.controls.play();

            if (PedalEnabled == 0)
            {
                int PedalButtonLocation = PedalButton.Location.X;
                Timer PedalTimer = new Timer();
                PedalTimer.Interval = 1;
                int borderCount = 0;
                PedalEnabled = 1;
                PedalTimer.Tick += new EventHandler((o, ev) =>
                {
                    borderCount++;
                    if (borderCount < 10)
                    {
                        PedalButton.Size = new Size(PedalButton.Width - 2, PedalButton.Height - 2);
                        PedalButton.Location = new Point(PedalButton.Location.X + 1, PedalButton.Location.Y + 1);
                    }
                    else
                    {
                        PedalButton.Size = new Size(PedalButton.Width + 2, PedalButton.Height + 2);
                        PedalButton.Location = new Point(PedalButton.Location.X - 1, PedalButton.Location.Y - 1);
                    }
                    if (PedalButton.Location.X == PedalButtonLocation)
                    {
                        PedalButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Gas0.png");

                        WaitingSecondsCount = 0;

                        InvertRombsVisibility(2);

                        if (CheckFlag == 0)
                        {
                            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Result.png");

                            PedalButton.Visible = false;

                            ReactionTimer.Stop();
                            stopwatch.Stop();

                            QuitButton.Visible = true;

                            QuitButton.Location = new Point(12, 968);
                            MLabel.Location = new Point(680, 586);

                            RetryButton.Location = new Point(1423, 918);
                            RetryButton.Visible = true;

                            ResultLabel.Location = new Point(680, 821);
                            ResultTextLabel.Location = new Point(665, 739);

                            RoadLightPictureBox.Visible = false;

                            ResultLabel.Visible = true;
                            TimeSpan timeSpan = stopwatch.Elapsed;
                            string[] time = timeSpan.ToString("mm\\.ss\\.ff").Split('.');
                            MLabel.Font = new Font(font.Families[0], 80);
                            MLabel.Text = timeSpan.ToString("mm\\.ss\\.ff");
                            string[] result = CheckBestResult(time[0], time[1], time[2]).Split('_');
                            ResultLabel.Text = result[1];

                            ResultTextLabel.Visible = true;
                        }
                        else
                        {
                            cancellationTokenSource.Cancel();
                            cancellationTokenSource.Dispose();
                            cancellationTokenSource = new System.Threading.CancellationTokenSource();
                            PedalButton.Visible = false;

                            System.Threading.Thread.Sleep(100);
                            wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Lose.mp3";
                            wplayer.controls.play();

                            RegularTimer.Stop();
                            OddTimer.Start();


                            RoadLightPictureBox.Visible = false;

                            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Falsh.png");

                            QuitButton.Visible = true;

                            RetryButton.Location = new Point(699, 474);

                            RetryButton.Visible = true;

                            QuitButton.Location = new Point(772, 656);

                            MLabel.Visible = false;
                        }
                        PedalTimer.Stop();

                        PedalEnabled = 0;
                    }
                });

                PedalButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Gas1.png");
                PedalTimer.Start();
            }
        }
    }
}
