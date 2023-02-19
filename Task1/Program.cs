
bool IsDigit(string? l)
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

bool ContainsH(string? l)
{
    char[] operatorsHigh = new char[] { '/', '*' };
    if (l is null)
    {
        return false;
    }
    foreach (var e in l)
    {
        if (!operatorsHigh.Contains(e))
        {
            return false;
        }
    }

    return true;
}

bool ContainsL(string? l)
{
    if (l is null)
    {
        return false;
    }
    char[] operatorsLow = new char[] { '-', '+' };
    foreach (var e in l)
    {
        if (!operatorsLow.Contains(e))
        {
            return false;
        }
    }

    return true;
}

var variable = "2+4*6";

char[] operators = new char[] { '+', '-', '/', '*' };
var tokenized = new ArrayList();

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


        tokenized.Add(Buffer);


        Buffer = "";
            if (op!=',')
            {
                tokenized.Add(op.ToString());
            }

            //Console.WriteLine(Buffer);
        op = ch;
    }

   
    
}
if (Buffer!="")
{
    tokenized.Add(Buffer);
    tokenized.Add(op.ToString());
}

for (var i = 0; i < tokenized.Count(); i++)
{
    Console.WriteLine(tokenized.GetAt(i));
}
Console.WriteLine("---------------");


var calculations= new Queue();
 var oper = new Stack();
var final = new Stack();
char[] operatorsHigh = new char[] { '/', '*' };
char[] operatorsLow = new char[] { '-', '+' };
string[] tempOpers = new string[2];
for (var t = 0; t < tokenized.Count(); t++)
{
    // 
    foreach (var c in tokenized.GetAt(t))
    {
        if (IsDigit(c.ToString()))
        {
           calculations.Enqueue(c.ToString());
        }
       else if (ContainsL(c.ToString()))
        {
            if (oper.Count()==0)
            {
                oper.Push(c.ToString());
               
            }
            else if (oper.Count()>0)
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    tempOpers[i] = oper.Pop();
                    
                    if (tempOpers[i]!=null)
                    {
                       calculations.Enqueue(tempOpers[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c.ToString());
            }
            
            
        } else if (ContainsH(c.ToString()))
        {
            if (oper.Count()==0)
            {
                
                oper.Push(c.ToString());
            }

            if (oper.Count()>0 &&  oper.GetAt(0)=="+" || oper.GetAt(0)=="-")
            {
                oper.Push(c.ToString());  
            }
          
            else if (oper.Count()>0 &&  oper.GetAt(0) == "*" || oper.GetAt(0) == "/")
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    tempOpers[i] = oper.Pop();
                    
                    if (tempOpers[i]!=null)
                    {
                        calculations.Enqueue(tempOpers[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c.ToString());
            }
           
        }
        
    }
}

for(var g=0; g<calculations.Count(); g++)
{
  Console.WriteLine(calculations.GetAt(g));
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


