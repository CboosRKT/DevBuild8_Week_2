//Going Simple this time... nothing too unnecessary

//Create Method ReverseString()
static string ReverseString(string mInput)
{

    Stack<string> mOutStack = new Stack<string>(); 
    
    foreach(char mChar in mInput)
    {      
        string tempChar = mChar.ToString();

        mOutStack.Push(tempChar);
    }

    string mOutput = "";

    if(mOutStack.Count > 0)
    {
        foreach (string mChar in mOutStack)
        {
            mOutput = mOutput + mChar;
        }
        return mOutput;
    }
    else
    {   
        return "";
    }
    
}


//Begin Program
//
//declare goAgain
bool goAgain = true;
//Do While for goAgain
//
while (goAgain)
{
    //
    //Print Greeting
    //
   
    //declare uValid Bool False
    bool uValid = false;
    string uString = "";
    //while !uValid 
    while (!uValid)
    {
        Console.Clear();
        Console.WriteLine("\n\n\n Welcome! Lets Try Reversing a Word! \n Please Enter a Word!");
        //Ask for a word and save it as string uInput
        uString = Console.ReadLine();
        //Check if uString is valid - otherwise ask for a new entry and loop!
        if(uString != "" && !uString.Contains(" "))
        {
            uValid = true;
        } else
        {
            Console.WriteLine("That was not a Valid Entry! Please enter a SINGLE word!");
            Thread.Sleep(2500);

            uValid = false;
        }
        //
    }
    //pass UString into ReverseString() to make String uOutput
    //
    Console.WriteLine();
    Console.WriteLine("Your word backwards is ");
    Console.Write (ReverseString(uString), "!");
    Console.WriteLine();

    //Writeline uOutput
    //
    //??goAgain??
    //
    Console.WriteLine("Would you like to go again? \n Press (y) to go Again! Press any other key to End.");
    ConsoleKeyInfo uKey = Console.ReadKey();
   String uAgain = (uKey.KeyChar).ToString();
    if (uAgain != "y")
    {
        goAgain = false;
    }
    Console.Clear();
}
Console.Clear();
Console.WriteLine("{0,35}","\n\n\n Good bye! \n\n\n");
//end Go Again
