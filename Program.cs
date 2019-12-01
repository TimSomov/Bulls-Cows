using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestGame
{
    static void Main(string[] args)
    {
        var rnd = new Random();
        int[] num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for(int i = 0; i < 9; i++)
        {
            int j = rnd.Next(i + 1, 10);
            int k = num[i];
            num[i] = num[j];
            num[j] = k;
        }
        Console.WriteLine("Отгдай число из 4 неповторяющихся цифр!");

        while (true)
        {
            var s = Console.ReadLine();

            //Обрабатываем ошибки

            if(s.Length != 4)
            {
                Console.WriteLine("Число должно быть из 4 ЦИФР!");
                continue;
            }
            if(s[0] == s[1] || s[0] == s[2] || s[0] == s[3] || s[1] == s[2] || s[2] == s[3])
            {
                Console.WriteLine("Цифры не должны повторяться!");
                continue;
            }
            if (!s.All(ch=>char.IsDigit(ch)))
            {
                Console.WriteLine("Вводить нужно только цифры!");
                continue;
            }

            //Приступаем к игре

            int bulls = 0, cows = 0;
            int[] ans = s.Select(ch => ch - 48).ToArray();

            //Считаем быков и коров

        for(int i=0; i<4; i++)
            {
                if (ans[i] == num[i])
                    bulls++;
                else
                    foreach (var dig in num.Take(4))
                        if (dig == ans[i])
                            cows++;
            }
            Console.WriteLine($"Быки: {bulls}, Коровы: {cows}");
            if (bulls == 4)
                break;
        }
        Console.WriteLine("Отлично! Число отгадано!");
        Console.ReadKey();
    }
}