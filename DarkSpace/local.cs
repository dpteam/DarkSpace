using System;
using System.Threading;
using System.Globalization;
using Microsoft.SqlServer.Server;

namespace DarkSpace
{
    internal class Local
    {
        /*string localName;
        localName = Thread.CurrentThread.CurrentCulture.Name;
        if(localName == "ru-RU")
        {*/
        public static string strDbgModeOn = "Режим отладки включен.";
        
        public static string strWelcome = "Добро пожаловать в нашу пездатую игору.";
        
        public static string strSelector = "Выберите опцию:";
        public static string strSelectorNewGame = "1. Начать новую игру";
        public static string strSelectorExit = "2. Выйти";

        public static string strUnknownFatalError = "Произошел троллинг. Программа будет закрыта.";
        //}
    }
}