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
        string[] questions = { 
            "What is the highest mountain in the world?",
            "Who was the first Presient of USA?",
            "Which country has the longest coastline in the world?",
            "Who is known as the queen of crime?",
            "What is the capital of Australia?",
            "What animal's milk is pink?",
            "What is the northernmost capital city in the World?",
            "Who is known as the father of modern Physics?"
            };

        int questionsAnswered = 0;
        int questionsCorrect = 0;

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event handler for when button "Start Game" is pressed by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_button_Click(object sender, EventArgs e)
        {
            /* create quiz interface: */
            // first remove start key
            this.Controls.RemoveByKey("startQuiz");
            // then change text
            label1.Location = new Point(150, 100);
            label1.Font = new Font("Microsoft Sans Serif", 20);

            // create buttons for quiz
            addQuizButton("option1", new Point(150, 200));
            addQuizButton("option2", new Point(450, 200));
            addQuizButton("option3", new Point(150, 300));
            addQuizButton("option4", new Point(450, 300));
            addQuizButton("Next", new Point(500,400)); // TODO: add another handler to this button?

            loadQuestionPage(questionsAnswered);
        }

        /// <summary>
        /// Event handler that handles click on all answer options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void answer_Click(Object sender, EventArgs e)
        {
            // check which object sent the event
            var senderObject = (Button)sender;
            string buttonTag = senderObject.Text;
            Console.WriteLine(buttonTag); // temporary to check that it works

            // TODO: make button that was clicked blue to show the user?
        }

        /// <summary>
        /// Updates the app form to show the question at index <paramref name="qIndex"/>
        /// </summary>
        /// <param name="qIndex"></param>
        private void loadQuestionPage(int qIndex)
        {
            label1.Text = questions[qIndex];
            // TODO: load answer options
        }

        /// <summary>
        /// Creates a button, <c>b</c>, with <c>b.name</c> and <c>b.text</c> defined by 
        /// <paramref name="buttonName"/>, and location on app defined by <paramref name="location"/>.
        /// Then adds button to app form
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="location"></param>
        private void addQuizButton(string buttonName, Point location)
        {
            Button b = new Button();
            b.Location = location;
            b.Name = buttonName;
            b.Text = buttonName;
            b.Size = new Size(250, 65); // TODO: Make button size fit text
            b.Font = new Font("Microsoft Sans Serif", 14);
            b.Click += answer_Click;
            this.Controls.Add(b);
        }
    }
}
