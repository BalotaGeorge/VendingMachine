using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static List<string[]> items = new List<string[]>()
        {
            new string[] { "7Days", "100", "2" },
            new string[] { "BakeRolls", "101", "3" },
            new string[] { "Lays", "102", "2.5" },
            new string[] { "Sniker", "103", "2.5" },
            new string[] { "Tuc", "104", "2" },
            new string[] { "Mars", "105", "2" },
            new string[] { "Lion", "106", "2.5" },
            new string[] { "Cola", "107", "4" },
            new string[] { "Cola-Zero", "108", "4.5" },
            new string[] { "Sprite", "109", "4" },
            new string[] { "Fanta", "110", "4" },
            new string[] { "7Up", "111", "3.5" },
        };
        static string cr = "Lei: ";
        static string id = "ID: ";
        static int spaceitem = 30;
        static int itemsinrow = 3;
        public static void Draw()
        {
            int idcol = 0;
            Console.Write("|");
            for (int j = 0; j < (spaceitem + 1) * itemsinrow - 1; j++) Console.Write("-");
            Console.WriteLine("|");
            for (int i = 0; i < items.Count; i++)
            {
                if(idcol == itemsinrow)
                {
                    idcol = 0;
                    Console.Write("|");
                    Console.WriteLine();
                    for (int j = 0; j < spaceitem * itemsinrow; j++)
                    {
                        if (j % spaceitem == 0) Console.Write("|");
                        Console.Write("-");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
                int gapbefore = (spaceitem - items[i][0].Length - id.Length - items[i][1].Length - cr.Length - items[i][2].Length) / 2;
                int gapafter = spaceitem - gapbefore - items[i][0].Length - id.Length - items[i][1].Length - cr.Length - items[i][2].Length - 2;
                Console.Write("|");
                for (int j = 1; j <= gapbefore; j++) Console.Write(" ");
                Console.Write(items[i][0] + " " + id + items[i][1] + " " + cr + items[i][2]);
                for (int j = 1; j <= gapafter; j++) Console.Write(" ");
                idcol++;
            }
            Console.WriteLine("|");
            Console.Write("|");
            for (int j = 0; j < (spaceitem + 1) * itemsinrow - 1; j++) Console.Write("-");
            Console.Write("|");
        }
        static void Main(string[] args)
        {
            float currentcurrency = 0f;
            Draw();
            Console.WriteLine("\n");
            do
            {
                Console.Write($"Enter currency: {cr}0.5, {cr}1, {cr}5 or {cr}10 --- ");
                do
                {
                    float t = 0f;
                    try
                    {
                        t = float.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.Write("Enter money! Words are cheap. Try again --- ");
                    }
                    if (t != 0f && t != 0.5f && t != 1f && t != 5f && t != 10f) 
                    {
                        Console.Write("Enter one of the amounts listed above. Try again --- ");
                        t = 0f;
                    }
                    if (t != 0f)
                    {
                        currentcurrency += t;
                        break;
                    }
                } while (true);
                Console.WriteLine("Current amount: " + cr + currentcurrency + ".");
                Console.Write("Would you like to buy or add more money (type b or m) --- ");
                char desire = ' ';
                desire = Console.ReadLine()[0];
                if (desire == 'b') 
                {
                    string idt = "";
                    int indexitem = -1;
                    do
                    {
                        Console.Write("Enter the ID of the item you would like --- ");
                        indexitem = -1;
                        bool good = false;
                        idt = Console.ReadLine();
                        foreach (string[] s in items)
                        {
                            if (s[1] == idt)
                            {
                                good = true;
                                indexitem = items.IndexOf(s);
                            }
                        }
                        if (good)
                        {
                            if ((currentcurrency - float.Parse(items[indexitem][2])) >= 0f) break;
                            else
                            {
                                char desire2 = ' ';
                                Console.Write("Seems like you don't have enough money for that. Choose other item or add more money (type o or m) --- ");
                                desire2 = Console.ReadLine()[0];
                                if (desire2 == 'm')
                                {
                                    indexitem = -1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.Write("Enter a valid ID. Try again --- ");
                        }
                    } while (true);
                    if (indexitem >= 0)
                    {
                        currentcurrency -= float.Parse(items[indexitem][2]);
                        Console.WriteLine(items[indexitem][0] + "! I choose you.");
                        break;
                    }
                }
            } while (true);
            Console.WriteLine("Thank you for the purchase. " + "Your change is " + currentcurrency + ".");
            Console.ReadLine();
        }
    }
}
