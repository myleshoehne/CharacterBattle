using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Models.Characters
{
    internal class Goblin : CharacterBase
    {
        public Goblin(string name, int hp, int attackDamage, int healEffectiveness) : base(name, CharacterHelper.SpecialAttackDescriptions[CharacterHelper.Characters.Goblin], hp, attackDamage, healEffectiveness, CharacterHelper.Characters.Goblin, "Steal", 3)
        {
        }

        // Steal special attack takes away enemies max hp and increases own max hp by amount stolen
        public override void SpecialAttack(ref CharacterBase character)
        {
            if (CanUseSpecialAttack())
            {
                // Steal logic
                character.CurrHP -= AttackDamage;
                character.MaxHP -= AttackDamage;

                MaxHP += AttackDamage;

                // Write attack 
                Console.WriteLine();
                Console.WriteLine($"{Name} stole {AttackDamage} Max HP from {character.Name}");
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
