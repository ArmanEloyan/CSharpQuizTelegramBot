using System;
using System.Linq;
using System.Text;

namespace CSharpTelegramBot
{
    public class Question
    {
        public string Text { get; set; }
        public string PhotoPath { get; set; }
        public List<string> Options { get; set; }
        public string TrueAnswer { get; set; }

        public Question(string text, string photoUrl, List<string> options, string trueAnswer)
        {
            Text = text;
            PhotoPath = photoUrl;
            Options = options;
            TrueAnswer = trueAnswer;
        }

        public void SetRandomOptions()
        {
            Random random = new Random();
            Options = Options.OrderBy(x => random.Next()).ToList();
        }

        public string GetQuesionAsString()
        {
            string[] letters = new string[] { "A", "B", "C", "D" };

            StringBuilder optionsAsString = new StringBuilder();

            optionsAsString.AppendLine(Text+"\n");
            for (int i = 0; i < Options.Count; i++)
            {
                optionsAsString.AppendLine($"{letters[i]}) {Options[i]}");
            }
            return optionsAsString.ToString();
        }
    }
}