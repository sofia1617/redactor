using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace pr6_Sonia
{
    public class TopPopa
    {
        public string NameofPizza;
        public string LayesofCheese;
        public string Countofpepperoni;
        static public List<TopPopa> MyPizza = new List<TopPopa>();
        public TopPopa()
        {
        }
        public TopPopa(string NameofPizza, string LayesofCheese, string Countofpepperoni)
        {
            this.NameofPizza = NameofPizza;
            this.LayesofCheese = LayesofCheese;
            this.Countofpepperoni = Countofpepperoni;
        }
        public static void GettingLink()
        {
            string b;
            Console.WriteLine("Введите путь вашего файла:\n");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("____________________________");
            Console.SetCursorPosition(0, 2);
            b = Console.ReadLine();
            String b2 = b.Substring(b.Length - 1);
            GettingInfoABoutPizza(b2, b);
            Thread.Sleep(3000);
            Console.Clear();

        }
        static void GettingInfoABoutPizza(string b2, string b)
        {
            switch (b2)
            {
                case "t":
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Формат вашего файла txt");
                    TopPopa Pepperoni__txt = new TopPopa();
                    string nameofpizza = File.ReadLines($"{b}").ElementAtOrDefault(0);
                    Pepperoni__txt.NameofPizza = nameofpizza;
                    Console.WriteLine(Pepperoni__txt.NameofPizza);

                    string layesofcheese = File.ReadLines($"{b}").ElementAtOrDefault(1);
                    Pepperoni__txt.LayesofCheese = layesofcheese;
                    Console.WriteLine(Pepperoni__txt.LayesofCheese);

                    string countofpepperoni = File.ReadLines($"{b}").ElementAtOrDefault(2);
                    Pepperoni__txt.Countofpepperoni = countofpepperoni;
                    Console.WriteLine(Pepperoni__txt.Countofpepperoni);
                    TopPopa.MyPizza.Add(Pepperoni__txt);
                    Thread.Sleep(2500);
                    break;
                case "n":
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Формат вашего файла json");
                    string Pepperoni__json = File.ReadAllText($"{b}");
                    MyPizza = JsonConvert.DeserializeObject<List<TopPopa>>(Pepperoni__json);
                    foreach (var item in MyPizza)
                    {
                        Console.WriteLine(item.NameofPizza);
                        Console.WriteLine(item.LayesofCheese);
                        Console.WriteLine(item.Countofpepperoni);
                    }
                    Thread.Sleep(2500);
                    break;
                case "l":
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Формат вашего файла xml");
                    XmlSerializer Pepperoni__xml = new XmlSerializer(typeof(List<TopPopa>));
                    using (FileStream Pepperoni_stream = new FileStream($"{b}", FileMode.Open))
                    {
                        MyPizza = (List<TopPopa>)Pepperoni__xml.Deserialize(Pepperoni_stream);
                    }
                    foreach (var item in MyPizza)
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