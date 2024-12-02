using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuizMaster
{
    public partial class Form1 : Form
    {
        Quiz quiz = new Quiz();
        string tempUserAnswer = ""; // TODO: move to quiz class?

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
            // then change textbox to be ready to load question
            title.Location = new Point(150, 100);
            title.Font = new Font("Microsoft Sans Serif", 20);

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
        /// Event handler that handles button-click on all answer options. Updates field
        /// <c>tempUserAnswer</c> every time one of the options is clicked
        /// </summary>
        private void Answer_Click(Object sender, EventArgs e)
        {
            // check which button sent the event
            Button buttonClicked = (Button)sender;
            tempUserAnswer = buttonClicked.Text;
        }

        /// <summary>
        /// Event handler that handles click on "next" button. Sends value of field
        /// <c>tempUserAnswer</c> to class <c>Quiz</c> as answer to current question
        /// </summary>
        private void Next_Click(Object sender, EventArgs e)
        {
            // TODO: give message if the question was not answered by the user?
            quiz.SaveAnswer(tempUserAnswer);

            // load next page
            LoadNextQuizPage();
        }

        /// <summary>
        /// Event handler that handles when "close" button is pressed
        /// </summary>
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            b.Size = new Size(250, 65);
            b.Font = new Font("Microsoft Sans Serif", 14);
            b.Click += eventHandler;
            this.Controls.Add(b);
        }

        /// <summary>
        /// Fills textbox and buttons with values for the next question, unless all questions
        /// have already been answered. In the latter case, the final page is loaded.
        /// </summary>
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

                title.Text = "Congratulations, you completed the quiz!";
                title.Font = new Font("Microsoft Sans Serif", 24);
                Label score = new Label();
                score.Location = new Point(150, 200);
                score.Font = new Font("Microsoft Sans Serif", 18);
                score.Text = $"Your score is:\n{quiz.GetScore()}/{quiz.GetNmbQuestions()}";
                score.AutoSize = true;
                this.Controls.Add(score);

                // Add "close" button so user can end game
                AddQuizButton("close", new Point(500, 400), Close_Click);

                // TODO: add "replay" button?
            }
            else
            {
                title.Text = q;
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
