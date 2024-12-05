using CharacterBattle.Bases;
using CharacterBattle.Helpers;
using CharacterBattle.Interfaces;
using CharacterBattle.Models;
using CharacterBattle.Models.Battles;
using CharacterBattle.Models.Characters;
using CharacterBattle.Models.Games;

namespace CharacterBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to begin the Versus Battle");
            Console.ReadKey();
            Console.Clear();

            IGame versusGame = new VersusGame();
            versusGame.Start();


        }
    }
}
