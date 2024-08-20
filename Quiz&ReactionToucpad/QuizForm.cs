using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Quiz_ReactionToucpad
{
    public partial class QuizForm : Form
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

        public QuizForm(int globalQuestionIndexE, int globalQuestionIndexH)
        {
            InitializeComponent();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            this.globalQuestionIndexH = globalQuestionIndexH;
            this.globalQuestionIndexE = globalQuestionIndexE;

            WaitTimer.Start();
            OptTimer.Start();

            Blue = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb0.png");
            Red = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb1.png");

            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith("RR") || control.Name.StartsWith("RL"))
                {
                    control.BackgroundImage = Blue;
                }
            }

            RegularTimer.Start();

            QuestionsMarks = new List<Image>
            {
                Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb0.png"),
                Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb1.png"),
                Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Romb2.png")
            };

            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Zer.png");
            Easy_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Yound0.png");
            Hard_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Old0.png");

            QuitButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Knowledge0_1.png");

            AnswerButton_1.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_2.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_3.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_4.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again0.png");

            font.AddFontFile("C:\\Quiz&Reaction\\ProgramResources\\Fonts\\Oswald-Bold.ttf");

            QuestionTextBox.Font = new Font(font.Families[0], 35);
            AnswerButton_1.Font = new Font(font.Families[0], 30);
            AnswerButton_2.Font = new Font(font.Families[0], 30);
            AnswerButton_3.Font = new Font(font.Families[0], 30);
            AnswerButton_4.Font = new Font(font.Families[0], 30);
            ResultLabel.Font = new Font(font.Families[0], 80);
            MLabel.Font = new Font(font.Families[0], 50);
            RTLabel.Font = new Font(font.Families[0], 40);
            ReLabel.Font = new Font(font.Families[0], 80);
        }

        #region Global Variables
        int globalQuestionIndexE;
        int globalQuestionIndexH;
        int ButtonFlag = 0;
        PrivateFontCollection font = new PrivateFontCollection();

        System.Threading.Thread thread;
        int WaitingSecondsCount = 0;
        int enableSwitch = 0;

        List<Image> QuestionsMarks;

        class QuizModel
        {
            public string Question { get; set; }

            public string Answer_1 { get; set; }

            public string Answer_2 { get; set; }

            public string Answer_3 { get; set; }

            public string Answer_4 { get; set; }

            public string CorrectAnswer { get; set; }
        }

        List<QuizModel> quizModels = new List<QuizModel>();

        Random Random = new Random();
        int questionIndex = 0;
        int RightFlag = 0;
        int WrongCount = 0;
        int WrongFlag = 0;

        Timer timerTimer = new Timer();

        Stopwatch stopwatch = new Stopwatch();
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        int chosenMode;

        int backgroundCount = 1;
        int number = 1;

        Image Blue, Red;
        #endregion

        private void Hard_QuizButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int Hard_QuizButtonLocation = Hard_QuizButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 10;
                int count = 0;

                borderTimer.Tick += new EventHandler((o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        Hard_QuizButton.Location = new Point(Hard_QuizButton.Location.X - 2, Hard_QuizButton.Location.Y);
                    }
                    else
                    {
                        Hard_QuizButton.Location = new Point(Hard_QuizButton.Location.X + 2, Hard_QuizButton.Location.Y);
                    }
                    if (Hard_QuizButton.Location.X == Hard_QuizButtonLocation)
                    {
                        borderTimer.Stop();
                        Hard_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Old0.png");

                        chosenMode = 0;
                        FillQuizModel("Hard");
                        enableSwitch = 0;
                    }
                });

                Hard_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Old1.png");
                borderTimer.Start();
            }
        }

        private void Easy_QuizButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                int Easy_QuizButtonLocation = Easy_QuizButton.Location.X;
                Timer borderTimer = new Timer();
                borderTimer.Interval = 10;
                int count = 0;

                borderTimer.Tick += new EventHandler((o, ev) =>
                {
                    count++;
                    if (count < 10)
                    {
                        Easy_QuizButton.Location = new Point(Easy_QuizButton.Location.X + 2, Easy_QuizButton.Location.Y);
                    }
                    else
                    {
                        Easy_QuizButton.Location = new Point(Easy_QuizButton.Location.X - 2, Easy_QuizButton.Location.Y);
                    }
                    if (Easy_QuizButton.Location.X == Easy_QuizButtonLocation)
                    {
                        borderTimer.Stop();
                        Easy_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Yound0.png");

                        chosenMode = 1;
                        FillQuizModel("Easy");
                        enableSwitch = 0;
                    }
                });

                Easy_QuizButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Young1.png");
                borderTimer.Start();
            }
        }

        private void FillQuizModel(string mode)
        {
            quizModels = new List<QuizModel>();
            questionIndex = 0;
            WrongFlag = 0;
            WrongCount = 0;
            RightFlag = 0;

            Question_1.BackgroundImage = QuestionsMarks[1];
            Question_2.BackgroundImage = QuestionsMarks[0];
            Question_3.BackgroundImage = QuestionsMarks[0];
            Question_4.BackgroundImage = QuestionsMarks[0];
            Question_5.BackgroundImage = QuestionsMarks[0];

            List<string> Qs = new List<string>();

            using (StreamReader reader = new StreamReader($"C:\\Quiz&Reaction\\Quizes\\{mode}Bank.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Qs.Add(line);
                }

                reader.Close();
            }

            int globalQuestionIndex = 0;

            switch (mode)
            {
                case "Hard":
                    globalQuestionIndex = globalQuestionIndexH;
                    break;
                case "Easy":
                    globalQuestionIndex = globalQuestionIndexE;
                    break;
            }

            for (int i = globalQuestionIndex; i < Qs.Count; i++)
            {
                string[] strSplit = Qs[i].Split('/');

                quizModels.Add(new QuizModel
                {
                    Question = strSplit[0],
                    Answer_1 = strSplit[1],
                    Answer_2 = strSplit[2],
                    Answer_3 = strSplit[3],
                    Answer_4 = strSplit[4],
                    CorrectAnswer = strSplit[5]
                });
            }

            if (quizModels.Count >= 5)
            {
                globalQuestionIndex += 5;
            }
            else
            {
                int i = 0;
                while (quizModels.Count != 5)
                {
                    string[] strSplit = Qs[i].Split('/');

                    quizModels.Add(new QuizModel
                    {
                        Question = strSplit[0],
                        Answer_1 = strSplit[1],
                        Answer_2 = strSplit[2],
                        Answer_3 = strSplit[3],
                        Answer_4 = strSplit[4],
                        CorrectAnswer = strSplit[5]
                    });

                    i++;
                }

                globalQuestionIndex = i;
            }

            switch (mode)
            {
                case "Hard":
                    globalQuestionIndexH = globalQuestionIndex;
                    break;
                case "Easy":
                    globalQuestionIndexE = globalQuestionIndex;
                    break;
            }

            InvertRombsVisibility(1);
            InvertButtonsVisibility(0);
            InvertLabelsVisibility(1);
            FillAnswers(quizModels[questionIndex]);

            MLabel.Visible = true;

            stopwatch = new Stopwatch();

            timerTimer.Interval = 1;
            timerTimer.Tick += new EventHandler((o, ev) =>
            {
                TimeSpan timeSpan = stopwatch.Elapsed;
                MLabel.Text = timeSpan.ToString("mm\\.ss\\.ff");
            });

            timerTimer.Start();

            stopwatch.Start();
        }

        private void FillAnswers(QuizModel quizModel)
        {
            QuestionTextBox.Text = quizModel.Question;
            AnswerButton_1.Text = quizModel.Answer_1;
            AnswerButton_2.Text = quizModel.Answer_2;
            AnswerButton_3.Text = quizModel.Answer_3;
            AnswerButton_4.Text = quizModel.Answer_4;

            AnswerButton_1.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_2.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_3.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
            AnswerButton_4.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");
        }

        private void InvertButtonsVisibility(int flag)
        {
            if (flag == 0)
            {
                Hard_QuizButton.Visible = false;

                Easy_QuizButton.Visible = false;

                foreach (Control control in this.Controls)
                {
                    if (control.Name.StartsWith("AnswerButton") || control.Name.StartsWith("Question_"))
                    {
                        control.Visible = true;
                    }
                }

                QuestionTextBox.Visible = true;
            }
            else
            {
                Hard_QuizButton.Visible = true;

                Easy_QuizButton.Visible = true;

                foreach (Control control in this.Controls)
                {
                    if (control.Name.StartsWith("AnswerButton") || control.Name.StartsWith("Question_"))
                    {
                        control.Visible = false;
                    }
                }

                QuestionTextBox.Visible = false;
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

        private void InvertLabelsVisibility(int flag)
        {
            if (flag == 0)
            {
                QuestionTextBox.Visible = false;
                MLabel.Visible = false;
                ResultLabel.Visible = true;
            }
            else
            {
                QuestionTextBox.Visible = true;
                ResultLabel.Visible = false;
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

        public string CheckBestResult(string M, string S, string F, int flag)
        {
            string path = "";
            if (flag == 0)
            {
                path = "C:\\Quiz&Reaction\\QuizResults\\HardQuizBestResult.txt";
            }
            else
            {
                path = "C:\\Quiz&Reaction\\QuizResults\\EasyQuizBestResult.txt";
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadToEnd();
                reader.Close();
                int[] values = Array.ConvertAll(line.Split('.'), delegate (string s) { return int.Parse(s); });

                if (
                    (values[0] == 0 && int.Parse(M) == 0 && values[1] == 0 && int.Parse(S) == 0 && int.Parse(F) < values[2]) ||
                    (values[0] == 0 && int.Parse(M) == 0 && values[1] != 0 && int.Parse(S) < values[1]) ||
                    (values[0] != 0 && int.Parse(M) < values[0])
                   )
                {
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.WriteLine($"{M}.{S}.{F}");
                    }

                    wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Win.mp3";
                    wplayer.controls.play();

                    return $"Новый рекорд -_{M}:{S}.{F}";
                }
                else
                {
                    wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\Lose.mp3";
                    wplayer.controls.play();

                    return $"Лучший результат -_{line.Split('.')[0]}:{line.Split('.')[1]}.{line.Split('.')[2]}";
                }
            }
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith("AnswerButton"))
                {
                    control.Click += new EventHandler((o, ev) =>
                    {
                        WaitingSecondsCount = 0;

                        if (enableSwitch == 0)
                        {
                            enableSwitch = 1;

                            string nameInt = control.Name.Split('_')[1];
                            string Name = $"AnswerButton_{nameInt}";

                            Button button = this.Controls[Name] as Button;
                            int ButtonLocation = button.Location.X;
                            Timer borderTimer = new Timer();
                            borderTimer.Interval = 5;
                            int count = 0;

                            if (quizModels[questionIndex].CorrectAnswer == nameInt)
                            {
                                wplayer.URL = $"C:\\Quiz&Reaction\\Sounds\\RightAnswerSound{Random.Next(1, 4)}.mp3";
                                wplayer.controls.play();
                            }
                            else
                            {
                                wplayer.URL = $"C:\\Quiz&Reaction\\Sounds\\WrongAnswerSound{Random.Next(1, 4)}.mp3";
                                wplayer.controls.play();
                            }

                            borderTimer.Tick += new EventHandler(async (ooo, evvv) =>
                            {
                                count++;
                                if (count < 10)
                                {
                                    button.Location = new Point(button.Location.X - 2, button.Location.Y);
                                }
                                else
                                {
                                    button.Location = new Point(button.Location.X + 2, button.Location.Y);
                                }
                                if (button.Location.X == ButtonLocation)
                                {
                                    borderTimer.Stop();
                                    control.ForeColor = Color.White;
                                    control.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Answer0.png");

                                    if (quizModels[questionIndex].CorrectAnswer == nameInt)
                                    {
                                        this.Controls[$"Question_{questionIndex + 1}"].BackgroundImage = QuestionsMarks[2];
                                        if (questionIndex != 4)
                                        {
                                            FillAnswers(quizModels[questionIndex + 1]);

                                            this.Controls[$"Question_{questionIndex + 2}"].BackgroundImage = QuestionsMarks[1];

                                            if (WrongFlag == 0)
                                            {
                                                RightFlag++;
                                            }
                                            WrongFlag = 0;

                                            questionIndex++;
                                            enableSwitch = 0;
                                        }
                                        else
                                        {
                                            if (WrongFlag == 0)
                                            {
                                                RightFlag++;
                                            }
                                            WrongFlag = 0;

                                            stopwatch.Stop();

                                            string[] result;
                                            TimeSpan timeSpan = stopwatch.Elapsed;
                                            string[] time = timeSpan.ToString("mm\\.ss\\.ff").Split('.');
                                            ResultLabel.Text = timeSpan.ToString("mm\\.ss\\.ff");
                                            if (WrongCount == 0)
                                            {
                                                result = CheckBestResult(time[0], time[1], time[2], chosenMode).Split('_');
                                                ReLabel.Text = result[1];
                                                ReLabel.Location = new Point(702, 851);
                                                RTLabel.Location = new Point(685, 759);
                                                RTLabel.Text = "Лучший результат:";
                                            }
                                            else
                                            {
                                                result = CheckBestResult("10", "00", "00", chosenMode).Split('_');
                                                ReLabel.Text = $"{RightFlag.ToString()} из 5";
                                                RTLabel.Text = "Правильные ответы:";

                                                ReLabel.Location = new Point(750, 841);
                                                RTLabel.Location = new Point(655, 759);
                                            }

                                            QuestionTextBox.Visible = false;

                                            AnswerButton_1.Visible = false;
                                            AnswerButton_2.Visible = false;
                                            AnswerButton_3.Visible = false;
                                            AnswerButton_4.Visible = false;

                                            ReLabel.Visible = true;
                                            RTLabel.Visible = true;

                                            for (int i = 1; i < 6; i++)
                                            {
                                                this.Controls[$"Question_{i}"].Visible = false;
                                            }

                                            RetryButton.Location = new Point(1423, 918);
                                            RetryButton.Visible = true;

                                            this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Result.png");

                                            InvertLabelsVisibility(0);
                                            InvertRombsVisibility(2);

                                            RegularTimer.Stop();
                                            OddTimer.Start();

                                            timerTimer.Stop();
                                            enableSwitch = 0;
                                        }
                                    }
                                    else
                                    {
                                        WrongFlag++;
                                        WrongCount++;

                                        this.Controls[Name].BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\WrongAnswer.png");
                                        this.Controls[Name].Text = "Неправильно!";

                                        await Task.Delay(500);

                                        enableSwitch = 0;
                                    }
                                }
                            });

                            borderTimer.Start();
                        }
                    });
                }
            }
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

        private void RetryButton_Click(object sender, EventArgs e)
        {
            if (enableSwitch == 0)
            {
                enableSwitch = 1;
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "C:\\Quiz&Reaction\\Sounds\\ButtonClick.mp3";
                wplayer.controls.play();

                WaitingSecondsCount = 0;

                MLabel.Visible = false;

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
                        borderTimer.Stop();
                        RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again0.png");
                        InvertButtonsVisibility(1);
                        OddTimer.Stop();
                        RegularTimer.Start();

                        ReLabel.Visible = false;
                        RTLabel.Visible = false;

                        ResultLabel.Visible = false;

                        RetryButton.Visible = false;
                        this.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Backgrounds\\Zer.png");
                    }
                });

                RetryButton.BackgroundImage = Image.FromFile("C:\\Quiz&Reaction\\ProgramResources\\Buttons\\Again1.png");
                borderTimer.Start();
            }
        }
    }
}
