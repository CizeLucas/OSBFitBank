/*
    -> Rules:
A valid IPv4 address consists of four numbers separated by dots
Each number must not contain leading zeroes
Each number must range from 0 to 255
*/

string[] ipv4Input = {"107.31.1.5", "255.0.0.255", "555..0.555", "255...255"};

foreach (string ip in ipv4Input) 
{
    string[] address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);

    if (ValidateLength(address) && ValidateZeroes(address) && ValidateRange(address)) 
    {
        Console.WriteLine($"{ip} is a valid IPv4 address");
    } 
    else 
    {
        Console.WriteLine($"{ip} is an invalid IPv4 address");
    }
}

bool ValidateLength(string[] address) 
{
    return address.Length == 4;
};

bool ValidateZeroes(string[] address) 
{
    foreach (string number in address) 
    {
        if (number.Length > 1 && number.StartsWith("0")) 
        {
            return false;
        }
    }

    return true;
}

bool ValidateRange(string[] address) 
{
    foreach (string number in address) 
    {
        int value = int.Parse(number);
        if (value < 0 || value > 255) 
        {
            return false;
        }
    }
    return true;
}