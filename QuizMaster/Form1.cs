﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizMaster
{
    public partial class Form1 : Form
    {
        private Quiz quiz = new Quiz();
        private string tempUserAnswer = ""; // TODO: move to quiz class?
        private string[] altButtonNames = { "option1", "option2", "option3", "option4" };

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
            // first remove start button
            this.Controls.RemoveByKey("startQuiz");
            // then change textbox to be ready to load question
            title.Location = new Point(150, 100);
            title.Font = new Font("Microsoft Sans Serif", 20);

            // create buttons for quiz
            int xStart = 150;
            int yStart = 200;
            for (int i = 0; i < altButtonNames.Length; i++)
            {
                AddQuizButton(altButtonNames[i], new Point(xStart + ((i%2)*300), yStart + (i/2)*100), Answer_Click);
            }
            AddQuizButton("next", new Point(500,400), Next_Click);

            // load question
            LoadNextQuizPage();
        }

        /// <summary>
        /// Event handler that handles button-click on all answer options. Updates field
        /// <c>tempUserAnswer</c> every time one of the options is clicked
        /// </summary>
        private void Answer_Click(Object sender, EventArgs e)
        {
            // check which button sent the event and retrieve text
            tempUserAnswer = ((Button)sender).Text;
        }

        /// <summary>
        /// Event handler that handles click on "next" button. Sends value of field
        /// <c>tempUserAnswer</c> to class <c>Quiz</c> as answer to current question. Then
        /// loads next page in the game.
        /// </summary>
        private void Next_Click(Object sender, EventArgs e)
        {
            // TODO: give message if the question was not answered by the user?
            quiz.SaveAnswer(tempUserAnswer);
            tempUserAnswer = "";
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
            (string q, List<string> answerAlternatives) = quiz.GetNextQuestion();

            // First checks if there are any questions left. If not it loads final page
            if (q == null)
            {
                // remove arbitrary buttons
                foreach (string buttonName in altButtonNames)
                {
                    this.Controls.RemoveByKey(buttonName);
                }
                this.Controls.RemoveByKey("next");

                // add relevant text
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
            // Otherwise it loads the next quiz question with alternatives
            else
            {
                // update relevant label and button texts
                title.Text = q;
                for (int i = 0; i < altButtonNames.Length; i++)
                {
                    Button b = (Button)this.Controls[altButtonNames[i]];
                    b.Text = answerAlternatives[i];
                }
            }
        }
    }
}
