using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using CharacterBattle.Interfaces;
using CharacterBattle.Models.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterBattle.Models.Games
{
    internal class VersusGame : IGame
    {
        private VersusBattle _battle;
        private CharacterBase _player1;
        private CharacterBase _player2;

        //WHEN BACK FIX THIS, WE SHOULD BE ABLE TO JUST CALL GET DETAILS AND IT GETS DETAILS NOT SET IT UP IN CONSTRUCTOR
        public void GetGameDetails()
        {
            Console.WriteLine("Player 1, build your character...");
            _player1 = InputHelper.BuildCharacter();

            Console.WriteLine("Player 2, build your character");
            _player2 = InputHelper.BuildCharacter();

            _battle = new VersusBattle(_player1, _player2);
        }

        public void Start()
        {
            this.GetGameDetails();

            Console.Clear();

            _battle.Start();

            

            Console.WriteLine($"Game over! {_battle.Winner?.Name} Wins!!");

            OutputHelper.DisplayVersusBattleLog(_battle.BattleLog);

            Console.ReadKey();
        }
    }
}
