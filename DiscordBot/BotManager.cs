using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class BotManager
    {
        public static DiscordSocketClient? BotClient;
        public static CommandService? Commands;
        public static IServiceProvider? ServiceProvider;


        public async Task RunBot()
        {
            BotClient = new DiscordSocketClient();
            await BotClient.LoginAsync(Discord.TokenType.Bot, Secret.GetToken(), true);
            await BotClient.StartAsync();
            BotClient.Log += Logger;
            BotClient.Ready += BotReady;

            await Task.Delay(-1);
        }

        public Task Logger(LogMessage message)
        {
            Console.WriteLine("[Logger] - " + message);
            return Task.CompletedTask;
        }

        public async Task BotReady()
        {
            await BotClient.SetGameAsync("Mit deiner Mum");
            await BotClient.SetStatusAsync(UserStatus.DoNotDisturb);
            BotClient.MessageReceived += TestMessage;
        }

        public async Task TestMessage(SocketMessage arg)
        {
            var test = arg.Content;
            if (test == "ping")
            {

                await arg.Channel.SendMessageAsync("pong!");
               
            }
        }

    }
}
