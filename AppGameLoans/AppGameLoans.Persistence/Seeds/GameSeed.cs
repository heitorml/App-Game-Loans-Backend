using AppGameLoans.Domain.Entities;
using System.Collections.Generic;


namespace AppGameLoans.Persistence.Seeds
{
    public static class GameSeed
    {
        public static List<Game> DefaultGames()
        {
            var gameList = new List<Game>()
            {
                new Game()
                {
                    Name="Mortal Kombat Ultimate 4"
                },
                 new Game()
                {
                    Name="GTA V"
                },
                  new Game()
                {
                    Name="Super Mario World"
                },
                    new Game()
                {
                    Name="Call of Duty - Warzone"
                },
                      new Game()
                {
                    Name="PLAYERUNKNOWN'S BATTLEGROUNDS"
                }
            };
            return gameList;
        }
    }
}
