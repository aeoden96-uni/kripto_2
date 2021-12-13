using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranspositionCipherHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Luka
            string text = @"EPIZP AUAIF EOOIU ZUOIA IEERI AAEUL RARCT IJMCZ ESBIS ALOEA NIKLO ZKPJR GOLAH KDVRI VJVJT PRCCI";
            // Monika
            //string text = @"NKIIP KEPAU RAKNN JAIRG JODFI SCCEM 
            //                JIRUF MEIEE JJKOI EEWDO DJOOU TFVIN";

            int minColumns = 4;
            int maxColumns = 16;

            WriteEverything(text, minColumns, maxColumns);
        }

        public static void WriteEverything(string text, int minColumns, int maxColumns)
        {
            text = Regex.Replace(text, @"\s+", "");

            List<int> possibleNumberOfColumns = new List<int>();
            for (int i = minColumns; i <= maxColumns; i++)
            {
                if ((text.Length % i == 0) && (text.Length / i <= maxColumns))
                {
                    possibleNumberOfColumns.Add(i);
                    Console.WriteLine(i.ToString() + " x " + (text.Length / i).ToString() + " = " + text.Length.ToString());
                }
            }
            Console.WriteLine();
            foreach (int columns in possibleNumberOfColumns)
            {
                WriteMatrices(text, columns);
            }
        }

        public static void WriteMatrices(string text, int columns)
        {
            int rows = text.Length / columns;

            List<string> matrix = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(String.Empty);
                for (int j = i; j < text.Length; j += rows)
                {
                    matrix[i] += text[j];
                }
            }

            Console.WriteLine("Columns = " + columns);
            foreach (var row in matrix)
            {
                string firstGroup = "AEIOU";
                int firstCount = 0;
                foreach (char c in firstGroup)
                {
                    firstCount += Regex.Matches(row, c.ToString()).Count;
                }
                int secondCount = row.Length - firstCount;
                Console.WriteLine(row + " " + firstCount.ToString() + ":" + secondCount.ToString());
            }
            Console.WriteLine();
            WriteFrequencies(matrix);
        }

        public static void WriteFrequencies(List<string> matrix)
        {
            HashSet<string> commonBigrams = new HashSet<string>()
            {
                "AK", "AN", "AS", "AT", "AV", "CI", "DA", "ED", "EN", "IC", "IJ", "IN",
                "IS", "JA", "JE", "KA", "KO", "LI", "NA", "NE", "NI", "NO", "OD", "OJ",
                "OS", "OV", "PO", "PR", "RA", "RE", "RI", "ST", "TA", "TI", "VA", "ZA"
            };

            if (matrix[0].Length >= 10)
                Console.Write(" ");
            Console.Write("  |");
            for (int i = 1; i <= matrix[0].Length; i++)
                Console.Write(" " + i);
            Console.WriteLine();
            int max = 3 + 2 * matrix[0].Length;
            if (matrix[0].Length >= 10)
                max += matrix[0].Length - 8;
            for (int i = 0; i < max; i++)
                Console.Write("-");
            Console.WriteLine();

            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0].Length >= 10 && i < 9)
                    Console.Write(" ");
                Console.Write((i + 1).ToString() + " |");
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (i != j)
                    {
                        string col1 = string.Empty;
                        string col2 = string.Empty;
                        foreach (string str in matrix)
                        {
                            col1 += str.Substring(i, 1);
                            col2 += str.Substring(j, 1);
                        }

                        int counter = 0;
                        for (int k = 0; k < col1.Length; k++)
                        {
                            string tmp = col1[k].ToString() + col2[k];
                            if (commonBigrams.Contains(tmp))
                                ++counter;
                        }
                        if (j >= 10)
                            Console.Write(" ");
                        Console.Write(" " + counter);
                    }
                    else
                    {
                        if (j >= 10)
                            Console.Write(" ");
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

