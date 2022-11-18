
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;

namespace pr6_Sonia

{
    public class Programm
    {
        static void Main()
        {
            TopPopa.GettingLink();
            Console.WriteLine("Нажмите F1 для сохранения файла\n" +
                "или ESC для выхода из программы\n" +
                "------------------------------");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.F1:
                    Console.WriteLine("Вы нажали клавишу F1");
                    GivingInfo.New_FileandData();

                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Вы нажали клавишу ESC");

                    break;


            }
        }

    }
}