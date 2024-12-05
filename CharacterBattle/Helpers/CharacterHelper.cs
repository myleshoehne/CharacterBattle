using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Helpers
{
    internal static class CharacterHelper
    {
        public enum Characters
        {
            Goblin, 
            Archer,
            Warrior
        }

        public static Dictionary<Characters, string> SpecialAttackDescriptions 
        {
            get
            {
                return new Dictionary<Characters, string>
                {
                    { Characters.Goblin, "Can steal a portion of enemies' maximum HP to permanently boost its own maximum HP. Additionally, it heals at twice the normal regeneration rate." },
                    { Characters.Archer, "The archer fires a special arrow that deals damage to enemies and heals the player for a random amount. The damage ranges from 50% to 150% of the archer's attack damage." },
                    { Characters.Warrior, "Enters a state of fury, doubling attack damage for one turn and immediately taking an additional turn" },
                };
            }
        }
    }
}
