using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1
    {
        public bool? Run(IEnumerable<char> s)
        {
            State a = new State() //empty
            {
                Name = "a",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State b = new State() //0- 1+
            {
                Name = "b",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State c = new State() //0+ 1-
            {
                Name = "c",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State d = new State() //one 0 >=one 1
            {
                Name = "d",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            State e = new State() // >one 0 
            {
                Name = "e",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = a;

            a.Transitions['0'] = c;
            a.Transitions['1'] = b;

            b.Transitions['0'] = d;
            b.Transitions['1'] = b;

            c.Transitions['0'] = e;
            c.Transitions['1'] = d;

            d.Transitions['0'] = e;
            d.Transitions['1'] = d;

            e.Transitions['0'] = e;
            e.Transitions['1'] = e;

            State now = InitialState;
            foreach (var ch in s)
            {
                if (!now.Transitions.ContainsKey(ch))
                    return null;

                now = now.Transitions[ch];
                if (now == null)
                    return null;
            }

            return now.IsAcceptState;
        
        }
    }



    public class FA2
    {
        public bool? Run(IEnumerable<char> s)
        {
            State a = new State() //start 0c 1c
            {
                Name = "a",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State b = new State() //0nc 1c
            {
                Name = "b",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State c = new State() //0c 1nc
            {
                Name = "c",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State d = new State() //0nc 1nc
            {
                Name = "d",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = a;

            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = a;
            b.Transitions['1'] = d;

            c.Transitions['0'] = d;
            c.Transitions['1'] = a;

            d.Transitions['0'] = c;
            d.Transitions['1'] = b;

            State now2 = InitialState;
            foreach (var ch in s)
            {
                if (!now2.Transitions.ContainsKey(ch))
                    return null;

                now2 = now2.Transitions[ch];
                if (now2 == null)
                    return null;
            }

            return now2.IsAcceptState;
        }
    }

    public class FA3
    {
        public bool? Run(IEnumerable<char> s)
        {
            State a = new State() // no 1
            {
                Name = "a",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State b = new State() // one 1
            {
                Name = "b",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State c = new State() // 11+
            {
                Name = "c",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = a;

            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = a;
            b.Transitions['1'] = c;
            c.Transitions['0'] = c;
            c.Transitions['1'] = c;

            State now3 = InitialState;
            foreach (var ch in s)
            {
                if (!now3.Transitions.ContainsKey(ch))
                    return null;

                now3 = now3.Transitions[ch];
                if (now3 == null)
                    return null;
            }

            return now3.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}