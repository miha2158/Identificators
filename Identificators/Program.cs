using System;
using System.Collections.Generic;
using System.Linq;

namespace Identificators
{
    public static class Extenisons
    {
        public static Types ParseType(string s)
        {
            s = s.Trim();
            switch (s)
            {
                case "int":
                    return Types._int;
                case "float":
                    return Types._float;
                case "bool":
                    return Types._bool;
                case "char":
                    return Types._char;
                case "string":
                    return Types._string;
                case "class":
                    return Types._class;
                case "void":
                    return Types._void;
                default:
                    return Types._;
            }
        }
        public static object ParseTo(this string s, Types t)
        {
            switch (t)
            {
                case Types._int:
                    return int.Parse(s);
                case Types._float:
                    return float.Parse(s);
                case Types._bool:
                    return bool.Parse(s);
                case Types._char:
                    return char.Parse(s);
                case Types._string:
                    return s;
                default:
                    return null;
            }
        }

        public static Identifier ParseIdentifier(string s)
        {
            Identifier result = null;

            s = s.Replace("(", " ( ").Replace(")", " ) ").Replace("  ", " ");
            s = s.Trim();
            if (s[s.Length - 1] != ';')
                throw new FormatException();
            s = s.TrimEnd(';').Trim();
            var sArr = s.Split(' ').ToList();

            if (sArr[0] == "const")
                result = new Consts(sArr[2], ParseType(sArr[1]), sArr[3].ParseTo(ParseType(sArr[1])));

            if(s.Contains('('))
                if (!s.Contains(')'))
                    throw new FormatException();
                else
                {
                    result = new Methods(sArr[1],ParseType(sArr[0]));
                    var list = new LinkedList<Tuple<string, Types, Params>>();
                    string sTemp = s.Substring(s.IndexOf('('), s.LastIndexOf(')'));
                    sTemp = sTemp.Trim('(', ')');

                    var args = sTemp.Split(',');
                    foreach (string s1 in args)
                    {
                        string[] arg = s1.Split(' ');
                        if (arg.Length == 2)
                            list.AddLast(new Tuple<string, Types, Params>(arg[1].Trim(), ParseType(arg[0]), Params._val));
                        else if(arg[0] == "out")
                            list.AddLast(new Tuple<string, Types, Params>(arg[1].Trim(), ParseType(arg[0]), Params._out));
                        else if(arg[0] == "ref")
                            list.AddLast(new Tuple<string, Types, Params>(arg[1].Trim(), ParseType(arg[0]), Params._ref));
                    }

                    ((Methods)result).args = list;
                    return result;
                }

            if (sArr[0] == "class")
                return new Classes(sArr[1]);
            
            return new Vars(sArr[1],ParseType(sArr[0]));
        }
    }

    static class Program
    {

        static void Main(string[] args)
        {/*
            var tree = new BinTree<Identifier>(new Vars("a", Types._int),
                new BinTree<Identifier>(new Classes("MyClass"), new BinTree<Identifier>(
                    new Methods("method1",
                        new LinkedList<Tuple<string, Types, Params>>(new[]
                        {
                            new Tuple<string, Types, Params>("x1", Types._int, Params._ref),
                            new Tuple<string, Types, Params>("x2", Types._char, Params._ref),
                            new Tuple<string, Types, Params>("x3", Types._float, Params._out)
                        }), Types._string))),
                new BinTree<Identifier>(new Consts("c", Types._float, 10)));
            */


            Console.ReadKey(true);
        }
    }
}
