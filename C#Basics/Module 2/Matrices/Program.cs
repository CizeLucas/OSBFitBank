/* 
string[] OrderIDs = {"B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"};
string[] fraudulentOrderIDs = new string[OrderIDs.Length];
int fraudulentOrderIDsIndex = 0;

foreach(string id in OrderIDs){ 

    if(id.StartsWith("B")){
        fraudulentOrderIDs[fraudulentOrderIDsIndex] = id;
        fraudulentOrderIDsIndex++;
        Console.WriteLine(id);
    }
}
fraudulentOrderIDsIndex = 0;
*/

/*****************************************************************************************************/

/*
   This code reverses a message, counts the number of times 
   a particular character appears, then prints the results
   to the console window.
 */
/*
string originalMessage = "The quick brown fox jumps over the lazy dog.";

char[] message = originalMessage.ToCharArray();
Array.Reverse(message);

int letterCount = 0;

string newMessage = new String(message);

Console.WriteLine(newMessage);
*/
