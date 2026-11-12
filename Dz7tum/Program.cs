using Dz7tum.classes;
using Dz7tum.enums;
using System;
using System.IO;
using System.Runtime.CompilerServices;
namespace Dz7tum
{

    internal class Program
    {
       

        static void Ex1()
        {
            Bankacc acc1 = new Bankacc(1000, AccountType.Current); 
            Bankacc acc2 = new Bankacc(100, AccountType.Savings);  
            acc2.DepositFromOther(ref acc1, 400);
            Console.WriteLine(acc2.Balance);
        }
        static string Ex2(ref string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
             }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            input=new string(charArray);
            return input;
        }
        public static void Ex3()
        {
            Console.WriteLine("Введите имя файла");
            string NameOfFile = Console.ReadLine();
            if (File.Exists(NameOfFile))
            {
                string text = File.ReadAllText(NameOfFile);
                File.AppendAllText("Output.txt", text.ToUpper());
                Console.WriteLine("Обработка текста завершена, текст скопирован в новый файл");
                return;
            }
            else
            {
                Console.WriteLine("Такого файла нет");
                return;
            }
        }
        public static bool Ex4WithIs(object obj)
        {
            return obj is IFormattable;
        }
        public static bool Ex4WithAs(object obj)
        {
            IFormattable IsObjectFormattable = obj as IFormattable;
            if (IsObjectFormattable != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Ex5(ref string s)
        {
            s = s.Substring('#' + 1).Trim();
        }
        public static void SearchMail(ref string s)
        {
            int separatorIndex = s.IndexOf('#');

            if (separatorIndex != -1)
            {
                s = s.Substring(separatorIndex + 1).Trim();
            }
            else
            {
                s = string.Empty;
            }
        }

        public static void Hw1(string sourceFile, string targetFile)
        {
            try
            {
                if (!File.Exists(sourceFile))
                {
                    Console.WriteLine($"Ошибка: Исходный файл '{sourceFile}' не найден.");
                    return;
                }

                string[] lines = File.ReadAllLines(sourceFile);
                string[] emails = new string[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    SearchMail(ref line);

                    emails[i] = line;
                }

                File.WriteAllLines(targetFile, emails);
                Console.WriteLine($"Файл успешно обработан, данные перенесены в {targetFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обработке: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Упражнение 8.1");
            //Ex1();
            //Console.ReadKey();

            //Console.WriteLine("Упражнение 8.2");
            //string teststring = "Абракадабра";
            //Console.WriteLine($"Преобразованная строка равна:{Ex2(ref teststring)}");
            //Console.ReadKey();

            //Console.WriteLine("Упражнение 8.3");
            //Ex3();
            //Console.ReadKey();

            //Console.WriteLine("Упражнение 8.4");
            //Console.WriteLine(Ex4WithIs("Karim"));
            //Console.WriteLine(Ex4WithAs(2008));
            //Console.ReadKey();

            //Console.WriteLine("Домашнее задание 8.1");
            string inputPath = "NamesAndEmails.txt"; 
            string outputPath = "CopyOfEmails.txt";
            Hw1(inputPath,outputPath);

            Console.WriteLine("Домашнее задание 8.2");
            Song song1 = new Song();
            song1.SetName("Ride The lightning");
            song1.SetAuthor("Metallica");
            song1.SetPrev(null); 

            Song song2 = new Song();
            song2.SetName("Ich will");
            song2.SetAuthor("Rammstein");
            song2.SetPrev(song1); 

            Song song3 = new Song();
            song3.SetName("Ich will");
            song3.SetAuthor("Rammstein");
            song3.SetPrev(song2); 

            Song song4 = new Song();
            song4.SetName("Долгая счастливая жизнь");
            song4.SetAuthor("Гражданская оборона");
            song4.SetPrev(song3);

            List<Song> playlist = new List<Song> { song1, song2, song3, song4 };

            Console.WriteLine("Список песен:");
            foreach (Song song in playlist)
            {
                song.PrintTitle();
            }

            Console.WriteLine();
            bool areEqual = playlist[0].Equals(playlist[1]);
            Console.WriteLine($"Первая и вторая песни одинаковые? Ответ: {areEqual}");


        }
    }
}