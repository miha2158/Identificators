using System;
using System.Collections.Generic;

namespace Identificators
{
    [Serializable]
    public class Consts: Identifier
    {
        public new const UseCase uses = UseCase.Consts;

        public readonly object value;

        public Consts(string name): base(name) { }
        public Consts(string name, Types type): base(name, type) { }
        public Consts(string name, Types type, dynamic value): base(name)
        {
            if ("_" + value.GetType().ToString() == typeReturned)
                this.value = value;
            else throw new TypeInitializationException("Введён  аргумент не правильного типа",new Exception());
        }

        public override bool Equals(object obj)
        {
            var o = obj as Consts;
            return base.Equals(obj) && value.Equals(o.value);
        }
    }
}