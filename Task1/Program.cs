bool IsDigit(string? token)
{
    if (token is null)
    {
        return false;
    }
    foreach (var e in token)
    {
        if (!Char.IsDigit(e))
        {
            return false;
        }
    }

    return true;
}
bool CheckOper(string? token)
{
    return token is "+" or "-" or "/" or "*" or "^";
}

bool isLBreck(string? token)
{
    return token is "(";
}

bool isRBreck(string? token)
{
    return token is ")";
}


//
int Prior(string token)
{
    switch (token)
    {
        case "+":
        case "-":
            return 2;
        case "*":
        case "/":
            return 3;
        case "^":
            return 4;
        default:
            return 0;
            
        
            
    }
}



ArrayList Reverse(ArrayList tokens)
{
    var res = new Queue();
    var operators = new Stack();
    foreach (string tok in tokens.GetArray())
    {
        if (IsDigit(tok))
        {
            res.Enqueue(tok);
        }else if (CheckOper(tok))
        {
            while (operators.Count()!=0 && !isLBreck(operators.Peak()) && Prior(operators.Peak())>Prior(tok) || Prior(operators.Peak())==Prior(tok))
            {
                
                res.Enqueue(operators.Pop());
                
            }
            operators.Push(tok);
        }
        else if (isLBreck(tok))
        {
            operators.Push(tok);
            
        }else if (isRBreck(tok))
        {
            while (!isLBreck(operators.Peak()))
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




ArrayList token(string r)
{
    var res = new ArrayList();
    
    String Buffer = "";
    foreach (var c in r)
    {
        if (Char.IsNumber(c))
        {
            Buffer += c;
            
        }else if (c is '+' or '-' or '/' or '*' or '(' or ')' or '^')
        {
            if (Buffer.Length>0)
            {
                res.Add(Buffer);
                Buffer = "";
                
            }
            res.Add(c.ToString());
        }
    }

    if (Buffer.Length>0)
    {
        res.Add(Buffer);
    }
    
    return res;
}


var g = token("25+43*6");
var ReverseTok = Reverse(g);
for (var i = 0; i < ReverseTok.Count(); i++)
{
    Console.WriteLine(ReverseTok.GetAt(i));
}




























public class ArrayList
{
    private string[] _array = new String[10];

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
        if (_pointer == _array.Length)
        {
            // this code is raising an exception about reaching stack limit
            throw new Exception("Stack overflowed");
        }

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

    public string Peak()
    {
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
    private const int Capacity = 10;

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
            Converted.Add(Q.Dequeue());
        }

        return Converted;
    }
    public void Enqueue(string value)
    {
        if (_pointer == _array.Length)
        {
            // this code is raising an exception about reaching stack limit
            throw new Exception("Queue overflowed");
        }

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

