﻿using System.Globalization;

namespace MJU23v_DTP_T1
{
    /*
     * 1. get new array strings for the command
     * 2. get do while loop
     * 3. get if-else sats for every command 
     * 4. delete the old code a keep the new one
     * 5. refactor if needed
     */

    public class Language
    {
        public string family, group;
        public string language, area, link;
        public int pop;
        public Language(string line)
        {
            string[] field = line.Split("|");
            family = field[0];
            group = field[1];
            language = field[2];
            pop = (int)double.Parse(field[3], CultureInfo.InvariantCulture);
            area = field[4];
            link = field[5];
        }
        public void Print()
        {
            Console.WriteLine($"Language {language}:");
            Console.Write($"  family: {family}");
            if (group != "")
                Console.Write($">{group}");
            Console.WriteLine($"\n  population: {pop}");
            Console.WriteLine($"  area: {area}");
        }
    }
    public class Program
    {
        static string dir = @"..\..\..";
        static List<Language> eulangs = new List<Language>();
        static void Main(string[] arg)
        {
            using (StreamReader sr = new StreamReader($"{dir}\\lang.txt"))
            {
                Language lang;
                string line = sr.ReadLine();
                while (line != null)
                {
                    // Console.WriteLine(line);
                    lang = new Language(line);
                    eulangs.Add(lang);
                    line = sr.ReadLine();
                }
            }

            Console.WriteLine("Welcome! enter commnad 'help' if you need help??");
            do
            {
                Console.Write("> ");
                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "list" && command[1] == "group")
                {
                    string groupName = string.Join(" ", command.Skip(2));

                    foreach (Language L in eulangs)
                    {
                        int index = L.group.IndexOf(groupName);
                        if (index != -1)
                        {
                            Console.WriteLine(L.language);
                        }
                    }
                }
                else if (command[0] == "list" && command[1] == "country")
                {
                    string countryname = command[2];
                    foreach (Language L in eulangs)
                    {
                        int index = L.area.IndexOf(countryname);
                        if (index != -1)
                            Console.WriteLine(L.language);
                    }
                }
                else if (command[0] == "list" && command[1] == "between" && command[3] == "and")
                {

                    int lownum = int.Parse(command[2]);
                    int highnum = int.Parse(command[4]);

                    foreach (Language L in eulangs)
                    {
                        if (lownum <= L.pop && L.pop <= highnum)
                        {
                            Console.WriteLine(L.language);
                        }
                    }
                }
                else if (command[0] == "show")
                {
                    Show(command);
                }
                else if (command[0] == "population" && command[1] == "group")
                {
                    //NYI: write code here
                }
                else if (command[0] == "help")
                {
                    Help();
                }
                else if (command[0] == "quit")
                {
                    Console.WriteLine("Good Bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong command");
                }
            } while (true);

            static void Help()
            {
                Console.WriteLine("Here are a list of the commnads you can use\n");
                Console.WriteLine("list group /group name/              to list the languages of the gruop");
                Console.WriteLine("list country /countryname/           to list the languages of the country");
                Console.WriteLine("list between /lownum/ and /hinum/    to list the languages between the country that have a population between the lownumber and the highnumber");
                Console.WriteLine("show /language/                      to show the informations about the language");
                Console.WriteLine("show group /group name/              to show the informations about the group of the countries");
                Console.WriteLine("show country /countryname/           to show the informtaions about the country");
                Console.WriteLine("show between /lownum/ and /hinum/    to show informations about countrys tha has a population between lownum and hinum");
                Console.WriteLine("population group /groupname/         to show the population in the group of countries");
                Console.WriteLine("Help                                 to see the command list");
                Console.WriteLine("quit                                 to exit the program");
            }

            static void Show(string[] command)
            {
                if (command.Length == 2)
                {
                    string language = command[1];

                    foreach (Language L in eulangs)
                    {
                        int index = L.language.IndexOf(language);
                        if (index != -1)
                        { L.Print(); }
                    }
                }
                else if (command.Length > 2 && command[1] == "group")
                {
                    //NYI: need to add code here
                }
                else if (command.Length > 2 && command[1] == "country")
                {
                    //NYI: write code here 
                }
                else if (command.Length > 4 && command[1] == "between" && command[3] == "and")
                {
                    //NYI: write code here
                }
            }
        }
    }
}
