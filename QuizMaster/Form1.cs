using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMaster
{
    public partial class Form1 : Form
    {
        Quiz quiz = new Quiz();
        string userAnswer = ""; // TODO: move to quiz class

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when button "Start Game" is pressed by the user
        /// </summary>
        private void StartButton_Click(object sender, EventArgs e)
        {
            //** create quiz interface: **//
            // first remove start key
            this.Controls.RemoveByKey("startQuiz");
            // then change text
            label1.Location = new Point(150, 100);
            label1.Font = new Font("Microsoft Sans Serif", 20);

            // create buttons for quiz
            AddQuizButton("option1", new Point(150, 200), Answer_Click);
            AddQuizButton("option2", new Point(450, 200), Answer_Click);
            AddQuizButton("option3", new Point(150, 300), Answer_Click);
            AddQuizButton("option4", new Point(450, 300), Answer_Click);
            AddQuizButton("next", new Point(500,400), Next_Click);

            // fill quiz with first question
            LoadNextQuizPage();
        }

        /// <summary>
        /// Event handler that handles button-click on all answer options
        /// </summary>
        private void Answer_Click(Object sender, EventArgs e)
        {
            // check which button sent the event
            Button buttonClicked = (Button)sender;
            userAnswer = buttonClicked.Text;
        }

        /// <summary>
        /// Event handler that handles click on "next" button
        /// </summary>
        private void Next_Click(Object sender, EventArgs e)
        {
            // TODO: account for if the question was not answered by the user

            quiz.SaveAnswer(userAnswer);

            // load next page
            LoadNextQuizPage();
        }

        /// <summary>
        /// Creates a button, <c>b</c>, with <c>b.name</c> and <c>b.text</c> defined by 
        /// <paramref name="buttonName"/>, location on app defined by <paramref name="location"/>,
        /// and <paramref name="eventHandler"/> as <c>EventHandler</c>.
        /// Then adds button to app form.
        /// </summary>
        private void AddQuizButton(string buttonName, Point location, EventHandler eventHandler)
        {
            Button b = new Button();
            b.Location = location;
            b.Name = buttonName;
            b.Text = buttonName;
            b.Size = new Size(250, 65); // TODO: Make button size fit text
            b.Font = new Font("Microsoft Sans Serif", 14);
            b.Click += eventHandler;
            this.Controls.Add(b);
        }

        private void LoadNextQuizPage()
        {
            (string q, string a1, string a2, string a3, string a4) = quiz.GetNextQuestion();
            if (q == null)
            {
                // load final page
                this.Controls.RemoveByKey("option1");
                this.Controls.RemoveByKey("option2");
                this.Controls.RemoveByKey("option3");
                this.Controls.RemoveByKey("option4");
                this.Controls.RemoveByKey("next");

                label1.Text = "Congratulations, you completed the quiz!";
                Label score = new Label();
                score.Location = new Point(150, 200);
                score.Font = new Font("Microsoft Sans Serif", 14);
                score.Text = $"Your score is:\n{quiz.GetScore()}/{quiz.GetNmbQuestions()}";
                score.AutoSize = true;
                this.Controls.Add(score);

                // TODO: add "close" and/or "replay" button
            }
            else
            {
                label1.Text = q;
                Button op1 = (Button)this.Controls["option1"];
                op1.Text = a1;
                Button op2 = (Button)this.Controls["option2"];
                op2.Text = a2;
                Button op3 = (Button)this.Controls["option3"];
                op3.Text = a3;
                Button op4 = (Button)this.Controls["option4"];
                op4.Text = a4;
            }
        }
    }
}
