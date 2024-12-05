using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Models.Characters
{
    internal class Archer : CharacterBase
    {
        public Archer(string name, int hp, int attackDamage, int healEffectiveness) : base(name, CharacterHelper.SpecialAttackDescriptions[CharacterHelper.Characters.Archer], hp, attackDamage, healEffectiveness, CharacterHelper.Characters.Archer, "Life Bolt", 3)
        {
        }

        // Life Bolt randonly multiplies attack damage (0.5-1.5) and heals/deals damage with that new damage
        public override void SpecialAttack(ref CharacterBase character)
        {
            if (CanUseSpecialAttack())
            {
                Random random = new Random();
                double multiplier = 0.5 + random.NextDouble();

                int buffDamamge = AttackDamage + (int)Math.Round(AttackDamage * multiplier);

                CurrHP += buffDamamge;
                character.CurrHP -= buffDamamge;

                // Write Attack
                Console.WriteLine();
                Console.WriteLine($"{Name} stole {buffDamamge} HP from {character.Name}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"You must wait {SpecialAttackCoolDownCurr} more turns before using the special attack");
                Console.WriteLine();
            }
        }
    }
}
