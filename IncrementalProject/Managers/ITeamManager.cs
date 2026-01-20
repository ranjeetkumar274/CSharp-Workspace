using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Managers
{
    public interface ITeamManager
    {

        void AddTeam();

        void ListTeams();

        void AddTeamToDB();

        void ListTeamsFromDB();
        
    }
}
