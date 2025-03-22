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
                    new List<string> { "0", "1", "Runtime Error", "Compile time error" },
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
                    "C#-ում կարո՞ղ է արդյոք աբստրակտ կլասը ժառանգվել մեկ այլ աբստրակտ կլասից",
                    "",
                    new List<string> { "Ոչ աբստրակտ կլասները չեն կարող ժառանգել իրարից", "Այո բայց միայն եթե չեն պարունակում աբստրակտ մեթոդներ", "Այո աբստրակտ կլասը կարող է ժառանգել մեկ այլ աբստրակտ կլասից" },
                    "Այո աբստրակտ կլասը կարող է ժառանգել մեկ այլ աբստրակտ կլասից"
                ),
                        new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "8.png",
                     new List<string> { "123", "23", "32", "3" },
                    "123"
                ),
                            new Question(
                    "Կարո՞ղ է արդյոք աբստրակտ կլասը պարունակել private Field-եր",
                    "",
                    new List<string> { "Ոչ, միայն protected և public է կարելի օգտագործել", "Այո, բայց դրանք անմիջականորեն հասանելի չեն ժառանգող կլասում",
                        "Ոչ, որովհետև աբստրակտ կլասից չի կարելի օբյեկտ ստեղծել", "Այո, և դրանք հասանելի են դառնում ժառանգող կլասին" },
                    "Այո, բայց դրանք անմիջականորեն հասանելի չեն ժառանգող կլասում"
                ),
                  new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "9.png",
                    new List<string> { "Compilation Error", "Runtime error", "Base", "Ոչինչ" },
                    "Base"
                ),
                  new Question(
                    "Ի՞նչ ցույց կտա այս կոդը:",
                    "11.png",
                    new List<string> { "Compilation Error", "Base Print", "Derived Print", "Ոչինչ" },
                    "Derived Print"
                ),
                       new Question(
                    "C#-ում ո՞ր դելեգատը կարող է ոչինչ չընդունել և ոչինչ չվերադարձնել",
                    "",
                    new List<string> { "Action", "Func<int>", "Predicate<string>", "EventHandler"},
                    "Action"
                ),
                     new Question(
                    "C#-ում կարելի՞ է override անել ստատիկ (static) մեթոդը",
                    "",
                    new List<string> { "Այո, եթե այն նշված է որպես virtual", "Այո, բայց պետք է օգտագործել new բառը", "Ոչ, ստատիկ մեթոդը չի կարելի override անել", "Այո, եթե կլասը sealed է" },
                    "Ոչ, ստատիկ մեթոդը չի կարելի override անել"
                ),
                      new Question(
                    "Ի՞նչ ցույց կտա այս կոդը",
                    "12.png",
                    new List<string> { "First", "Second", "C#-ում չի կարելի օգտագործել ref կլասի օբյեկտների հետ" },
                    "Second"
                ),
                       new Question(
                    "Ի՞նչ ցույց կտա այս կոդը",
                    "15.png",
                    new List<string> { "Try Catch Catch1 Finally", "Try Catch Finally", "Try Catch (Error)","Try Finally" },
                    "Try Catch (Error)"
                ),
                       new Question(
                    "Կարո՞ղ է մեկ struct-ը ժառանգվել մեկ այլ struct-ից",
                    "",
                    new List<string> { "Այո, ինչպես class-ները", "Միայն եթե struct-ը սահմանված է որպես public", "Միայն սկսած C# 10-ից", "Ոչ, struct-ները չեն կարող ժառանգել միմյանցից" },
                    "Ոչ, struct-ները չեն կարող ժառանգել միմյանցից"
                ),

                     new Question(
                    "Ի՞նչ ցույց կտա այս կոդը",
                    "14.png",
                    new List<string> { "10", "20", "0","Error" },
                    "20"
                ),
                    new Question(
                    "Ի՞նչ ցույց կտա այս կոդը",
                    "13.png",
                    new List<string> { "13", "12", "InvalidOperationException","123" },
                    "InvalidOperationException"
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
