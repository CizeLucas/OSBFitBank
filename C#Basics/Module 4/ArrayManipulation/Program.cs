using System;

string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 3);
Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

/* -------------------------------------------------------------------------- */

string pangram = "The quick brown fox jumps over the lazy dog";
string[] pangramWords = pangram.Split(' ');
string[] pangramWordsReversed = new string[pangramWords.Length];
for(int i=0; i<pangramWords.Length; i++){
    char[] charTemp = pangramWords[i].ToCharArray();
    Array.Reverse(charTemp);
    pangramWordsReversed[i] = new string(charTemp);
}
string pangramReversed = String.Join(' ', pangramWordsReversed);
Console.WriteLine(pangramReversed);
/* Output: ehT kciuq nworb xof spmuj revo eht yzal god */