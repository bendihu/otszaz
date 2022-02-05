namespace otszaz
{
    public class Program
    {
        static List<String> vasarlas = new List<String>();
        static int bSorszam = 0, bDarab = 0;
        static string bArucikk = "";
        static void Main(string[] args)
        {
            //1. feladat
            Beolvas();

            //2. feladat
            Feladat2();

            //3. feladat
            Feladat3();

            //4. feladat
            Feladat4();

            //5. feladat
            Feladat5();

            //6. feladat
            Feladat6();

            //7. feladat
            Feladat7();

            //8. feladat
            Feladat8();

            Console.ReadLine();
        }
        private static void Beolvas()
        {
            StreamReader sr = new StreamReader(@"penztar.txt");

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                vasarlas.Add(sor);
            }

            sr.Close();
        }
        private static void Feladat2()
        {
            Console.WriteLine("2. feladat");

            int fizetesek = 0;

            foreach (var item in vasarlas)
            {
                if (item.Equals("F")) fizetesek++;
            }

            Console.WriteLine($"A fizetések száma: {fizetesek}");
            Console.WriteLine();
        }
        private static void Feladat3()
        {
            Console.WriteLine("3. feladat");

            int darab = 0;

            foreach (var item in vasarlas)
            {
                if (!item.Equals("F")) darab++;
                else break;
            }

            Console.WriteLine($"Az első vásárló {darab} darab árúcikket vásárolt.");
            Console.WriteLine();
        }
        private static void Feladat4()
        {
            Console.WriteLine("4. feladat");

            Console.Write("Adja meg egy vásárlás sorszámát! ");
            bSorszam = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adja meg egy árucikk nevét! ");
            bArucikk = Console.ReadLine();

            Console.Write("Adja meg a vásárolt darabszámot! ");
            bDarab = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat");

            int fizetes = 1, elsoFizetes = 0, utolsoFizetes = 0, osszes = 0;

            for (int i = 0; i < vasarlas.Count; i++)
            {
                if (vasarlas[i].Equals("F")) fizetes++;

                if (elsoFizetes == 0 && vasarlas[i].Equals(bArucikk)) elsoFizetes = fizetes;

                if (vasarlas[i].Equals(bArucikk) && utolsoFizetes <= fizetes)
                {
                    utolsoFizetes = fizetes;
                    osszes++;
                }
            }

            Console.WriteLine($"Az első vásárlás sorszáma: {elsoFizetes}");
            Console.WriteLine($"Az utolsó vásárlás sorszáma: {utolsoFizetes}");
            Console.WriteLine($"{osszes} vásárlás során vettek belőle.");
            Console.WriteLine();
        }
        private static int ertek(int db)
        {
            int osszeg = 0;
            switch (db)
            {
                case 1:
                    osszeg = 500;
                    break;
                case 2:
                    osszeg = 500 + 450;
                    break;
                case >= 3:
                    osszeg = 500 + 450 + 400 + (db - 3) * 400;
                    break;
                default:
                    break;
            }
            return osszeg;
        }
        private static void Feladat6()
        {
            Console.WriteLine("6. feladat");
            Console.WriteLine($"{bDarab} darab vételekor fizetendő: {ertek(bDarab)}");
            Console.WriteLine();
        }
        private static void Feladat7()
        {
            Console.WriteLine("7. feladat");

            int vasar = 1;
            List<String> lista = new List<String>();

            for (int i = 0; i < vasarlas.Count; i++)
            {
                if (vasarlas[i].Equals("F"))
                {
                    vasar++;
                    i++;
                }

                if (vasar == bSorszam)
                {
                    lista.Add(vasarlas[i]);
                }
            }

            var csoport = lista.GroupBy(x => x).ToList();

            foreach (var group in csoport)
            {
                Console.WriteLine($"{group.Count()} {group.Key}");
            }
        }
        private static void Feladat8()
        {
            StreamWriter sw = new StreamWriter(@"osszeg.txt");
            int vasar = 1, osszeg = 0;

            List<String> list = new List<String>();

            foreach (var item in vasarlas)
            {
                if (!item.Equals("F"))
                {
                    list.Add(item);
                }
                else
                {
                    var csoport = list.GroupBy(x => x).ToList();

                    foreach (var group in csoport)
                    {
                        osszeg += ertek(group.Count());
                    }

                    sw.WriteLine($"{vasar}: {osszeg}");
                    vasar++;
                    osszeg = 0;
                    list.Clear();
                }
            }

            sw.Close();
        }
    }
}