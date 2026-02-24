using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1.Session5
{
    public class Assessment2
    {
        //Assessment2
        //Build a class MyCookieCollection that:
        //Stores cookie names and values.
        //Allows access with cookies["username"] = "Mai";.
        public Assessment2()
        {
            MyCookieCollection cookies = new MyCookieCollection();
            cookies["username"] = "Mai";
            cookies["id"] = "1";
            cookies["role"] = "admin";


            Console.WriteLine(cookies["username"]);
            Console.WriteLine(cookies["id"]);
            Console.WriteLine(cookies["role"]);
        }
    }

    public class MyCookieCollection
    {
        Dictionary<string, string> cookies = new Dictionary<string, string>();
        public string this[string name]
        {
            get
            {
                return cookies[name];
            }
            set
            {
                cookies[name] = value;
            }
        }
    }
}