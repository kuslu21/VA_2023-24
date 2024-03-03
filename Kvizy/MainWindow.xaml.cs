using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace RandomQuestionGame
{
    public partial class MainWindow : Window
    {
        private int score = 0;
        private int bestScore = 0;
        private readonly string scoresFilePath = "scores.json";
        private List<Question> questions;

        public MainWindow()
        {
            InitializeComponent();
            LoadScores();
            lblBestScore.Text = bestScore.ToString(); // Display best score
            LoadQuestions();
            ShowRandomQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<Question>();

            // Generate questions for addition (up to score of 5)
            if (score < 5)
            {
                GenerateAdditionQuestions();
            }
            // Generate questions for addition and subtraction (score between 5 and 9)
            else if (score < 10)
            {
                GenerateAdditionQuestions();
                GenerateSubtractionQuestions();
            }
            // Generate questions for multiplication (score between 10 and 14)
            else if (score < 15)
            {
                GenerateMultiplicationQuestions();
            }
            // Generate questions for division (score 15 and above)
            else
            {
                GenerateDivisionQuestions();
            }
        }

        private void GenerateAdditionQuestions()
        {
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    if (i + j <= 10)
                        questions.Add(new Question { Text = $"Kolik je {i} + {j}?", Answer = i + j });
                }
            }
        }

        private void GenerateSubtractionQuestions()
        {
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    if (i - j >= 0)
                        questions.Add(new Question { Text = $"Kolik je {i} - {j}?", Answer = i - j });
                }
            }
        }

        private void GenerateMultiplicationQuestions()
        {
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    if (i * j <= 100)
                        questions.Add(new Question { Text = $"Kolik je {i} * {j}?", Answer = i * j });
                }
            }
        }

        private void GenerateDivisionQuestions()
        {
            for (int i = 1; i <= 10; i++) // Avoid division by zero
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (i * j <= 100)
                        questions.Add(new Question { Text = $"Kolik je {i * j} / {i}?", Answer = j });
                }
            }
        }

        private void LoadScores()
        {
            if (File.Exists(scoresFilePath))
            {
                string json = File.ReadAllText(scoresFilePath);
                var scores = JsonConvert.DeserializeObject<Scores>(json);
                if (scores != null)
                {
                    bestScore = scores.BestScore;
                }
            }
        }

        private void SaveScores()
        {
            var scores = new Scores { BestScore = bestScore };
            string json = JsonConvert.SerializeObject(scores);
            File.WriteAllText(scoresFilePath, json);
        }

        private void ShowRandomQuestion()
        {
            Random rand = new Random();
            Question question = questions[rand.Next(0, questions.Count)];
            lblQuestion.Content = question.Text;
            lblQuestion.Tag = question.Answer; // Save correct answer

            // Randomly determine which button will have the correct answer
            int correctButton = rand.Next(1, 4);

            if (correctButton == 1)
            {
                btnAnswer1.Content = question.Answer;
                btnAnswer2.Content = rand.Next(0, 20);
                btnAnswer3.Content = rand.Next(0, 20);
            }
            else if (correctButton == 2)
            {
                btnAnswer1.Content = rand.Next(0, 20);
                btnAnswer2.Content = question.Answer;
                btnAnswer3.Content = rand.Next(0, 20);
            }
            else
            {
                btnAnswer1.Content = rand.Next(0, 20);
                btnAnswer2.Content = rand.Next(0, 20);
                btnAnswer3.Content = question.Answer;
            }

            // Set correct Tag for answer buttons
            btnAnswer1.Tag = btnAnswer1.Content;
            btnAnswer2.Tag = btnAnswer2.Content;
            btnAnswer3.Tag = btnAnswer3.Content;
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int selectedAnswer = Convert.ToInt32(button.Tag);

            if (selectedAnswer == Convert.ToInt32(lblQuestion.Tag))
            {
                score++;
                if (score > bestScore)
                {
                    bestScore = score;
                    lblBestScore.Text = bestScore.ToString(); // Update best score
                    SaveScores(); // Save best score
                }
            }
            else
            {
                MessageBox.Show("Špatná odpověď!");
                score = 0;
            }

            lblBestScore.Text = score.ToString(); // Update current score
            LoadQuestions(); // Reload questions based on updated score
            ShowRandomQuestion();
        }

        private void GameOver()
        {
            // Code executed when the player loses
            MessageBox.Show("Prohrál jsi!");

            // Delete current score from file
            DeleteScore();

            // Reset current score
            score = 0;
            lblBestScore.Text = score.ToString(); // Update current score label

            // Display next random question
            ShowRandomQuestion();
        }

        private void DeleteScore()
        {
            // Check if the scores file exists
            if (File.Exists(scoresFilePath))
            {
                // Delete the scores file
                File.Delete(scoresFilePath);
            }
        }
    }

    public class Scores
    {
        public int BestScore { get; set; }
    }

    public class Question
    {
        public string Text { get; set; }
        public int Answer { get; set; }
    }
}
