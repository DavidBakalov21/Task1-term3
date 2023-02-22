namespace Task1;

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