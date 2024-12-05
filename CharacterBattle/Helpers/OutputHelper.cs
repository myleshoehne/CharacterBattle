using CharacterBattle.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CharacterBattle.Helpers
{
    internal static class OutputHelper
    {
        public static void DisplayVersusHeading(CharacterBase player1, CharacterBase player2)
        {           
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            // Heading
            string text = "VERSUS GAME";
            Console.SetCursorPosition(centerX - (text.Length / 2), 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();

            // Opening line
            Console.SetCursorPosition(0, 3);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("^");
            }

            // Health bars
            text = GetHealthBar(player1.CurrHP, player1.MaxHP);
            Console.SetCursorPosition((centerX - text.Length / 2) - 30, 5);
            DisplayHealthBarFromString(text);
            Console.Write("     ");
            text = GetHealthBar(player2.CurrHP, player2.MaxHP);
            Console.SetCursorPosition((centerX - text.Length / 2) + 30, 5);
            DisplayHealthBarFromString(text);

            // Player names 
            text = $"{player1.Name}";
            Console.SetCursorPosition((centerX - 30) - text.Length / 2, 7);
            Console.Write(text);
            
            text = $"{player2.Name}";
            Console.SetCursorPosition((centerX + 30) - text.Length / 2, 7);
            Console.Write(text);


            // Attack
            text = $"Attack Damage >> {player1.AttackDamage} <<";
            Console.SetCursorPosition((centerX - 30) - text.Length / 2, 10);
            Console.Write(text);


            text = "Attack [1]";
            Console.SetCursorPosition(centerX - (text.Length / 2), 10);
            Console.Write(text);

            text = $"Attack Damage >> {player2.AttackDamage} <<";
            Console.SetCursorPosition((centerX + 30) - text.Length / 2, 10);
            Console.Write(text);

            // Heal
            text = $"Heal Eff. >> {player1.HealEffectiveness} <<";
            Console.SetCursorPosition((centerX - 30) - text.Length / 2, 12);
            Console.Write(text);


            text = "Heal [2]";
            Console.SetCursorPosition(centerX - (text.Length / 2), 12);
            Console.Write(text);

            text = $"Heal Eff. >> {player2.HealEffectiveness} <<";
            Console.SetCursorPosition((centerX + 30) - text.Length / 2, 12);
            Console.Write(text);

            // Special 
            text = $"Special Attack >> {player1.SpecialAttackName} | ";
            if (player1.SpecialAttackCoolDownCurr == 0)
            {
                text += $"Ready";
                Console.SetCursorPosition((centerX - 30) - text.Length / 2, 14);
                foreach (string i in text.Split("|"))
                {
                    if (i.Contains("Ready"))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(i);
                    }
                }
            }
            else
            {
                text += $"Ready in {player1.SpecialAttackCoolDownCurr}";
                Console.SetCursorPosition((centerX - 30) - text.Length / 2, 14);
                foreach (string i in text.Split("|"))
                {
                    if (i.Contains("Ready"))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(i);
                    }
                }
            }
            Console.Write(" <<");
            
            text = "Special [3]";
            Console.SetCursorPosition(centerX - (text.Length / 2), 14);
            Console.Write(text);

            text = $"Special Attack >> {player2.SpecialAttackName} | ";
            if (player2.SpecialAttackCoolDownCurr == 0)
            {
                text += $"Ready";
                Console.SetCursorPosition((centerX + 30) - text.Length / 2, 14);
                foreach (string i in text.Split("|"))
                {
                    if (i.Contains("Ready"))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(i);
                    }
                }
            }
            else
            {
                text += $"Ready in {player2.SpecialAttackCoolDownCurr}";
                Console.SetCursorPosition((centerX + 30) - text.Length / 2, 14);
                foreach (string i in text.Split("|"))
                {
                    if (i.Contains("Ready"))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(i);
                    }
                }
            }
            Console.Write(" <<");

            // Closing line
            Console.SetCursorPosition(0, 17);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("^");
            }
            Console.WriteLine();
        }

        public static void DisplayHealthBar(int currHp, int maxHp, bool displayHealth = true)
        {
            decimal currentHp = (decimal)currHp / 5;
            int healthLength = (int)Math.Ceiling(currentHp);

            decimal maxHealth = (decimal)maxHp / 5;
            int barLength = (int)Math.Ceiling(maxHealth);

            Console.Write("[");
            for (int i = 0; i < barLength; i++)
            {
                if (healthLength > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("#");
                    Console.ResetColor();

                    healthLength--;
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('-');
                    Console.ResetColor();
                }
            }
            Console.Write("]");

            if (displayHealth)
            {
                Console.Write($" {currHp}/{maxHp}");
            }
            
        }

        public static string GetHealthBar(int currHp, int maxHp, bool displayHealth = true)
        {
            decimal currentHp = (decimal)currHp / 5;
            int healthLength = (int)Math.Ceiling(currentHp);

            decimal maxHealth = (decimal)maxHp / 5;
            int barLength = (int)Math.Ceiling(maxHealth);

            StringBuilder bar = new StringBuilder();
            bar.Append("[");
            for (int i = 0; i < barLength; i++)
            {
                if (healthLength > 0)
                {
                    bar.Append("#");
                    healthLength--;
                }
                else
                {
                    bar.Append('-');
                }
            }

            bar.Append("]");

            if (displayHealth)
            {
                bar.Append($" {currHp}/{maxHp}");
            }
            
            

            return bar.ToString();
        }

        public static void DisplayHealthBarFromString(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("#");
                    Console.ResetColor();

                }
                else if (text[i] == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('-');
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(text[i]);
                }
            }
        }

        public static void DisplayVersusBattleLog(List<string> log)
        {
            int ogCursorTop = Console.CursorTop;
            int ogCursorLeft = Console.CursorLeft;

            
            Console.SetCursorPosition(0, Console.CursorTop + 5);
            for (int i = 0; i < log.Count;i++)
            {
                Console.Write($">> ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{log[i]}{Environment.NewLine}");
                Console.ResetColor();
            }
            Console.SetCursorPosition(ogCursorLeft, ogCursorTop);
        }
    }
}
