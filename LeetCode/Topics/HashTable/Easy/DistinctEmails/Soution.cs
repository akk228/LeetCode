using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Topics.HashTable.Easy.DistinctEmails
{
    public class Solution
    {
        public int NumUniqueEmails(string[] emails) {
        var distinctEmails = new HashSet<string>();
        
        foreach (var email in emails)
        {
            distinctEmails.Add(EmailReducer(email));   
        }
        
        return distinctEmails.Count;
    }
    
    private string EmailReducer(string email)
    {
        var reducedEmail = new StringBuilder();
        var length = email.Length - 4;
        var i = 0;
        
        for (; i < length; i++)
        {
            if (email[i] == '@') break;
            
            if (email[i] == '+')
            {
                while (email[i] != '@') i++;
                break;
            }
            
            if (email[i] == '.') continue;
            
            reducedEmail.Append(email[i]);
        }
        
        for (; i < length; i++)
        {
            reducedEmail.Append(email[i]);
        }
        
        return reducedEmail.ToString();
    }
        // public int NumUniqueEmails(string[] emails)
        // {
        //     HashSet<string> uniqueEmails = new HashSet<string>();

        //     foreach (var email in emails)
        //     {
        //         var parts = email.Split('@');
        //         var local = parts[0].Split('+')[0].Replace(".", "");
        //         var domain = parts[1];
        //         uniqueEmails.Add($"{local}@{domain}");
        //     }

        //     return uniqueEmails.Count;
        // }
    }
}