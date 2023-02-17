
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
var operations = new ArrayList();

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

for (var i = 0; i < operations.Count(); i++)
{
    Console.WriteLine(operations.GetAt(i));
}
Console.WriteLine("---------------");


Queue<String> calculations= new Queue<String>();
var oper = new Stack();
var final = new Stack();
char[] operatorsHigh = new char[] { '/', '*' };
char[] operatorsLow = new char[] { '-', '+' };
string[] kk = new string[2];
for (var t = 0; t < operations.Count(); t++)
{
    // 
    foreach (var c in operations.GetElements())
    {
        if (IsDigit(c))
        {
           calculations.Enqueue(c);
        }
       else if (ContainsL(c))
        {
            if (oper.Count()==0)
            {
                oper.Push(c);
               
            }
            else if (oper.Count()>0)
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    kk[i] = oper.Pop();
                    
                    if (kk[i]!=null)
                    {
                       calculations.Enqueue(kk[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c);
            }
            
            
        } else if (ContainsH(c))
        {
            if (oper.Count()==0)
            {
                
                oper.Push(c);
            }

            if (oper.Count()>0 &&  oper.Contains(operatorsLow.ToString()))
            {
                oper.Push(c);  
            }
          
            else if (oper.Count()>0 &&  oper.Contains(operatorsHigh.ToString()))
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    kk[i] = oper.Pop();
                    
                    if (kk[i]!=null)
                    {
                        calculations.Enqueue(kk[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c);
            }
           
        }
        
    }
}

foreach (var g in calculations)
{
  Console.WriteLine(g);
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


