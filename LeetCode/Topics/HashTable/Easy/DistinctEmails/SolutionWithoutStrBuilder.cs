using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Topics.HashTable.Easy.DistinctEmails
{
    public class SolutionWithouStrBuilder
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> uniqueEmails = new HashSet<string>();

            foreach (var email in emails)
            {
                var parts = email.Split('@');
                var local = parts[0].Split('+')[0].Replace(".", "");
                var domain = parts[1];
                uniqueEmails.Add($"{local}@{domain}");
            }

            return uniqueEmails.Count;
        }
    }
}