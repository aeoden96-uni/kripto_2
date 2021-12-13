using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerchoff
{
    class Program
    {
        static void Main(string[] args)
        {

            // moje    
            string s1 = "YZBGACWW", s2 = "VYFIUSCU";
// profesorovo za provjeru
//            string s1 = "CRUDLHGCAS", s2 = "XVXDUXKUIA";
                    
            // Može i s jednim od ova dva rječnika, al ovak je lakše
            Dictionary<int, char> BrojUSlovo = new Dictionary<int, char>();
            Dictionary<char, int> SlovoUBroj = new Dictionary<char, int>();

            // Moraju obje riječi počinjati s jednim od ova četiri slova
            List<char> Pocetni = new List<char> { 'S', 'P', 'N', 'D'};
            char c = 'A';
            for (int i = 0; i < 26; ++i)
            {
                SlovoUBroj.Add((char)(c + i), i);
                BrojUSlovo.Add(i, (char)(c + i));
            }
            List<int> y1 = new List<int>(), y2 = new List<int>();
            for (int i = 0; i < s1.Length; ++i)
                y1.Add(SlovoUBroj[s1[i]]);
            for (int i = 0; i < s2.Length; ++i)
                y2.Add(SlovoUBroj[s2[i]]);
            
        // y[i] = y2[i] - y1[i]            
            List<int> y = new List<int>();
            for (int i = 0; i < y1.Count; ++i)
            {
                int x = y2[i] - y1[i];
                if (x < 0)
                    x = 26 + x;
                y.Add(x);
            }
            
            
            int ind = 0;
            Console.WriteLine("\nKoristi velika slova kako bi program radio. Neda mise provjeravat dali je slovo u redu uneseno. ");
            Console.WriteLine("Samo da te podsjetim, duljina tvojih rijeci je {0}", s1.Length);
            Console.WriteLine();

            // Izlazni stringovi
            string x1 = "";
            string x2 = "";
            while (ind < s1.Length)
            {
                Console.Write("\n{0}. slovo prve rijeci: ", ind);
                char x1ch = char.Parse(Console.ReadLine());
                if (ind == 0 && Pocetni.Contains(x1ch) == false)
                    continue;
                
                // Znači, ako si unio neko slovo koje nije u Pocetni i ind je 0, preskaci
                // Izračunaj koje je slovo x2[i]
                int x1ind = SlovoUBroj[x1ch];
                int x2ind = (y[ind] + x1ind) % 26;
                

                if (ind == 0 && !Pocetni.Contains(BrojUSlovo[x2ind]))
                    continue;
                x1 += BrojUSlovo[x1ind];
                x2 += BrojUSlovo[x2ind];
                Console.WriteLine("{0} \t{1}", x1, x2);
                ++ind;
                // U redu, sada smo učitali znak, provjerili dali ga je moguće staviti na početak
                // ako je prvi znak, u suprotnom ga dodali na x1 te izračunali novi znak za x2
                // Sada, moramo provjeriti dali je korisnik zadovoljan dobivenim stringom. 
                // Ako je, nastavljamo, ako nije, brišemo posljednji učitani znak iz oba stringa
                // te vraćamo ind na prijašnju poziciju
                // Također, postoji i opcija Reset koja oba situaciju vraća na početak
                
                Console.Write("Jeste li zadovoljni trenutnim stringom?");
                Console.Write("\n\t7 Jesam\n\t1 Obrisi prethodni znak\n\t2 Resetiraj\n\t3 Obrisi zadnjih nekoliko znakova\n\t0 Kraj");
                Console.Write("\nUnesi odluku: ");
                int odl = int.Parse(Console.ReadLine());
                if (odl == 2)
                {
                    x1 = x1.Remove(0);
                    x2 = x2.Remove(0);
                    ind = 0;
                    Console.Clear();
                }
                if (odl == 1)
                {
                    --ind;
                    x1 = x1.Remove(ind);
                    x2 = x2.Remove(ind);
                }
                if (odl == 3)
                {
                    int koliko;
                    Console.Write("Koliko znakova obrisati?  ");
                    koliko = int.Parse(Console.ReadLine());
                    if (koliko == 0)
                        continue;
                    if (koliko < 0)
                        Console.WriteLine("Imbecilu!");
                    ind -= koliko;
                    x1 = x1.Remove(ind);
                    x2 = x2.Remove(ind);
                }
                if (odl == 0)
                    break;
                
            }
            Console.WriteLine("{0} \t {1}", x1, x2);
        }
    }
}
