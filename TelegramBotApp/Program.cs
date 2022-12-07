using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotApp;

namespace TelegramBotApp
{
    internal class Program
    {
        private static string token { get; set; } = "5983920068:AAFgt-yTEuPzCZcMEwZsNxBSqGaqeaFzVjk";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Получение сообщение:{msg.Text}");
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
                //var ph = await client.SendPhotoAsync(
                //    chatId: msg.Chat.Id,
                //    photo: "https://screenmusings.org/movie/blu-ray/Once-Upon-a-Time-in-Hollywood/images/Once-Upon-a-Time-in-Hollywood-333.jpg",
                //    replyToMessageId: msg.MessageId);
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GeButtons());
            }
        }

        private static IReplyMarkup GeButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { new KeyboardButton {Text = "1MOK" }, new KeyboardButton { Text = "31ИС"} },
                new List<KeyboardButton> { new KeyboardButton {Text = "2MOK" }, new KeyboardButton { Text = "33ИС"} }
            }
            };
        }
    }
}
