using System;
using System.IO;
using System.Collections.Generic;
class Synch
{

    //Hello world 

    //O(n*n)

    public Synch(I1 i1, I1 i2) 
    {

    }
    public void CharCount(string s) {
        var count = new Dictionary<char, int>();
        var stringArr = s.ToCharArray();
        foreach (var ch in stringArr) {
            if (count.ContainsKey(ch))
            {
                count[ch] = count[ch] + 1;
            }
            else {
                count.Add(ch, 1);
            }
        }


        foreach (var item in count)
        {
            Console.WriteLine($"{item.Key}={item.Value}");
        }
    
    }


}