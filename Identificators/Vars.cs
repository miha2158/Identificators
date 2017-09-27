using System;

namespace Identificators
{
    [Serializable]
    public class Vars: Identifier
    {
        public new const UseCase uses = UseCase.Vars;

        public Vars(string name): base(name) { }
        public Vars(string name, Types type): base(name, type) { }
    }
}