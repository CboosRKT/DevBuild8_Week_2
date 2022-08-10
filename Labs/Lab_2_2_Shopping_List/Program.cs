//Learn how to create custom Methods that can be used in multiple programs WITHOUT Copy Pasta


//Pizzazz Methods
//
// PrintHead()
//
static void PrintHead()
{
    Console.Clear();
    Console.WriteLine("******          **************************************          ******");
    Console.WriteLine("******              Build Dev8 Shopping List  v1.0              ******");
    Console.WriteLine("******          **************************************          ******");
    Console.WriteLine();
}
// ProgSleep()
//
static void ProgSleep()
{
    
   // Console.WriteLine();
    for (int i = 0; i < 35; i++)
    {
        Console.Write("* ");
        Thread.Sleep(10);
    }
}
//
// END Pizzazz Methods




//BEGIN shopping list app

//Declare all "Program Wide" Variables and Datas

//Declare GoAgain for shopping loop
bool GoAgain = false;

Dictionary<string, decimal> inventoryList = new Dictionary<string, decimal> {
    {"apple", 0.75m},
    {"bananas", 0.65m},
    {"carrots", 1.75m},
    {"detergent", 12.18m},
    {"epsom salt", 4.97m},
    {"fritos", 1.25m},
    {"graham crackers", 3.29m},
    {"heavy cream", 2.58m},
    {"ice cream", 4.48m},
    {"jack fruit", 17.48m},
    {"klondike bar", 4.24m},
    {"lentils", 1.59m},
    {"macaroni & cheese", 0.99m}
};
//Data name 8 items with price
//
//Place Holder data for UserOrder
List<string> userOrder = new List<string>();
//
//Begin Shopping DoWhile
do
{
    bool uFound = false;
    do
    {

        //Declare Internal Datas or Var
        //
        
        int ii = 0;
        Dictionary<int, string> menuIndex = new Dictionary<int, string>(); //for adding number calls to items

        //
        //Print Head and pleasantries 
        PrintHead();
        // ProgSleep();
        PrintHead();

        //Begin Print Inventory List
        foreach (KeyValuePair<string, decimal> item in inventoryList)
        {
            ii++;
            string itemName = item.Key;
            decimal itemPrice = item.Value;

            //create a nicer output
            bool itemSpaces = true;
            string modItemName = itemName;
            char modChar = char.ToUpper(itemName[0]);
            modItemName = modItemName.Remove(0,1);
            modItemName = modChar + modItemName;
            int modSpaces = itemName.IndexOf(" ");
            do
            {
                
                if (modSpaces >= 0)
                {
                    string modItemName2 = modItemName.Substring(modSpaces);
                    char modChar2 = char.ToUpper(modItemName2[1]);
                    modItemName2 = modItemName2.Remove(0,2);
                    modItemName2 = modChar2 + modItemName2;
                    modItemName = modItemName.Substring(0, modSpaces);
                    modItemName = modItemName +" "+ modItemName2;
                }
                else { itemSpaces = false; }
                modSpaces = itemName.IndexOf(" ", modSpaces+1);
            } while (itemSpaces);

         
            //end nicer output

            string itemOut = string.Format("\t {0, 6} \t {1,-25} {2,-20:C}", "(" + ii + ")", modItemName, itemPrice);
            menuIndex.Add(ii, itemName);
            Console.WriteLine(itemOut);


        }
        //End Print Inventory List

        Console.WriteLine();
        Console.WriteLine("\t \t Welcome! What can I help you buy today? \n Please enter an (item name) or (number) to add to your cart.");
        //INPUT ask user for an item name
        string uSearch = (Console.ReadLine().ToLower()).Trim();

        bool uIsNum = int.TryParse(uSearch, out int uIndex); //check to see if INT so we can use short cuts
       
        if (!uIsNum) //if not INT then uSearch by name
        {

            if (inventoryList.ContainsKey(uSearch))
            {
                uFound = true;
            }
            else
            {
                uFound=false;
            }

        }
        else if (uIsNum && menuIndex.ContainsKey(uIndex)) //check to see if INT is an item offered or kick back error and move on to the loop
        {
            uFound = true;
            uSearch = menuIndex[uIndex];  //convert INT to item name
        }
        else if (uIsNum && !menuIndex.ContainsKey(uIndex))
        { 
            uFound = false;
        }
        else
        {           
            uFound = false;
        }

        if (uFound)
        {   //if itrem does exist, display the item and price and add to UserOrder
            userOrder.Add(uSearch);
            PrintHead();
            ProgSleep();
            PrintHead();
            decimal iPrice = inventoryList[uSearch];
            Console.WriteLine();
            Console.WriteLine(uSearch + " for "+ iPrice + "added to order!");
        }
        else
        {         //if item not available, error report and ask for new item
            PrintHead();
            ProgSleep();
            PrintHead();
            Console.WriteLine("Sorry, Item not found! Please Enter a new Item!");
            Thread.Sleep(500);
            Console.WriteLine("Press Any Key to Search for another item.");
            Console.ReadKey();
        }

    } while (!uFound);

    //After an item has been added, ask if they want to add more items
    //do while uValid = false
    bool uValid = false;
    do
    {

        Console.WriteLine("\n Would you like to continue shopping? (y/n)");
        string uResponse = Console.ReadLine().ToLower().Trim(); 
  
      
        if (uResponse != "" && uResponse[0] == 'y')
        {
            GoAgain = true;
            uValid = true;
        }
        else if (uResponse != "" && uResponse[0] == 'n')
        {
            GoAgain = false;
            uValid = true;
        }
        else
        {
            uValid = false;
            PrintHead();
            Console.WriteLine($"That was NOT a valid response - Please only enter (y/n)!");
            ProgSleep();
            PrintHead();
        }


    } while (!uValid);     
    //end do while uValid

} while (GoAgain);
//End Shopping DoWhile
//
//When done with shopping, list items with prices in colums and a SUM total of all items and costs

