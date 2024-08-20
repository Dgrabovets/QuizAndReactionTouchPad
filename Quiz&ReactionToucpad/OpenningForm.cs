using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Quiz_ReactionToucpad
{
    public partial class OpenningForm : Form
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

        public OpenningForm(int startFlag, int globalQuestionIndexE, int globalQuestionIndexH)
        {
            InitializeComponent();

            if (startFlag == 0)
            {
                List<string> pathList = new List<string>
                {
                    "C:\\Quiz&Reaction\\QuizResults\\HardQuizBestResult.txt",
                    "C:\\Quiz&Reaction\\QuizResults\\EasyQuizBestResult.txt",
                    "C:\\Quiz&Reaction\\ReactionBestResult.txt"
                };

                foreach (string path in pathList)
                {
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.WriteLine("00.59.00");
                    }
                }

                startFlag = 1;
            }

            this.globalQuestionIndexE = globalQuestionIndexE;
            this.globalQuestionIndexH = globalQuestionIndexH;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            OptTimer.Start();

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
            QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Knowledge0.png");
            ReactionButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Speed0.png");
            BackgroundTimer.Start();
        }

        #region Global Variables
        int globalQuestionIndexE;
        int globalQuestionIndexH;
        int enableSwitch = 0;
        System.Threading.Thread thread;
        int WaitingSecondsCount = 0;
        int backgroundCount = 1;
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        Image Blue, Red;
        System.Windows.Forms.Timer BackgroundTimer = new System.Windows.Forms.Timer();
        System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource();
        #endregion

        private void QuizButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int QuizButtonLocation = QuizButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 10;
                int count = 0;

                borderTimer.Tick += new EventHandler(async (o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        QuizButton.Location = new Point(QuizButton.Location.X - 2, QuizButton.Location.Y);
                    }
                    else
                    {
                        QuizButton.Location = new Point(QuizButton.Location.X + 2, QuizButton.Location.Y);
                    }
                    if (QuizButton.Location.X == QuizButtonLocation)
                    {
                        borderTimer.Stop();
                        BackgroundTimer.Stop();

                        await Task.Run(() =>
                        {
                            thread = new System.Threading.Thread(OpenQuizForm);
                            thread.SetApartmentState(System.Threading.ApartmentState.STA);
                            thread.Start();
                        });

                        await Task.Delay(500);

                        this.Close();
                    }
                });

                QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Knowledge1.png");
                borderTimer.Start();
            }
        }

        private void ReactionButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int ReactionButtonLocation = ReactionButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 10;
                int count = 0;

                borderTimer.Tick += new EventHandler(async (o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        ReactionButton.Location = new Point(ReactionButton.Location.X + 2, ReactionButton.Location.Y);
                    }
                    else
                    {
                        ReactionButton.Location = new Point(ReactionButton.Location.X - 2, ReactionButton.Location.Y);
                    }
                    if (ReactionButton.Location.X == ReactionButtonLocation)
                    {
                        borderTimer.Stop();
                        BackgroundTimer.Stop();

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

                ReactionButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Speed1.png");
                borderTimer.Start();
            }
        }

        public async void OpenQuizForm(object obj)
        {
            Application.Run(new QuizForm(globalQuestionIndexE, globalQuestionIndexH));
        }

        public void OpenReactionForm(object obj)
        {
            Application.Run(new ReactionEntryForm(globalQuestionIndexE, globalQuestionIndexH));
        }

        public void OpenOpenningForm(object obj)
        {
            Application.Run(new OpenningForm(1, globalQuestionIndexE, globalQuestionIndexH));
        }

        private void OptTimer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void OpenningForm_Load(object sender, EventArgs e)
        {

        }
    }
}
