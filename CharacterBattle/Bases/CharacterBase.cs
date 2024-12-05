using CharacterBattle.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CharacterBattle.Helpers.CharacterHelper;

namespace CharacterBattle.Bases
{
    internal abstract class CharacterBase
    {
        protected CharacterBase(string name, string description, int hp, int attackDamage, int healEffectiveness, CharacterHelper.Characters characterType, string specialAttackName, int specialAttackCoolDown)
        {
            Name = name;
            SpecialAttackDescription = description;
            MaxHP = hp;
            CurrHP = hp;
            AttackDamage = attackDamage;
            HealEffectiveness = healEffectiveness;
            CharacterType = characterType;
            SpecialAttackName = specialAttackName;
            SpecialAttackCoolDown = specialAttackCoolDown;
        }
        private int _currHP;
        private int _specialCoolDownCurr;
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrHP
        {
            get
            {
                return _currHP;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > MaxHP)
                {
                    value = MaxHP;
                }
                _currHP = value;
            }
        }
        public int AttackDamage { get; set; }
        public int HealEffectiveness { get; set; }
        public CharacterHelper.Characters CharacterType { get; set; }
        public string SpecialAttackName { get; set; }
        public string SpecialAttackDescription { get; set; }
        public int SpecialAttackCoolDown { get; set; }
        public int SpecialAttackCoolDownCurr
        {
            get
            {
                return _specialCoolDownCurr;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _specialCoolDownCurr = value;
            }
        }

        public void Attack(ref CharacterBase character)
        {
            // Attack logic
            character.CurrHP -= AttackDamage;

            // Decrease special attack cooldown 
            this.SpecialAttackCoolDownCurr--;

            // Write attack
            Console.WriteLine();
            Console.WriteLine($"{Name} attacked {character.Name} for {AttackDamage}");
            Console.WriteLine();
        }
        public void Heal()
        {
            // Heal logic
            CurrHP += HealEffectiveness;

            // Decrease special attack cooldown 
            this.SpecialAttackCoolDownCurr--;

            // Write heal
            Console.WriteLine();
            Console.WriteLine($"{this.Name} healed for {this.HealEffectiveness}");
            Console.WriteLine();
        }
        public virtual void SpecialAttack(ref CharacterBase character)
        {
            Console.WriteLine($"{CharacterType} does not have a special attack.");
        }
        public bool CanUseSpecialAttack()
        {
            if (SpecialAttackCoolDownCurr == 0)
            {
                SpecialAttackCoolDownCurr = SpecialAttackCoolDown;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CharacterSummary()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{Name.ToUpper()} SUMMARY");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** CHARACTER INFORMATION ***");
            Console.ResetColor();
            Console.WriteLine($"Name                  --> {Name}");
            Console.WriteLine($"Character Type        --> {CharacterType}");
            Console.WriteLine($"Special Attack        --> {SpecialAttackName}");
            Console.WriteLine($"Special Attack Desc.  --> {SpecialAttackDescription}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** CHARACTER STATS ***");
            Console.ResetColor();
            Console.WriteLine($"HP                    --> {CurrHP} / {MaxHP}");
            Console.WriteLine($"Attack Damage         --> {AttackDamage}");
            Console.WriteLine($"Health Regen Eff.     --> {HealEffectiveness}");
            Console.WriteLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
