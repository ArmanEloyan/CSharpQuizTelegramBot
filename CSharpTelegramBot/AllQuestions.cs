namespace CSharpTelegramBot
{
    public class AllQuestions
    {
        private static List<Question> s_Questions;

        public AllQuestions()
        {
            s_Questions = InitializeQuestions();
        }

        private List<Question> InitializeQuestions()
        {
            var questions = new List<Question>
            {
                new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "1.png",
                    new List<string> { "0", "1", "Runtime Error", "Compile time error","123" },
                    "Compile time error"
                ),
                new Question(
                    "string-ը ի՞նչ տիպի տվյալ է:",
                    "",
                      new List<string> { "Reference Type", "Value Type", "Pointer Type", "Dynamic Type" },
                    "Reference Type"
                ),
                   new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "7.png",
                    new List<string> { "0", "123", "1230", "0123" },
                    "123"
                ),
                new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "2.png",
                     new List<string> { "01", "11", "12", "00" },
                    "11"
                ),
                new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "3.png",
                     new List<string> { "Compilation Error", "Runtime error", "text", "'Դատարկ'" },
                    "Compilation Error"
                ),
                 new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "4.png",
                    new List<string> { "Method1 Done", "Method1 Method2 Done", "Done", "Ոչինչ" },
                    "Method1 Method2 Done"
                ),
                     new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "10.png",
                    new List<string> { "Compilation Error", "Runtime error", "2", "0" },
                    "2"
                ),
                  new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "5.png",
                    new List<string> { "Animal Year: 1", "Cat Year: 4", "Animal Year: 2", "Animal Year: 4" },
                    "Animal Year: 4"
                ),
                    new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "6.png",
                     new List<string> { "Animal", "Cat", "Compilation Error", "NullReferenceException" },
                    "Cat"
                ),
                        new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "8.png",
                     new List<string> { "123", "23", "32", "3" },
                    "123"
                ),
                  new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "9.png",
                    new List<string> { "Compilation Error", "Runtime error", "Base", "Ոչինչ" },
                    "Base"
                ),
            };

            return questions;

        }

        public List<Question> GetQuestions()
        {
            return s_Questions;
        }
    }
}
