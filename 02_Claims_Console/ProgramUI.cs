using _02_Claims_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class ProgramUI
    {
        Claim_Repo _repo = new Claim_Repo();
        Queue<Claim> _listOfClaims = new Queue<Claim>();
        public void Run()
        {
            ExistingContentList();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToLoop = true;
            while(continueToLoop)
            {
                Console.Clear();
                Console.WriteLine("Please choose a menu item:\n" +
                    "\n" +
                    "1. See all claims\n" +
                    "\n" +
                    "2. Take care of next claim\n" +
                    "\n" +
                    "3. Enter a new claim\n" +
                    "\n" +
                    "4. Exit\n" +
                    "");
                string userPick = Console.ReadLine();
                switch(userPick)
                {
                    case "1":
                        //Show full list
                        ShowAllClaims();
                        break;
                    case "2":
                        //Get next claim
                        GetNextClaim();
                        break;
                    case "3":
                        //Add claim
                        AddClaimToList();
                        break;
                    case "4":
                        //Exit
                        continueToLoop = false;
                        break;
                    default:
                        Console.WriteLine("That was not one of the options, please try again ('1', '2', '3', etc");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddClaimToList()
        {
            Console.Clear();
            Claim addClaim = new Claim();
            Console.Write("Enter the claim id: ");
            addClaim.ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the claim type (1-Car, 2-Home, 3-Theft): # ");
            string typeClaim = Console.ReadLine();
            int typeID = int.Parse(typeClaim);
            addClaim.TypeOfClaim = (ClaimType)typeID;
            Console.Write("Enter a claim description: ");
            addClaim.Description = Console.ReadLine();
            Console.Write("Amount of damage: $ ");
            addClaim.Amount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Date of accident (ex - yyyy, mm, dd): ");
            addClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.Write("Date of claim (ex - yyyy, mm, dd): ");
            addClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            if (addClaim.IsValid)
            {
                Console.Write($"This claim is valid\n");
                Console.WriteLine("\n" +
                    "Claim added to queue\n" +
                    "\n" +
                    "Press any key to continue");
                Console.ReadKey();
            }
            else
                Console.ReadKey();
                _repo.AddClaim(addClaim);
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Console.WriteLine($"{"ClaimID"}   {"Type"}      {"Description"}               {"Amount"}       {"DateOfAccident"}        {"DateOfClaim"}       {"IsValid"}");
            Console.WriteLine("\n" +
                "");
            Queue<Claim> listOfClaims = _repo.GetListOfClaims();
            foreach(Claim items in listOfClaims)
            {
                DisplayContentAllClaims(items);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void GetNextClaim()
        {
            Console.Clear();
            Queue<Claim> claimList = _repo.GetListOfClaims();
            Claim any = claimList.Peek();
            Console.WriteLine(any);
            DisplayContentNextClaim(any);
            string answer = Console.ReadLine();
            switch(answer)
            {
                case "y":
                    //Dequeue
                    claimList.Dequeue();
                    Console.Clear();
                    Console.WriteLine("Claim removed from Queue");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case "n":
                    //Return To Menu
                    Run();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong letter champ\n" +
                        "");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
            }
        }
    private void DisplayContentAllClaims(Claim injury)
        { 
            Console.WriteLine($"{injury.ID,0}         {injury.TypeOfClaim}    {injury.Description,5}      ${injury.Amount}        {injury.DateOfIncident.ToString("dd/MM/yyyy")}            {injury.DateOfClaim.ToString("dd/MM/yyyy")}         {injury.IsValid}");
        }
        private void DisplayContentNextClaim(Claim injury)
        {
            Console.WriteLine($"ClaimID: {injury.ID} \n" +
                $"Type: {injury.TypeOfClaim} \n" +
                $"Description: {injury.Description} \n" +
                $"Amount: ${injury.Amount} \n" +
                $"DateOfAccident: {injury.DateOfIncident.ToString("dd/MM/yyy")} \n" +
                $"DateOfClaim: {injury.DateOfClaim.ToString("dd/MM/yyy")} \n" +
                $"IsValid: {injury.IsValid}\n" +
                $"\n" +
                $"Do you want to deal with this claim now(y/n)?");
        }
        private void ExistingContentList()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "  Dude where's my car  ", 50000, new DateTime(2020, 07, 04), new DateTime(2020, 07, 06));
            Claim claimTwo= new Claim(2, ClaimType.Home, " Dude where's my house", 15000, new DateTime(2019, 05, 22), new DateTime(2020, 03, 24));
            Claim claimThree = new Claim(3, ClaimType.Theft, "Dude where's my stuff", 50000, new DateTime(2020, 01, 15), new DateTime(2020, 01, 30));
            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
    }
}
