using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Quiz_ReactionToucpad
{
    public partial class ReactionEntryForm : Form
    {
        #region Global Variables
        int WaitingSecondsCount;
        System.Threading.Thread thread;
        Image Blue, Red;
        int backgroundCount = 1;
        int enableSwitch = 0;
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        PrivateFontCollection font = new PrivateFontCollection();

        int globalQuestionIndexE, globalQuestionIndexH;
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public ReactionEntryForm(int globalQuestionIndexE, int globalQuestionIndexH)
        {
            InitializeComponent();

            this.globalQuestionIndexE = globalQuestionIndexE;
            this.globalQuestionIndexH = globalQuestionIndexH;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            OptTimer.Start();
            WaitTimer.Start();

            System.Windows.Forms.Timer BackgroundTimer = new System.Windows.Forms.Timer();

            BackgroundTimer.Interval = 300;

            BackgroundTimer.Tick += new EventHandler((o, ev) =>
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
            });

            BackgroundTimer.Start();

            Blue = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb0.png");
            Red = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb1.png");

            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL"))
                {
                    control.BackgroundImage = Blue;
                }
            }

            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Main.png");
            NextButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");

            font.AddFontFile("C:\\Quiz&Reaction\\ProgramResources\\Fonts\\Oswald-Bold.ttf");

            NextButton.Font = new Font(font.Families[0], 40);
            WarningLabel.Font = new Font(font.Families[0], 50);
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

        public void OpenOpenningForm(object obj)
        {
            System.Windows.Forms.Application.Run(new OpenningForm(1, globalQuestionIndexE, globalQuestionIndexH));
        }

        public void OpenReactionForm(object obj)
        {
            Application.Run(new ReactionForm(globalQuestionIndexE, globalQuestionIndexH));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int NextButtonLocation = NextButton.Location.X;
                System.Windows.Forms.Timer borderTimer = new System.Windows.Forms.Timer();
                borderTimer.Interval = 25;
                int count = 0;

                borderTimer.Tick += new EventHandler(async (o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        NextButton.Location = new Point(NextButton.Location.X + 2, NextButton.Location.Y);
                    }
                    else
                    {
                        NextButton.Location = new Point(NextButton.Location.X - 2, NextButton.Location.Y);
                    }
                    if (NextButton.Location.X == NextButtonLocation)
                    {
                        borderTimer.Stop();

                        await Task.Run(() =>
                        {
                            thread = new System.Threading.Thread(OpenReactionForm);
                            thread.SetApartmentState(System.Threading.ApartmentState.STA);
                            thread.Start();
                        });

                        await Task.Delay(500);

                        this.Close();
                    }
                });

                NextButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
                borderTimer.Start();
            }
        }
    }
}
