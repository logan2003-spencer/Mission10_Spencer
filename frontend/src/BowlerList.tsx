import { useEffect, useState } from "react";
import {Bowler} from "./types/bowler";
// import { Team } from "./types/teams";


function BowlerList () {

  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  // const [teams, setTeams] = useState<Team[]>([]);


  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5003/api/bowler');
      const data = await response.json();
      // Filter only Marlins and Sharks bowlers
      const filteredBowlers = data.filter((b: Bowler) => b.teamName === "Marlins" || b.teamName === "Sharks");

      setBowlers(filteredBowlers);
    };

    fetchBowler();

  }, []);


  // // Fetch teams
  // useEffect(() => {
  //   const fetchTeam = async () => {
  //     const response = await fetch("https://localhost:5003/api/team");  // Adjust the API endpoint as needed
  //     const data = await response.json();
  //     setTeams(data);
  //   };
  //   fetchTeam();
  // }, []);


  //   // Join the bowlers with the corresponding team name
  // const getTeamNameById = (teamId: number | null) => {
  //   const team = teams.find((team) => team.teamId === teamId);
  //   return team ? team.teamName : "No Team";
  // };


  return (
    <>
      <h1>Bowlers</h1>
      <table>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Middle Initial</th>
            <th>Last Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
            <th>Team Name</th>
          </tr>
        </thead>
        <tbody>
          {
            bowlers.map((f) => (
              <tr key={f.bowlerId}>
                <td>{f.bowlerFirstName}</td>
                <td>{f.bowlerMiddleInit}</td>
                <td>{f.bowlerLastName}</td>
                <td>{f.bowlerAddress}</td>
                <td>{f.bowlerCity}</td>
                <td>{f.bowlerState}</td>
                <td>{f.bowlerZip}</td>
                <td>{f.bowlerPhoneNumber}</td>
                <td>{f.teamName}</td> {/* Fetch team name by teamId */}
                </tr>
            ))
          }
        </tbody>
      </table>
    </>
  );
}




export default BowlerList