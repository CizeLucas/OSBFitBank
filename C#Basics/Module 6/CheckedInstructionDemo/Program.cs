int a = int.MaxValue; // maior valor possível para um inteiro
int b = 1;
int result;

try{

    checked
    {
        result = a + b; // Isso causará um estouro de aritmética
    }
    Console.WriteLine(result);

} catch (Exception ex){
    Console.WriteLine($"{ex.ToString().Split('\n')[0]}");
}

//Result without the checked instruction: -2147483648
//Result with the checked instruction: OverFlow Exception
