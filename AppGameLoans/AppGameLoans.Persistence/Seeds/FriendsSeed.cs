using AppGameLoans.Domain.Entities;
using System.Collections.Generic;


namespace AppGameLoans.Persistence.Seeds
{
    public static class FriendsSeed
    {
        public static List<Friend> DefaultFriends()
        {
            var friendList = new List<Friend>()
            {
                new Friend()
                {
                    Name="Joe Satriani"
                },
                new Friend()
                {
                    Name="Tom Morelo"
                },
                new Friend()
                {
                    Name="Steve Vai"
                },
                new Friend()
                {
                    Name="Brian May"
                },
                new Friend()
                {
                    Name="Richie Sambora"
                }
            };
            return friendList;
        }
    }
}
