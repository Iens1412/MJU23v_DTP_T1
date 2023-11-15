using System.Globalization;

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
                }
            } while (true);
                Console.WriteLine("==== Languages in Spain ====");
            foreach (Language L in eulangs)
            {
                int index = L.area.IndexOf("Spain");
                if (index != -1)
                    L.Print();
            }
            Console.WriteLine("==== Baltic Languages ====");
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Baltic");
                if (index != -1)
                    L.Print();
            }
            Console.WriteLine("==== Population larger than 50 millions ====");
            foreach (Language L in eulangs)
            {
                if (L.pop >= 50_000_000)
                    L.Print();
            }
            Console.WriteLine("==== Number of Germanics ====");
            int sumgerm = 0;
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Germanic");
                if (index != -1)
                    sumgerm += L.pop;
            }
            Console.WriteLine($"Germanic speaking population: {sumgerm}");
            Console.WriteLine("==== Number of Romance ====");
            int sumromance = 0;
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Romance");
                if (index != -1)
                    sumromance += L.pop;
            }
            Console.WriteLine($"Romance speaking population: {sumromance}");
        }
    }
}
