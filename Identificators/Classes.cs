using System;

namespace Identificators
{
    [Serializable]
    public class Classes: Identifier
    {
        public new const UseCase uses = UseCase.Classes;

        public Classes(string name): base(name)
        {
            typeReturned = Types._class;
        }
    }
}