using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Managers
{
    public interface IPlayerManager
    {
        void AddPlayer(int teamId);

        void ListPlayers();

        void FindPlayer(string name);
        
        void EditPlayer();

        void DeletePlayer();

        void AddPlayerToDB(int teamId);

        void ListPlayersFromDB();

        void EditPlayerInDB();

        void DeletePlayerFromDB();
    }
}
