
var variable = "2 + 2 * 2";
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
       int firstI = Convert.ToInt32(first);
       int secondI = Convert.ToInt32(second);


       if (l=='+')
       {
           int s = firstI + secondI;
           calculations.Push(Convert.ToChar(s));
       }else if (l=='-')
       {
           int s = firstI - secondI;
           calculations.Push(Convert.ToChar(s));
       }else if (l=='*')
       {
           int s = firstI * secondI;
           calculations.Push(Convert.ToChar(s));
       }else if (l=='/')
       {
           int s = firstI / secondI;
           calculations.Push(Convert.ToChar(s));
       }
       
       
    }
   
}


foreach (var VARIABLE in calculations)
{
    Console.WriteLine(VARIABLE);
}


