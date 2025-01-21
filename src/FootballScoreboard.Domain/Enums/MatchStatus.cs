using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreboard.Domain.Enums;
public enum MatchStatus : byte
{
    NotStarted,
    FirstHalf,
    Halftime,
    SecondHalf,
    Finished
}
