using CharacterBattle.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Interfaces
{
    internal interface IBattle
    {
        void Start();
        void ExecuteTurn();
        CharacterBase? Winner { get; }
        List<string> BattleLog { get; set; }
    }
}
