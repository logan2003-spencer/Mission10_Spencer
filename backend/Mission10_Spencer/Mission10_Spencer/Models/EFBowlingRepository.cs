using Microsoft.EntityFrameworkCore;

namespace Mission10_Spencer.Models;

public class EFBowlingRepository : IBowlingRepository
{
    private BowlingLeagueContext _context;
    // private IBowlingRepository _bowlingRepositoryImplementation;

    public EFBowlingRepository(BowlingLeagueContext temp)
    {
        _context = temp;
    }

    // Method to get the list of bowlers and their associated team name
    public List<BowlerWithTeam> GetBowlersWithTeam()
    {
        var result = _context.Bowlers
            .Include(b => b.Team) // Join the Team table
            .Select(b => new BowlerWithTeam
            {
                BowlerFirstName = b.BowlerFirstName,
                BowlerMiddleInit = b.BowlerMiddleInit,
                BowlerLastName = b.BowlerLastName,
                BowlerAddress = b.BowlerAddress,
                BowlerCity = b.BowlerCity,
                BowlerState = b.BowlerState,
                BowlerZip = b.BowlerZip,
                BowlerPhoneNumber = b.BowlerPhoneNumber,
                TeamName = b.Team != null ? b.Team.TeamName : "No Team" // Handle null team
            })
            .ToList();
        
        // Console.WriteLine($"Fetched {result.Count} bowlers"); // Debugging output

        return result;
    }


    public List<Bowler> Bowlers => _context.Bowlers.ToList();
}

// Grabs the bowler teams as well
public class BowlerWithTeam
    {
        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string? BowlerMiddleInit { get; set; }
        
        public string? BowlerAddress { get; set; }

        public string? BowlerCity { get; set; }

        public string? BowlerState { get; set; }

        public string? BowlerZip { get; set; }

        public string? BowlerPhoneNumber { get; set; }

        public string TeamName { get; set; } // Added to hold the team name
    }

