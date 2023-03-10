namespace Task1;

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
