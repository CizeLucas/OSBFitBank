string[] values = { "12,3", "45", "ABC", "11", "DEF" };
decimal numberResult = 0m;
string stringResult = "";

foreach(string value in values){
    decimal decimalTemp = 0m;
    if(decimal.TryParse(value, out decimalTemp))
        numberResult += decimalTemp;
    else 
        stringResult += value;
}

Console.WriteLine("Soma dos Numeros: " + numberResult);
Console.WriteLine("Concatenação das letras: " + stringResult);

/* -------------------------------------------------------------------------- */

int value1 = 11;
decimal value2 = 6.2m;
float value3 = 4.3f;

int result1 = Convert.ToInt32(value1/value2);
// Hint: You need to round the result to nearest integer (don't just truncate)
Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

decimal result2 = value2/(decimal)value3;
Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

float result3 = value3/value1;
Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");

/* -------------------------------------------------------------------------- */

string str = "4.123456789";
Console.WriteLine(Decimal.Parse(str));
Console.WriteLine(Convert.ToDecimal(str));