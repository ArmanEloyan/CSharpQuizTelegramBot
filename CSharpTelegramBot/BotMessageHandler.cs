using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;

namespace CSharpTelegramBot
{
    internal class BotMessageHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly List<Question> _questions;
        private readonly Dictionary<long, int> _userCurrentQuestion;
        private readonly AllQuestions _allQuestions;


        public BotMessageHandler(ITelegramBotClient botClient)
        {
            _allQuestions = new AllQuestions();
            _questions = _allQuestions.GetQuestions();

            _botClient = botClient;
            _userCurrentQuestion = new Dictionary<long, int>();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Message != null)
                {
                    if(update.Message.Text == "/start")
                    {
                        await SendStartButtonAsync(update.Message.Chat.Id, cancellationToken);
                        return;
                    }
                }

                if (update.CallbackQuery != null)
                {
                    long chatId = update.CallbackQuery.Message.Chat.Id;
                    if (update.CallbackQuery.Data == "start")
                    {
                        if (_userCurrentQuestion.ContainsKey(chatId))
                        {
                            _userCurrentQuestion[update.CallbackQuery.Message.Chat.Id] = 0;
                        }
                        else
                        {
                            _userCurrentQuestion.Add(chatId, 0);
                        }

                        await SendNextQuestionAsync(update.CallbackQuery.Message.Chat.Id, cancellationToken);
                        return;
                    }

                    if (update.CallbackQuery.Data.StartsWith("answer_"))
                    {

                        if (_userCurrentQuestion.TryGetValue(chatId, out int currentQuestionIndex))
                        {
                            Question question = _questions[currentQuestionIndex];
                            string selectedAnswer = update.CallbackQuery.Data.Replace("answer_", "");
                            bool isCorrect = false;
                            
                            if(selectedAnswer == question.TrueAnswer)
                            {
                                isCorrect = true;
                            }

                            string caption = question.GetQuesionAsString() + "\n";

                            if (isCorrect)
                            {
                                caption += $"({selectedAnswer}) ճիշտ պատասխան ✅\n";
                            }
                            else
                            {
                                caption += $"({selectedAnswer}) պատասխանը սխալ է ❌\n";
                                caption += $"ճիշտ պատասխանն է {question.TrueAnswer}";
                            }

                            if (update.CallbackQuery.Message.Photo != null && update.CallbackQuery.Message.Photo.Any())
                            {
                                await _botClient.EditMessageCaption(
                                    chatId: chatId,
                                    messageId: update.CallbackQuery.Message.MessageId,
                                    caption: caption,
                                    replyMarkup: null,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await _botClient.EditMessageText(
                                    chatId: chatId,
                                    messageId: update.CallbackQuery.Message.MessageId,
                                    text: caption,
                                    replyMarkup: null,
                                    cancellationToken: cancellationToken);
                            }

                            currentQuestionIndex++;
                            if (currentQuestionIndex < _questions.Count)
                            {
                                _userCurrentQuestion[chatId] = currentQuestionIndex;
                                await SendNextQuestionAsync(chatId, cancellationToken);
                            }
                            else
                            {
                                await _botClient.SendMessage(
                                    chatId,
                                    "Դուք պատասխանել եք բոլոր հարցերին:",
                                    cancellationToken: cancellationToken);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }


        private async Task SendNextQuestionAsync(long chatId, CancellationToken cancellationToken)
        {
            if (_userCurrentQuestion.TryGetValue(chatId, out int currentQuestionIndex))
            {
                Question question = _questions[currentQuestionIndex];
                await SendQuestionAsync(chatId, question, cancellationToken);
            }
        }

        private async Task SendQuestionAsync(long chatId, Question question, CancellationToken cancellationToken)
        {
            string[] letters = new string[] { "A", "B", "C", "D" };

            string caption = question.GetQuesionAsString();

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            for (int i = 0; i < question.Options.Count; i++)
            {
                buttons.Add(new InlineKeyboardButton[]
                {
                InlineKeyboardButton.WithCallbackData(letters[i], $"answer_{question.Options[i]}")
                }
                );

            }
            InlineKeyboardMarkup answerButtons = new InlineKeyboardMarkup(buttons);

            if (string.IsNullOrWhiteSpace(question.PhotoPath))
            {
                await _botClient.SendMessage(
                    chatId,
                    caption,
                    replyMarkup: answerButtons,
                    cancellationToken: cancellationToken);
            }
            else
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, question.PhotoPath);
                if (File.Exists(filePath))
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        await _botClient.SendPhoto(
                            chatId,
                            stream,
                            caption: caption,
                            replyMarkup: answerButtons,
                            cancellationToken: cancellationToken);
                    }
                }
                else
                {
                    await _botClient.SendMessage(
                        chatId,
                        caption,
                        replyMarkup: answerButtons,
                        cancellationToken: cancellationToken);
                }
            }
        }

        private async Task SendStartButtonAsync(long chatId, CancellationToken cancellationToken)
        {
            InlineKeyboardMarkup startButton = new InlineKeyboardMarkup(new InlineKeyboardButton[] { InlineKeyboardButton.WithCallbackData("Սկսել", "start") });

            await _botClient.SendMessage(
                chatId,
                "Սկսելու համար սեղմեք «Սկսել» կոճակը",
                replyMarkup: startButton,
                cancellationToken: cancellationToken);
        }
    }
}
