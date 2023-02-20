//&& 
 
/*foreach (var l in operations)
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
*/






//original Kub
/*
bool IsNumberToken(string token)
{
    
    return int.TryParse(token, out _);
}
bool IsOperatorToken(string token)
{
    return token is "+" or "-" or "/" or "*" or "^";
}

bool isLeftBreck(string token)
{
    return token == "(";
}

bool isRightBreck(string token)
{
    return token == ")";
}

bool LeftAsociative(string token)
{
    return token != "^" && IsOperatorToken(token);
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

List<string> Reverse(List<string> tokens)
{
    Queue<string> output = new Queue<string>();
    Stack<string> operators = new Stack<string>();
    foreach (string token in tokens)
    {
        if (IsNumberToken(token))
        {
            output.Enqueue(token);
        }
        else if (IsOperatorToken(token))
        {
            while ( operators.Count!=0 &&
                !isLeftBreck(operators.Peek()) && 
                (
                    Prior(operators.Peek())>Prior(token) || 
                    (
                    Prior(operators.Peek())==Prior(token) && 
                    LeftAsociative(token)
                    )
                )
                )
            {
                
                output.Enqueue(operators.Pop());
                
            }
            operators.Push(token);
        }
        else if (isLeftBreck(token))
        {
            operators.Push(token);
            
        }else if (isRightBreck(token))
        {
            while (!isLeftBreck(operators.Peek()))
            {
                if (operators.Count()==0)
                {
                    throw new Exception("Error mis");
                    
                }
                
                output.Enqueue(operators.Pop());
                
            }

            if (!isLeftBreck(operators.Peek()))
            {
                throw new Exception("fdvsdfsfsdf");
            }
            
            operators.Pop();
            
        }
       
        
    }

    while (operators.Count()>0)
    {
        if (isLeftBreck(operators.Peek()))
        {
            throw new Exception("Error mis");
        }
        output.Enqueue(operators.Pop());
    }

    return output.ToList();
}




List<String> Tokenize(string r)
{
    List<String> result = new List<string>();
    
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
                result.Add(Buffer);
                Buffer = "";
                
            }
            result.Add(c.ToString());
        }
    }

    if (Buffer.Length>0)
    {
        result.Add(Buffer);
    }
    
    return result;
}


List<String> g = Tokenize("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
    //3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3
//Console.WriteLine(IsNumberToken("+"));
List<String> ReverseTok = Reverse(g);
Console.WriteLine(String.Join("", ReverseTok));







































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

*/












//20.02.2023 12.57

/*
bool IsNumberToken(string token)
{
    
    return int.TryParse(token, out _);
}
bool IsOperatorToken(string token)
{
    return token is "+" or "-" or "/" or "*" or "^";
}

bool isLeftBreck(string token)
{
    return token == "(";
}

bool isRightBreck(string token)
{
    return token == ")";
}

bool LeftAsociative(string token)
{
    return token != "^" && IsOperatorToken(token);
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
    var output = new Queue();
    var operators = new Stack();
    for (int token = 0; token < tokens.Count(); token++)
        //foreach (string token in tokens)
    {
        if (IsNumberToken(tokens.GetAt(token)))
        {
            output.Enqueue(tokens.GetAt(token));
        }
        else if (IsOperatorToken(tokens.GetAt(token)))
        {
            while ( operators.Count()!=0 &&
                !isLeftBreck(operators.Peek()) && 
                (
                    Prior(operators.Peek())>Prior(tokens.GetAt(token)) || 
                    (
                    Prior(operators.Peek())==Prior(tokens.GetAt(token)) && 
                    LeftAsociative(tokens.GetAt(token))
                    )
                )
                )
            {
                
                output.Enqueue(operators.Pop());
                
            }
            operators.Push(tokens.GetAt(token));
        }
        else if (isLeftBreck(tokens.GetAt(token)))
        {
            operators.Push(tokens.GetAt(token));
            
        }else if (isRightBreck(tokens.GetAt(token)))
        {
            while (!isLeftBreck(operators.Peek()))
            {
                if (operators.Count()==0)
                {
                    throw new Exception("Error mis");
                    
                }
                
                output.Enqueue(operators.Pop());
                
            }

            if (!isLeftBreck(operators.Peek()))
            {
                throw new Exception("fdvsdfsfsdf");
            }
            
            operators.Pop();
            
        }
       
        
    }

    while (operators.Count()>0)
    {
        if (isLeftBreck(operators.Peek()))
        {
            throw new Exception("Error mis");
        }
        output.Enqueue(operators.Pop());
    }

    return output.toList(output);
}

ArrayList Tokenize(string r)
{
    ArrayList result = new ArrayList();
    
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
                result.Add(Buffer);
                Buffer = "";
                
            }
            result.Add(c.ToString());
        }
    }

    if (Buffer.Length>0)
    {
        result.Add(Buffer);
    }
    
    return result;
}


var g = Tokenize("33 + 44 * 2/ 77");
    //3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3
//Console.WriteLine(IsNumberToken("+"));
ArrayList ReverseTok = Reverse(g);
//Console.WriteLine(String.Join("", ReverseTok));
for (int i = 0; i < ReverseTok.Count(); i++)
{
    Console.WriteLine(ReverseTok.GetAt(i)); 
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


*/