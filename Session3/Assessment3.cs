using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session3
{
    public class Assessment3
    {
        //https://leetcode.com/problems/valid-parentheses/submissions/1913978141

        //Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        //An input string is valid if:
        //Open brackets must be closed by the same type of brackets.
        //Open brackets must be closed in the correct order.
        //Every close bracket has a corresponding open bracket of the same type.

        //Example 1:
        //Input: s = "()"
        //Output: true

        //Example 2:
        //Input: s = "()[]{}"
        //Output: true

        //Example 3:
        //Input: s = "(]"
        //Output: false

        //Example 4:
        //Input: s = "([])"
        //Output: true

        //Example 5:
        //Input: s = "([)]"
        //Output: false

        //Constraints:
        //1 <= s.length <= 10^4
        //s consists of parentheses only '()[]{}'.

        //https://leetcode.com/problems/valid-parentheses/submissions/1913978141

        public bool IsValid(string s)
        {
            string openings = "({[";
            string closings = ")}]";

            //check if length fits constraints
            if ((s.Length >= 2 && s.Length <= Math.Pow(10, 4) && s.Length % 2 == 0) == false)
                return false;

            //check if first char is an opening and last char is a closing
            if (openings.Contains(s[0]) == false || closings.Contains(s[s.Length - 1]) == false)
                return false;


            //STACK
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (openings.Contains(c))
                {
                    stack.Push(c);
                }
                else if (closings.Contains(c))
                {
                    int indexOfClosings = closings.IndexOf(c);
                    char opening = openings[indexOfClosings];

                    if (stack.Count > 0 && stack.Peek() ==  opening)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