PrintHead();
ProgSleep();
PrintHead();

Console.WriteLine("------------[Items]----------- \t ---[Cost]---\n");
decimal total = 0.00m;
foreach (string item in userOrder)
{
    decimal iPrice = inventoryList[item];
    
    //pretty up output
    bool itemSpaces = true;
    string modItemName = item;
    char modChar = char.ToUpper(item[0]);
    modItemName = modItemName.Remove(0, 1);
    modItemName = modChar + modItemName;
    int modSpaces = item.IndexOf(" ");
    do
    {

        if (modSpaces >= 0)
        {
            string modItemName2 = modItemName.Substring(modSpaces);
            char modChar2 = char.ToUpper(modItemName2[1]);
            modItemName2 = modItemName2.Remove(0, 2);
            modItemName2 = modChar2 + modItemName2;
            modItemName = modItemName.Substring(0, modSpaces);
            modItemName = modItemName + " " + modItemName2;
        }
        else { itemSpaces = false; }
        modSpaces = item.IndexOf(" ", modSpaces + 1);
    } while (itemSpaces);
    //end pretty

    Console.WriteLine("{0, -25}{1,14:C}", item, iPrice );
    total = total + iPrice;

}
Console.WriteLine("\n");

Console.WriteLine("[---Total---]");
Console.WriteLine("{1, 8:C}","  ", total);
Console.WriteLine();
//Display the most and least expensive items ordered --- Declare Decimals "mostCost" and "leastCost" set both values to the inVentory decimal for the first item on userOrder
//Declare Strings "mCostName" and "lCostName" same deal as above
//Run a ForEach() that would cycle through userOrder and compare the inVentory decimal to the mostCost and leastCost if the ForEach value is a better match than change values
//for coresponding decimals and strings.
decimal mostCost = inventoryList[userOrder[0]];
decimal leastCost = inventoryList[userOrder[0]];
string mCostName = userOrder[0];
string lCostName = userOrder[0];

foreach (string item in userOrder)
{
    decimal compare = 0.00m;
    compare = inventoryList[item];
    if (compare < leastCost)
    {
       leastCost = compare;
        lCostName = item;
    }
    if (compare > mostCost)
    {
        mostCost = compare;
        mCostName = item;
    }
}

Console.WriteLine($"Most Expensive Item: {mCostName}");
Console.WriteLine($"Least Expensive Item: {lCostName}");

Console.ReadKey();
//END shopping list app





//Bonus

//Display the most and least expensive items ordered --- Declare Decimals "mostCost" and "leastCost" set both values to the inVentory decimal for the first item on userOrder
//Declare Strings "mCostName" and "lCostName" same deal as above
//Run a ForEach() that would cycle through userOrder and compare the inVentory decimal to the mostCost and leastCost if the ForEach value is a better match than change values
//for coresponding decimals and strings.
//
//Print Results