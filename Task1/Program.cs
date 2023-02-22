

using Task1;

bool IsNumb(string? l)
{
    if (l is null)
    {
        return false;
    }
    foreach (var e in l)
    {
        if (!Char.IsDigit(e))
        {
            return false;
        }
    }
    return true;
}

bool isFunc(string l)
{
    var check = false;
    if (l is "sin" or "cos" or "tg" or "ctg")
    {
        check = true;
    } else
    {
        check = false;
    }

    return check;
}
bool OperatorCheck(string l)
{
    bool check = false;
    if (l is "+" or "-" or "/" or "*" or "^")
    {
        check = true;
    }
    else
    {
        check = false;
    }
    return check;
}
bool LeftBreck(string l)
{
    bool check = false;
    if (l =="(")
    {
        check = true;
    }
    else
    {
        check = false;
    }
    return check;
}
bool RightBreck(string l)
{
    bool check = false;
    if (l ==")")
    {
        check = true;
    }
    else
    {
        check = false;
    }
    return check;
}
bool LeftAsoc(string l)
{
    bool check = false;
    if (l != "^" && OperatorCheck(l))
    {
        check = true;
    }
    else
    {
        check = false;
    }
    return check;
}
int Prior(string l)
{
    int prio;
    if (l=="+"|| l=="-")
    {
        prio = 2;
    }
    else if(l=="*"|| l=="/")
    {
        prio = 3; 
    }else if (l == "^")
    {
        prio = 4; 
    }
    else
    {
        prio = 0;
    }
    return prio;
}

ArrayList Reverse(ArrayList tokArray)
{
    var res = new Queue();
    var operators = new Stack();
    for (int t = 0; t < tokArray.Count(); t++)
        //foreach (string token in tokens)
    {
        if (IsNumb(tokArray.GetAt(t)))
        {
            res.Enqueue(tokArray.GetAt(t));
        }
        else if (OperatorCheck(tokArray.GetAt(t)))
        {
            while ( operators.Count()!=0 &&
                !LeftBreck(operators.Peek()) && 
                (Prior(operators.Peek())>Prior(tokArray.GetAt(t)) || 
                 (Prior(operators.Peek())==Prior(tokArray.GetAt(t)) && LeftAsoc(tokArray.GetAt(t)))))
            {
                
                res.Enqueue(operators.Pop());
                
            }
            operators.Push(tokArray.GetAt(t));
        }
        else if (LeftBreck(tokArray.GetAt(t)))
        {
            operators.Push(tokArray.GetAt(t));
            
        }else if (RightBreck(tokArray.GetAt(t)))
        {
            while (!LeftBreck(operators.Peek()))
            {
                res.Enqueue(operators.Pop());
                
            }
            operators.Pop();
        }
    }
    while (operators.Count()>0)
    {
        res.Enqueue(operators.Pop());
    }

    return res.toList(res);
}
//ok
ArrayList ToToken(string r)
{
    ArrayList toToken = new ArrayList();
    
    String Buffer = "";
    foreach (char c in r)
    {
        if (Char.IsNumber(c))
        {
            Buffer += c;
            
        }else if (c is '+' or '-' or '/' or '*' or '(' or ')' or '^')
        {
            if (Buffer.Length>0)
            {
                toToken.Add(Buffer);
                Buffer = "";
                
            }
            toToken.Add(c.ToString());
        }
    }

    if (Buffer!="")
    {
        toToken.Add(Buffer);
    }
    
    return toToken;
}
var g = ToToken("2*6^2");
//3^3+(2*10/5)-3
ArrayList ReverseTok = Reverse(g);
//for (int i = 0; i < ReverseTok.Count(); i++)
//{
   // Console.WriteLine(ReverseTok.GetAt(i)); 
//}
Console.WriteLine("-------------"); 
bool vvvx = OperatorCheck("/");
Console.WriteLine(vvvx);
var sFinal =new Stack();

for (int i = 0; i < ReverseTok.Count(); i++)
{
    if (IsNumb(ReverseTok.GetAt(i)))
    {
        sFinal.Push(ReverseTok.GetAt(i));
       
    }else if (OperatorCheck(ReverseTok.GetAt(i)))
    {
        var first=sFinal.Pop();
        var second = sFinal.Pop();
        int firstI = int.Parse(first);
        int secondI = int.Parse(second);

        if (ReverseTok.GetAt(i)=="+")
        {
            int r = firstI + secondI;
             
            var b = Convert.ToString(r);
            sFinal.Push(b);
     
     
        }else if (ReverseTok.GetAt(i)=="-")
        {
            int r =   secondI-firstI;
            var b = Convert.ToString(r);
            sFinal.Push(b);   
        }
        else if (ReverseTok.GetAt(i)=="*")
        {
            int r = firstI * secondI;
            var b = Convert.ToString(r);
            sFinal.Push(b);  
        }else if(ReverseTok.GetAt(i)=="/")
        {
            int r =   secondI/firstI;
            var b = Convert.ToString(r);
            sFinal.Push(b);  
        }
        else if(ReverseTok.GetAt(i)=="^")
        {
            double r = Math.Pow(secondI, firstI);
            var b = Convert.ToString(r);
            sFinal.Push(b);  
        }
    }
}
for (int i = 0; i < sFinal.Count(); i++)
{
    Console.WriteLine(sFinal.GetAt(i)); 
}
