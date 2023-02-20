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
                (
                    Prior(operators.Peek())>Prior(tokArray.GetAt(t)) || 
                    (
                    Prior(operators.Peek())==Prior(tokArray.GetAt(t)) && 
                    LeftAsoc(tokArray.GetAt(t))
                    )
                )
                )
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

    if (Buffer.Length>0)
    {
        toToken.Add(Buffer);
    }
    
    return toToken;
}


var g = ToToken("(7-2)^2");
//3^3+(2*10/5)-3
//Console.WriteLine(IsNumberToken("+"));


ArrayList ReverseTok = Reverse(g);
for (int i = 0; i < ReverseTok.Count(); i++)
{
    Console.WriteLine(ReverseTok.GetAt(i)); 
}
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
public class ArrayList
{
    private string[] _array = new String[50];

    private int _pointer = 0;

    public void Add(string element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            var extendedArray = new String[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
            //this also can be achieved via
            //Array.Resize(ref _array, _array.Length * 2);
        }
    }

    public void Remove(string element)
    {
        for (var i = 0; i < _pointer; i++)
        {
            if (_array[i] == element)
            {
                for (var j = i; j < _pointer - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }

                _pointer -= 1;
                return;
            }
        }
    }

    public string GetAt(int index)
    {
        return _array[index];
    }
    public Array GetArray()
    {
        return _array;
    }
    public int IndexOf(string element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(string element)
    {
        return IndexOf(element) != -1;
    }
    public string[] GetElements()
    {
        return _array;
        // string[] elments = new string[10]; 
        // for (int i = 0; i < _array.Count(); i++)
        // {
        //     elments[i] = _array[i];
        //     
        // }
        // return elments.ToString();
        //
    }
    public int Count()
    {
        return _pointer;
    }
}

public class Stack
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;

    public void Push(string value)
    {
        

        _array[_pointer] = value;
        _pointer++;
    }
    public string GetAt(int index)
    {
        return _array[index];
    }
    public string Pop()
    {
        if (_pointer == 0)
        {
            //you can also raise an exception here, but we're simple returning nothing
            return null;
        }
//original variant (var value = _array[_pointer];) didn't work
        var value = _array[_pointer-1];
        //original variant didn't work
        _pointer--;
        return value;
    }
    public int Count()
    {
        return _pointer;
    }

    public string Peek()
    {
        if (_pointer == 0)
        {
            //you can also raise an exception here, but we're simple returning nothing
            return null;
        }
        var value = _array[_pointer-1];
        return value;
        
    }
    
    public int IndexOf(string element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(string element)
    {
        return IndexOf(element) != -1;
    }
    
}

public class Queue
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;
    public Array GetArray()
    {
        return _array;
    }
   
    public ArrayList toList(Queue Q)
    {
        var Converted = new ArrayList();
        for (var  elToConvert=0; elToConvert<Q.Count(); elToConvert++)
        {
            Converted.Add(Q.GetAt(elToConvert));
        }

        return Converted;
    }
    public void Enqueue(string value)
    {
        _array[_pointer] = value;
        _pointer++;
    }
    public string GetAt(int index)
    {
        return _array[index];
    }
    public string Dequeue()
    {
       
//original variant (var value = _array[_pointer];) didn't work
        var value = _array[0];
        //original variant didn't work
        for (var i = 0; i < _pointer; i++)
        {
            if (i == 0)
            {
                for (var j = i; j < _pointer - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }

                _pointer -= 1;
                
            }
        }
        return value;
    }
    public int Count()
    {
        return _pointer;
    }
    
    
    public int IndexOf(string element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(string element)
    {
        return IndexOf(element) != -1;
    }
    
}

