Console.WriteLine("\n ---------------------------------------- \n");

string message = "Return what is (inside the parentheses)";

int openingPosition = message.IndexOf('(');
int closingPosition = message.IndexOf(')');

// Console.WriteLine(openingPosition);
// Console.WriteLine(closingPosition);

openingPosition++;
int length = closingPosition - openingPosition;

// Console.WriteLine(length);
// nConsole.WriteLine(message[closingPosition]);

Console.WriteLine(message.Substring(openingPosition, length));

/***********************************************************************************************************/
Console.WriteLine("\n ---------------------------------------- \n");

string message2 = "What is the value <span>between the tags</span>?";

const string openSpan = "<span>";
const string closeSpan = "</span>";

int openingPosition2 = message2.IndexOf(openSpan);
int closingPosition2 = message2.IndexOf(closeSpan);

openingPosition2 += openSpan.Length;
int length2 = closingPosition2 - openingPosition2;

Console.WriteLine(message2.Substring(openingPosition2, length2));

/***********************************************************************************************************/
Console.WriteLine("\n ---------------------------------------- \n");

string message3 = "(What if) there are (more than) one (set of parentheses)?";
while (true)
{
    int openingPosition3 = message3.IndexOf('(');
    if (openingPosition3 == -1) break;

    openingPosition3 += 1;
    int closingPosition3 = message3.IndexOf(')');
    int length3 = closingPosition3 - openingPosition3;
    Console.WriteLine(message3.Substring(openingPosition3, length3));

    // Note the overload of the Substring to return only the remaining 
    // unprocessed message:
    message3 = message3.Substring(closingPosition3 + 1);
}

/***********************************************************************************************************/
Console.WriteLine("\n ---------------------------------------- \n");

string message4 = "Help (find) the {opening symbols}";
Console.WriteLine($"Searching THIS Message: {message4}");
char[] openSymbols = { '[', '{', '(' };
int startPosition4 = 5;
int openingPosition4 = message4.IndexOfAny(openSymbols);
Console.WriteLine($"Found WITHOUT using startPosition: {message4.Substring(openingPosition4)}");

openingPosition4 = message4.IndexOfAny(openSymbols, startPosition4);
Console.WriteLine($"Found WITH using startPosition {startPosition4}:  {message4.Substring(openingPosition4)}");

Console.WriteLine("\n ---------------------------------------- \n");

/*
string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// The IndexOfAny() helper method requires a char array of characters. 
// You want to look for:

char[] openSymbols = { '[', '{', '(' };

// You'll use a slightly different technique for iterating through 
// the characters in the string. This time, use the closing 
// position of the previous iteration as the starting index for the 
//next open symbol. So, you need to initialize the closingPosition 
// variable to zero:

int closingPosition = 0;

while (true)
{
    int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

    if (openingPosition == -1) break;

    string currentSymbol = message.Substring(openingPosition, 1);

    // Now  find the matching closing symbol
    char matchingSymbol = ' ';

    switch (currentSymbol)
    {
        case "[":
            matchingSymbol = ']';
            break;
        case "{":
            matchingSymbol = '}';
            break;
        case "(":
            matchingSymbol = ')';
            break;
    }

    // To find the closingPosition, use an overload of the IndexOf method to specify 
    // that the search for the matchingSymbol should start at the openingPosition in the string. 

    openingPosition += 1;
    closingPosition = message.IndexOf(matchingSymbol, openingPosition);

    // Finally, use the techniques you've already learned to display the sub-string:

    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}
*/