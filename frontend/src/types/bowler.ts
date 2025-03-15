// Creates an object of Bowler

export type Bowler = {
  bowlerId: number;
  bowlerFirstName: string;
  bowlerMiddleInit: string | null;
  bowlerLastName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: number;
  bowlerPhoneNumber: number;
  teamId: number | null; // Add teamId to Bowler
  teamName: string;
};
