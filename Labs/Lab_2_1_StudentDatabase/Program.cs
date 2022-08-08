// Create a go again Object - returns a Bool
static bool GoAgain()
{
    while (true)
    {
        Console.WriteLine("Would you like to lookup another student? (y/n)");
        string uResponse = Console.ReadLine().ToLower();
        if (uResponse == "yes"|| uResponse == "y")
        {
            return true;
        } else if(uResponse == "no" || uResponse == "n")
        {
            Console.WriteLine("Good Bye!");
            Thread.Sleep(500);
            return false;
            
        }
        else
        {
            PrintHead();
            Console.WriteLine("Invalid Response. Please Enter Only Y or N.");
        }
        
    }
}

// Create a PrintHead object to print header

static void PrintHead()
{
    Console.Clear();
    Console.WriteLine("*******      ****************************************      ******");
    Console.WriteLine("*******          DevBuild 8 - Student Records v1.0         ******");
    Console.WriteLine("*******      ****************************************      ******");
    Console.WriteLine();
    Console.WriteLine();

}


//Create 3 arrays - 5 entries each 
//

//Array 1 Student Names
string[] sName = { "Scott Summers", "Jean Grey", "Ororo Munroe", "Henry McCoy", "Katherine Pryde" };
//Array 2 Student Home Town
string[] sTown = { "Anchorage, Alaska", "Annandale-on-Hudson, New York", "Cairo, Egypt", "Dundee, Illinois", "Deerfield, Illinois" };
//Array 3 Student favorite food
string[] sFood = { "Cheeseburgers", "Choclate Chip Cookies", "Ta'meya", "Twinkies", "S'mores" };
int sRecords = sName.Length;
do
{
    PrintHead();
    Console.WriteLine($"There are " + sName.Length + " student records.");
    //(optional) Prompt to search by name or number
    bool sMethod = false;
    bool sMethodNam = false;
    bool sNameSucc = false;
    bool sMethodAll = false;
    int uRecord = 0;
    do
    {
        Console.WriteLine("Would you like to search by student (name), student (number), or display (all) students?");
        //
        string uResponse = Console.ReadLine();
        uResponse = uResponse.Trim();
        uResponse = uResponse.ToLower();



        if (uResponse.Contains("nam"))
        {      //name
            sMethod = true; 
            sMethodNam = true;
            Console.WriteLine();

        }
        else if (uResponse.Contains("num") || uResponse.Contains("#"))
        {      //number
            sMethodNam = false;
            sMethod = true;

        } else if (uResponse[0].Equals('a') || uResponse.Contains("all"))
        {      //Display chosen information
            sMethod = true;
            sMethodNam = false;
            sMethodAll = true;
            Console.WriteLine();
            int count = 0;
            foreach (string sOut in sName)
            {
                count++;
                Console.Write($"{count} {sOut}, \n");

            }

        } else
        {
            PrintHead();
            if (sMethodAll)
            {
                
                int count = 0;
                Console.WriteLine();
                foreach (string sOut in sName)
                {
                    count++;
                    Console.Write($"{count} {sOut}, \n");

                }
            }
            Console.WriteLine("Invalid Response!");
        }


        //
    } while (!sMethod);

    //search and enter 


    //search by name
    if (sMethodNam)
    {
        bool uVerifyNam = false;
        uRecord = 0;
        do
        {
            Console.WriteLine("Please Enter the Students full or partial name that you wish to search for:");
            //
            string uResponse = Console.ReadLine();
            sNameSucc = false;
            uResponse = uResponse.Trim();
            uResponse = uResponse.ToLower();
            int sNameCount = 1;
            foreach (string sQuery in sName)
            {
                
                if ((sQuery.ToLower()).Contains(uResponse))
                {
                    sNameSucc = true;
                    Console.WriteLine($"{sNameCount} {sQuery},");
                }

                sNameCount++;

            }


            if (sNameSucc)
            {
                uVerifyNam = true;
            }

            else
            {
                uVerifyNam = false;
                PrintHead();
                Console.WriteLine("No Matching Records found!");

                Thread.Sleep(500);
                

            }
        } while (!uVerifyNam);


    }
    //search by name end

    
            uRecord = -1;
            //Prompt for student number
            bool uVerify = false;
            do
            {
                Console.WriteLine("Please enter the Student Record Number you wish to look up:");
                //
                if (int.TryParse(Console.ReadLine(), out uRecord) && uRecord >= 1 && uRecord <= 5)
                {
                    uVerify = true;

                }
                else
                {
                   

                    Console.WriteLine("Invalid Student Number!");
                }

                //
            } while (!uVerify);
   



    //Prompt for Hometown or Favorite Food.
    //(Optional allow partial catagory names or mixed upper and lower case
    bool uVerify2 = false;
    PrintHead();
    do
    {
        uRecord = uRecord -1;
        Console.WriteLine("Student "+ sName[uRecord]);
        Console.WriteLine("Which would you like to know about? (Favorite Food / Hometown):");
        //
        string uResponse = Console.ReadLine();
        uResponse = uResponse.Trim();
        uResponse = uResponse.ToLower();


        //if (uResponse[0].Equals('h') || uResponse == "hometown" || uResponse == "home town" || uResponse == "home" || uResponse =="town")
        if (uResponse[0].Equals('h') || uResponse.Contains("hom") || uResponse.Contains("tow"))
        {      //Display chosen information
            uVerify2 = true;
            Console.WriteLine($"Student #{uRecord+1}, {sName[uRecord]}, is from {sTown[uRecord]}.");

        }
        // else if (uResponse.Equals('f') || uResponse == "favoritefood" || uResponse == "favorite food" || uResponse == "favorite" || uResponse == "food")
        else if (uResponse[0].Equals('f') || uResponse.Contains("food") || uResponse.Contains("fav"))
        {    //Display chosen information
            uVerify2 = true;
            Console.WriteLine($"Student #{uRecord + 1}, {sName[uRecord]}'s favorite food is {sFood[uRecord]}.");

        } else
        {
            PrintHead();
            Console.WriteLine("Invalid Query!");
        }

        //
    } while (!uVerify2);





 
} while (GoAgain());
//prompt if would like to go again