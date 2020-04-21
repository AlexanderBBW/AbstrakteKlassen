using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstrakt
{
    abstract class Frage
    {
        public string FrageStellung { get; set; }
        public string Antwort { get; set; }
        public List<string> Fragestellungen = new List<string>();
        protected Random random = new Random();

        protected void ZeigeFrage()
        {
            Console.WriteLine(FrageStellung);
        }
        public void GibAntwort()
        {
            Console.WriteLine(Antwort);
        }
        protected void BekommeFrage()
        {

            
            while (true)
            {
                var numb = random.Next(0, Fragestellungen.Count);
                if (numb % 2 == 0)
                {
                    FrageStellung = Fragestellungen[numb];
                    Antwort = Fragestellungen[numb + 1];
                    break;
                }
            }
        }
        public bool PrüfeAntworti(string anwser)
        {
            return Antwort.ToLower() == anwser.ToLower();
        }
    }
    class Mathe : Frage
    {
        public Mathe ()
        {
            Fragestellungen = new List<string>
            {
                "Wie viel ist 9*9?", "81", "Was ist das Ergebniss von 9/9?", "1"
            };
            BekommeFrage();
            ZeigeFrage();
        }
    }
    class FreierText :Frage
    {
        public FreierText()
        {
            Fragestellungen = new List<string>
            {
                "Welche Zahl beschreibt Christopher?", "666", "Welches Wort möchte Alex zu Christopher sagen?", "Danke :)" 
            };
            BekommeFrage();
            ZeigeFrage();
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Was für ne Frage willst du denn? :)");
            Console.WriteLine("'1' für Mathe und '2' für eine TextAufgabe und bei allem anderen wirds beendet");
            switch (Console.ReadLine())
            {
                case "1":
                    Mathe mathe = new Mathe();
                   var eingabe =  Console.ReadLine();
                    if (mathe.PrüfeAntworti(eingabe))
                    {
                        Console.WriteLine("Richtig");
                    }
                    else
                    {
                        Console.WriteLine("I am sorry you are wrong! Du bist Hoffnungslos");
                    }
                    break;
                case "2":
                    FreierText freierText = new FreierText();
                    var eingabetext = Console.ReadLine();
                    if (freierText.PrüfeAntworti(eingabetext))
                    {
                        Console.WriteLine("Richtig");
                    }
                    else
                    {
                        Console.WriteLine("I am sorry you are wrong! Du bist Hoffnungslos");
                    }
                    break;
                default:
                    Console.WriteLine("Das war falsch ....");
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
