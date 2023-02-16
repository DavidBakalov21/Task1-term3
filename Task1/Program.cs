var variable = "2+4*6";

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

foreach (var g in operations)
{
    Console.WriteLine(g);
}
Console.WriteLine("---------------");

Queue<String> calculations= new Queue<String>();
Stack<String> oper = new Stack<string>();
Stack<String> final = new Stack<string>();
char[] operatorsHigh = new char[] { '/', '*' };
char[] operatorsLow = new char[] { '-', '+' };
string[] kk = new string[2];
foreach (var t in operations)
{
    // 
    foreach (var c in t.ToCharArray())
    {
        if (Char.IsDigit(c))
        {
           calculations.Enqueue(c.ToString());
        }
       else if (operatorsLow.Contains(c))
        {
            if (oper.Count()==0)
            {
                oper.Push(c.ToString());
               
            }
            else if (oper.Count()>0)
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    kk[i] = oper.Pop();
                    Console.WriteLine(kk[i]);
                    if (kk[i]!=null)
                    {
                       calculations.Enqueue(kk[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c.ToString());
            }
            
            
        } else if (operatorsHigh.Contains(c))
        {
            if (oper.Count==0)
            {
                
                oper.Push(c.ToString());
               
                    
                    
                    
                }

            if (oper.Count()>0 &&  oper.Contains(operatorsLow.ToString()))
            {
                oper.Push(c.ToString());  
            }
          
            else if (oper.Count()>0 &&  oper.Contains(operatorsHigh.ToString()))
            {
                for (int i = 0; i < oper.Count(); i++)
                {
                    kk[i] = oper.Pop();
                    Console.WriteLine(kk[i]);
                    if (kk[i]!=null)
                    {
                        calculations.Enqueue(kk[i]); 
                    }
                    
                    
                    
                }
                oper.Push(c.ToString());
            }
           
        }
        
    }
}

foreach (var g in calculations)
{
  Console.WriteLine(g);
}
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


public class ArrayList
{
    private int[] _array = new int[10];

    private int _pointer = 0;

    public void Add(int element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            var extendedArray = new int[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
            //this also can be achieved via
            //Array.Resize(ref _array, _array.Length * 2);
        }
    }

    public void Remove(int element)
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

    public int GetAt(int index)
    {
        return _array[index];
    }

    public int IndexOf(int element)
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

    public bool Contains(int element)
    {
        return IndexOf(element) != -1;
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

    public string Pull()
    {
        if (_pointer == 0)
        {
            //you can also raise an exception here, but we're simple returning nothing
            return null;
        }

        var value = _array[_pointer];
        _pointer--;
        return value;
    }
}

