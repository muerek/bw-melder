using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Crews;

public class CrewStatusResponse
{
    public required RaceResponse Race { get; set; }

    public required ClubResponse Club { get; set; }

    public required int RegisteredAthletes { get; set; }
}
