
var variable = "2 + 2";
char[] operators = new char[] { '+', '-', '/', '*' };

List<string> operations = new List<string>();

var buff = "";
char? oper = null;

foreach (var ch in variable)
{
    if (Char.IsDigit(ch))
    {
        buff += ch;
    }
    else if (operators.Contains(ch))
    {
        operations.Add(buff);
        buff = "";
        if (oper is not null)
        {
            operations.Add(oper.ToString());
        }
        oper = ch;
    }
}

if (buff != "")
{
    operations.Add(buff);
    operations.Add(oper.ToString());
}
Stack<char> calculations= new Stack<char>();

foreach (var operation in operations)
{
    var l = Convert.ToChar(operation);
    if (Char.IsDigit(l))
    {
        
        calculations.Push(l);
    }
    else if (operators.Contains(l))
    {
        var first=calculations.Pop();
        var second = calculations.Pop();
       int firstI = int.Parse(first.ToString());
       int secondI = int.Parse(second.ToString());
       // How can 2 be converted to 50?
       
        
Console.WriteLine(firstI);
Console.WriteLine(second);

if (l=='+')
{
    int s = firstI + secondI;
    var b = Convert.ToChar(s);
    calculations.Push(b);
    
    
}
       
       
    }
   
}


foreach (var VARIABLE in calculations)
{
    Console.WriteLine(VARIABLE);
}

