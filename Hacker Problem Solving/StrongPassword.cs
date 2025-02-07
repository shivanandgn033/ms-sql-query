using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'minimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */

    public static int minimumNumber(int n, string password)
    {
    // Return the minimum number of characters to make the password strong
    
           // Checking lower alphabet in string
        //int n = password.Length;
        bool hasLower = false, hasUpper = false,
                hasDigit = false, specialChar = false;
        HashSet<char> set = new HashSet<char>(
            new char[] { '!', '@', '#', '$', '%', '^', '&',
                          '*', '(', ')', '-', '+' });
        foreach (char i in password.ToCharArray())
        {
            if (char.IsLower(i))
                hasLower = true;
            if (char.IsUpper(i))
                hasUpper = true;
            if (char.IsDigit(i))
                hasDigit = true;
            if (set.Contains(i))
                specialChar = true;
        }
     
        int count = 0;
        if(!hasDigit) count++;
        if(!hasLower ) count++;
        if(!hasUpper) count++;
        if(!specialChar) count++;
       
        return (count+n < 6) ? 6-n : count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.minimumNumber(n, password);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
