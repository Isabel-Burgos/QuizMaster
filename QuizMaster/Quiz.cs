using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster
{
    internal class Quiz
    {
        // columns: question, alternative 1, aternative 2, alternative 3, alternative 4, correct answer
        private string[,] quiz = {
            { "Hva er verdens høyeste fjell?", "Galdhøpiggen", "Mount Everest", "Mount Kilimanjaro", "Mount Neverest", "Mount Everest" },
            { "Hvem var den første kongen i Norge?", "Harald Hårfagre", "Kong Carl Johan", "Kong Haakon VII", "Kong Harald V", "Harald Hårfagre" },
            { "Hvem er kjent som dronningen av krim?", "Anne Holt", "Erlend Loe", "Agatha Christie", "Isabel Allende", "Agatha Christie" },
            { "Hva er hovedstaden i Australia?", "Sydney", "Canberra", "Melbourne", "Perth", "Canberra" },
            { "Hvilket land har verdens lengste kystlinje?", "Russland", "Canada", "Grønland", "Norge", "Norge" },
            { "Hva er den mest nordliggende hovedstaden i verden?", "Oslo", "Nuuk", "Reykjavik", "Helsinki", "Nuuk" },
            { "Hvem vant Norske Talenter 2024?", "Quick Style", "Michael John", "Jump Crew", "Julie Bergan", "Jump Crew"}
        };

        private List<string> userAnswers = new List<string>();
        private int currentQuestionId = -1;

        public Quiz()
        {
            // asserting that there has to be 6 columns in the quiz matrix for logic to work
            if (quiz.GetLength(1) != 6)
            {
                throw new ArgumentException($"Matrix '{nameof(quiz)}' does not have 6 columns, as required");
            }
        }

        /// <summary>
        /// Returns question and the four answer alternatives associated to index <paramref name="questionId"/>.
        /// If no questions are left in the quiz, all variables have value <c>null</c>.
        /// </summary>
        /// <returns>Question, Answer alternative 1, Answer alternative 2, Answer alternative 3,
        /// Answer alternative 4</returns>
        public (string q, string a1, string a2, string a3, string a4) GetNextQuestion()
        {
            currentQuestionId++;

            if (currentQuestionId >= quiz.GetLength(0))
            {
                return (null, null, null, null, null);
            }
            return (quiz[currentQuestionId, 0], quiz[currentQuestionId, 1], quiz[currentQuestionId, 2], quiz[currentQuestionId, 3], quiz[currentQuestionId, 4]);
        }

        public void SaveAnswer(string userAnswer)
        {
            // if statement checks if the answer should be added to the list since the question has not
            // previously been answered, or if the answer should be updated.
            // In the case that the index (i.e., Id) is not consistent with list size, an error is thrown.
            if (userAnswers.Count == 0 || currentQuestionId == userAnswers.Count)
            {
                userAnswers.Add(userAnswer);
            }
            else if (currentQuestionId > userAnswers.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(currentQuestionId), "Index is out of bounds");
            }
            else
            {
                userAnswers[currentQuestionId] = userAnswer;
            }
        }

        /// <summary>
        /// Calculates the total score by comparing answers from user to correct answer.
        /// </summary>
        /// <returns>Score as an int</returns>
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < userAnswers.Count; i++)
            {
                if (userAnswers[i].Equals(quiz[i, 5])) { score++; }
            }
            return score;
        }

        public int GetNmbQuestions()
        {
            return quiz.GetLength(0);
        }
    }
}
