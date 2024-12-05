using CharacterBattle.Bases;
using CharacterBattle.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Helpers
{
    internal static class InputHelper
    {
        public static CharacterBase BuildCharacter()
        {
            // Get name
            Console.WriteLine();
            Console.WriteLine("Name Your Character...");
            string name = Console.ReadLine();

            // Get character type
            Console.WriteLine();
            Console.WriteLine("Select Character Type...");
            for(int i = 0; i < Enum.GetValues(typeof(CharacterHelper.Characters)).Length; i++)
            {
                Console.WriteLine($"{i} - {(CharacterHelper.Characters)i}");
            }
            string typeInput = Console.ReadLine();
            int type = int.Parse(typeInput);

            // Get Max HP
            Console.WriteLine();
            Console.WriteLine("Maximum Health Points...");
            string healthPointInput = Console.ReadLine();
            int maxHP = int.Parse(healthPointInput);

            // Get attack damage
            Console.WriteLine();
            Console.WriteLine("Attack Damage...");
            string attackDamageInput = Console.ReadLine();
            int attackDamage = int.Parse(attackDamageInput);

            // Get health regen
            Console.WriteLine();
            Console.WriteLine("Health Regen Effectiveness...");
            string healthEffInput = Console.ReadLine();
            int healthEff = int.Parse(healthEffInput);

            // return character based off type
            switch (type)
            {
                case (int)CharacterHelper.Characters.Archer:
                    return new Archer(name, maxHP, attackDamage, healthEff);
                case (int)CharacterHelper.Characters.Warrior:
                    return new Warrior(name, maxHP, attackDamage, healthEff);
                default:
                    return new Goblin(name, maxHP, attackDamage, healthEff);
            }
        }
    }
}
