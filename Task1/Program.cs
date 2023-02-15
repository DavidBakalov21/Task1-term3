var variable = "2 + 2 * 8";

char[] operators = new char[] { '+', '-', '/', '*' };
List<string> operations = new List<string>();

var Buffer="";
char op = ',';
foreach (var ch in variable)
{
    if (Char.IsDigit(ch))
    {
        Buffer += ch;
        
    }
    else if (operators.Contains(ch))
    {


        operations.Add(Buffer);


        Buffer = "";
            if (op!=',')
            {
                operations.Add(op.ToString());
            }

            //Console.WriteLine(Buffer);
        op = ch;
    }

   
    
}
if (Buffer!="")
{
    operations.Add(Buffer);
    operations.Add(op.ToString());
}

//foreach (var g in operations)
//{
  //  Console.WriteLine(g);
//}

var controll = "?";
Stack<String> calculations= new Stack<String>();
foreach (var l in operations)
{
    foreach (var c in l.ToCharArray())
    {
        if (Char.IsDigit(c))
        {
            controll = "Digit";
        }
        else if (operators.Contains(c))
        {
            controll = "Op";
        }
        {
            
        }
    }
    
     if (controll=="Digit")
     {
         calculations.Push(l);
     }
     else if (controll=="Op")
     {
         var first=calculations.Pop();
         var second = calculations.Pop();
         int firstI = int.Parse(first.ToString());
         int secondI = int.Parse(second.ToString());
        // How can 2 be converted to 50?
       
        
        Console.WriteLine(firstI);
        Console.WriteLine(second);

        if (l=="+")
        {
             int s = firstI + secondI;
             
             var b = Convert.ToString(s);
             calculations.Push(b);
     
     
         }else if (l=="-")
        {
            int s = firstI - secondI;
            var b = Convert.ToString(s);
            calculations.Push(b);   
        }
        else if (l=="*")
        {
            int s = firstI * secondI;
            var b = Convert.ToString(s);
            calculations.Push(b);  
        }else if(l=="/")
        {
            int s = firstI / secondI;
            var b = Convert.ToString(s);
            calculations.Push(b);  
        }
        
        
     }
    
 }


foreach (var VARIABLE in calculations)
{
    Console.WriteLine(VARIABLE);
}
