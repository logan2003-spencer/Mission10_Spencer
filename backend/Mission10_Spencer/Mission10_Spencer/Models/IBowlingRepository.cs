namespace Mission10_Spencer.Models;

public interface IBowlingRepository
{
    List<Bowler> Bowlers { get; }
    List<BowlerWithTeam> GetBowlersWithTeam();  // Change this line to return List<BowlerWithTeam>
}