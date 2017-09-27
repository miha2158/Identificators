using System;
using System.Collections.Generic;

namespace Identificators
{
    [Serializable]
    public class Methods: Identifier
    {
        public new const UseCase uses = UseCase.Methods;

        public Methods(string name): base(name) { }
        public Methods(string name, Types typeReturned): base(name, typeReturned) { }
        public Methods(string name, LinkedList<Tuple<string, Types, Params>> args, Types typeReturned): base(name,
            typeReturned)
        {
            this.args = args;
        }

        public LinkedList<Tuple<string, Types, Params>> args = new LinkedList<Tuple<string, Types, Params>>();

    }
}