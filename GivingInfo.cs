using System;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace pr6_Sonia
{
    public class GivingInfo
    {
        static public void New_FileandData()
        {
            string new_file_for_pizza;
            Console.Clear();
            Console.WriteLine("Введите путь к вашему новому файлу");
            Console.WriteLine("----------------------------------");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("-------------------------------");
            Console.SetCursorPosition(0, 3);
            new_file_for_pizza = Console.ReadLine();
            String editlink = new_file_for_pizza.Substring(new_file_for_pizza.Length - 1);
            creating_addingInfo_about_pizza(new_file_for_pizza, editlink);





        }
        static void creating_addingInfo_about_pizza(string new_fiel_for_pizza, string editlink)
        {
            File.Create($"{new_fiel_for_pizza}").Close();
            switch (editlink)
            {
                case "t":
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Формат вашего нового файла -> txt");
                    string pizza_txt = "";
                    string enter__ = "\n";
                    foreach (var item in TopPopa.MyPizza)
                    {
                        pizza_txt += item.NameofPizza;
                        pizza_txt += enter__;
                        pizza_txt += item.LayesofCheese;
                        pizza_txt += enter__;
                        pizza_txt += item.Countofpepperoni;
                    }
                    File.WriteAllText($"{new_fiel_for_pizza}", pizza_txt);
                    foreach (var item in TopPopa.MyPizza)
                    {
                        Console.WriteLine(item.NameofPizza);
                        Console.WriteLine(item.LayesofCheese);
                        Console.WriteLine(item.Countofpepperoni);
                    }
                    Thread.Sleep(2500);
                    break;
                case "n":
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Формат вашего нового файла -> json");
                    string pizza_json = JsonConvert.SerializeObject(TopPopa.MyPizza);
                    File.AppendAllText($"{new_fiel_for_pizza}", pizza_json);
                    Console.SetCursorPosition(0, 6);
                    foreach (var item in TopPopa.MyPizza)
                    {
                        Console.WriteLine(item.NameofPizza);
                        Console.WriteLine(item.LayesofCheese);
                        Console.WriteLine(item.Countofpepperoni);
                    }
                    Thread.Sleep(2500);
                    break;
                case "l":
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Формат вашего нового файла -> xml");
                    XmlSerializer pizza_xml = new XmlSerializer(typeof(List<TopPopa>));
                    using (FileStream pizza_stream2 = new FileStream($"{new_fiel_for_pizza}", FileMode.OpenOrCreate))
                    {
                        pizza_xml.Serialize(pizza_stream2, TopPopa.MyPizza);
                    }
                    foreach (var item in TopPopa.MyPizza)
                    {
                        Console.WriteLine(item.NameofPizza);
                        Console.WriteLine(item.LayesofCheese);
                        Console.WriteLine(item.Countofpepperoni);
                    }
                    Thread.Sleep(2500);
                    break;
            }
        }

    }
}