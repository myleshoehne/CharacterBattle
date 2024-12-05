using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Models.Characters
{
    internal class Warrior : CharacterBase
    {
        public Warrior(string name, int hp, int attackDamage, int healEffectiveness) : base(name, CharacterHelper.SpecialAttackDescriptions[CharacterHelper.Characters.Warrior], hp, attackDamage, healEffectiveness, CharacterHelper.Characters.Warrior, "Bezerk", 3)
        {
        }

        // Beserk special attack does 1.5x the base damage and lets player go again
        public override void SpecialAttack(ref CharacterBase character)
        {
            if (CanUseSpecialAttack())
            {
                // Attack logic
                int bezerkDamage = (int)Math.Ceiling(AttackDamage * 1.5);
                character.CurrHP -= bezerkDamage;
                // TODO: need logic to keep it the same players turn

                // Write attack
                Console.WriteLine();
                Console.WriteLine($"{Name} went bezerk on {character.Name}. Dealing {bezerkDamage} damage.");
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
