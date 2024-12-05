using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using CharacterBattle.Interfaces;
using CharacterBattle.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Models.Battles
{
    internal class VersusBattle : IBattle
    {
        public VersusBattle(CharacterBase player1, CharacterBase player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }
        private CharacterBase _player1;
        private CharacterBase _player2;
        public CharacterBase Player1
        {
            get
            {
                return _player1;
            }
            set
            {
                _player1 = value;
            }
        }
        public CharacterBase Player2
        {
            get
            {
                return _player2;
            }
            set
            {
                _player2 = value;
            }
        }
        public int PlayerTurn { get; set; } = 1;
        public bool BattleOver
        {
            get
            {
                return Player1.CurrHP <= 0 || Player2.CurrHP <= 0;
            }
        }
        public CharacterBase? Winner
        {
            get
            {
                if(this.Player1.CurrHP <= 0)
                {
                    return this.Player2;
                }
                else if(this.Player2.CurrHP <= 0)
                {
                    return this.Player1;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<string> BattleLog { get; set; } = new List<string>();

        public void ExecuteTurn()
        {
            Console.WriteLine();
            if (PlayerTurn == 1)
            {
                Console.Write($"{Player1.Name}'s turn: ");

                ConsoleKeyInfo move = Console.ReadKey();
                if (move.Key == ConsoleKey.D1)
                {
                    Player1.Attack(ref _player2);
                    this.BattleLog.Add($"{this.Player1.Name} attacked {this.Player2.Name} ({this.Player1.AttackDamage})");
                }
                else if (move.Key == ConsoleKey.D2)
                {
                    Player1.Heal();
                    this.BattleLog.Add($"{this.Player1.Name} healed ({this.Player1.HealEffectiveness})");
                }
                else if (move.Key == ConsoleKey.D3)
                {
                    Player1.SpecialAttack(ref _player2);
                    this.BattleLog.Add($"{this.Player1.Name} special attacked - {this.Player1.SpecialAttackName} - {this.Player2.Name} ({this.Player1.AttackDamage})");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Oops you missed");
                    this.BattleLog.Add($"{this.Player1.Name} slipped");
                    Console.WriteLine();
                }

                PlayerTurn = 2;
            }
            else if (PlayerTurn == 2)
            {
                Console.Write($"{Player2.Name}'s turn: ");

                ConsoleKeyInfo move = Console.ReadKey();
                if (move.Key == ConsoleKey.D1)
                {
                    Player2.Attack(ref _player1);
                    this.BattleLog.Add($"{this.Player2.Name} attacked {this.Player1.Name} ({this.Player2.AttackDamage})");
                }
                else if (move.Key == ConsoleKey.D2)
                {
                    Player2.Heal();
                    this.BattleLog.Add($"{this.Player2.Name} healed ({this.Player2.HealEffectiveness})");
                }
                else if (move.Key == ConsoleKey.D3)
                {
                    Player2.SpecialAttack(ref _player1);
                    this.BattleLog.Add($"{this.Player2.Name} special attacked {this.Player1.Name} ({this.Player2.SpecialAttackName})");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Oops you missed");
                    this.BattleLog.Add($"{this.Player2.Name} slipped");
                    Console.WriteLine();
                }

                PlayerTurn = 1;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Invalid Player # - {PlayerTurn} - Versus Battle is only two player.");
                Console.WriteLine();

                PlayerTurn = 1;
            }

            Thread.Sleep(2000); // stop program to display action message
            Console.Clear();
        }

        public void Start()
        {
            OutputHelper.DisplayVersusHeading(this.Player1, this.Player2);

            while (!BattleOver)
            {
                OutputHelper.DisplayVersusBattleLog(this.BattleLog);
                ExecuteTurn();
                OutputHelper.DisplayVersusHeading(this.Player1, this.Player2); // Display for next iteration
            }

            Console.WriteLine("Battle Over!");
        }
    }
}