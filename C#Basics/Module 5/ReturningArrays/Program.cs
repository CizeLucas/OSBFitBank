Random random = new Random();
string[,] strings = new string[5,10];
int count=0;

generateRandomStrings(strings);

foreach (string s in strings){
    Console.WriteLine(s);
    count++;
}
//Console.WriteLine(count);

void generateRandomStrings(string[,] str){
    for(int j = 0; j < 5; j++)
        for(int i = 0; i<10; i++){
            str[j,i] += ((char) random.Next(65, 91))+" "; //65 ("A") até 90 ("Z")
            str[j,i] += ((char) random.Next(65, 91))+" "; //65 ("A") até 90 ("Z")
            str[j,i] += (char) random.Next(65, 91); //65 ("A") até 90 ("Z")
            }
}