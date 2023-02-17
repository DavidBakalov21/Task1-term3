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
