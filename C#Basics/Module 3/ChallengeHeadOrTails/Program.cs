using System;

Random coinFlip = new Random();

string flipResult = coinFlip.Next(0, 2) == 1? "heads" : "tails";

Console.WriteLine(flipResult);
