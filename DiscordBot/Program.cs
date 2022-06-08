using Discord.WebSocket;
using DiscordBot;

namespace Discord_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            BotManager manager = new BotManager();
            manager.RunBot().GetAwaiter().GetResult();
        }
    }
}