using System;
using System.Net.Sockets;
using Ucu.Poo.DiscordBot.Services;

namespace Proyecto_Pokemon
{
    class Program
    {
        private static void Main()
        {
            DemoBot();
        }
        
        private static void DemoBot()
        {
            BotLoader.LoadAsync().GetAwaiter().GetResult();
        }
    }
}