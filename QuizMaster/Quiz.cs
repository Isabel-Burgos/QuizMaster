using System;
using System.Collections.Generic;

namespace QuizMaster
{
    /// <summary>
    /// Class containing the logic to retrieve the next quiz question, with answer options, and determine score based 
    /// on chosen answers.
    /// Assumes that every question has 4 answer alternatives.
    /// </summary>
    internal class Quiz
    {
        // columns: question, alternative 1, aternative 2, alternative 3, alternative 4, correct answer     
        private string[,] quiz = {
            { "Hva er verdens høyeste fjell?", "Galdhøpiggen", "Mount Everest", "Mount Kilimanjaro", "Mount Neverest", "Mount Everest" },
            { "Hvem var den første kongen i Norge?", "Harald Hårfagre", "Kong Carl Johan", "Kong Haakon VII", "Kong Harald V", "Harald Hårfagre" },
            { "Hvem er kjent som dronningen av krim?", "Anne Holt", "Erlend Loe", "Agatha Christie", "Isabel Allende", "Agatha Christie" },
            { "Hva er hovedstaden i Australia?", "Sydney", "Canberra", "Melbourne", "Perth", "Canberra" },
            { "Hvor mange bein har en sommerfugl?", "6", "8", "5", "4", "6" },
            { "Hvilket land har verdens lengste kystlinje?", "Russland", "Canada", "Grønland", "Norge", "Canada" },
            { "Hva er den mest nordliggende hovedstaden i verden?", "Oslo", "Nuuk", "Reykjavik", "Helsinki", "Reykjavik" },
            { "Hvem vant Norske Talenter 2024?", "Quick Style", "Michael John", "Jump Crew", "Julie Bergan", "Jump Crew"}
        };

        private List<string> userAnswers = new List<string>();
        private int currentQuestionId = -1;

        public Quiz()
        {
            // asserting that there has to be 6 columns in the quiz matrix for logic to work
            if (quiz.GetLength(1) != 6)
            {
                // Note: actually strange to use ArgumentException here because the function has no argument,
                // but I couln't find a better fitting exception
                throw new ArgumentException($"Matrix '{nameof(quiz)}' does not have 6 columns, as required");
            }
        }

        /// <summary>
        /// Returns question and the four answer alternatives associated to index <paramref name="questionId"/>.
        /// If no questions are left in the quiz, all variables have value <c>null</c>.
        /// </summary>
        public (string q, List<string> answerAlternatives) GetNextQuestion()
        {
            currentQuestionId++;

            if (currentQuestionId >= quiz.GetLength(0))
            {
                return (null, null);
            }
            return (quiz[currentQuestionId, 0],
                new List<string> { quiz[currentQuestionId, 1], quiz[currentQuestionId, 2], quiz[currentQuestionId, 3], quiz[currentQuestionId, 4] });
        }

        /// <summary>
        /// Saves <paramref name="userAnswer"/> in register of user answers at index of question.
        /// </summary>
        public void SaveAnswer(string userAnswer)
        {
            // if-statement checks if the answer should be added to the list since the question has not
            // previously been answered, or if the answer should be updated.
            // In the case that the index (i.e., Id) is not consistent with list size, an error is thrown.
            if (userAnswers.Count == 0 || currentQuestionId == userAnswers.Count)
            {
                userAnswers.Add(userAnswer);
            }
            else if (currentQuestionId < 0 || currentQuestionId > userAnswers.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(currentQuestionId), "Index is out of bounds");
            }
            else
            {
                userAnswers[currentQuestionId] = userAnswer;
            }
        }

        /// <summary>
        /// Calculates the total score by comparing all answers given by the user to the correct answers.
        /// </summary>
        /// <returns>int: current score</returns>
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < userAnswers.Count; i++)
            {
                if (userAnswers[i].Equals(quiz[i, 5])) { score++; }
            }
            return score;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>int: Number of questions in quiz</returns>
        public int GetNmbQuestions()
        {
            return quiz.GetLength(0);
        }
    }
}
