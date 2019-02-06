

using System.Collections.Generic;

namespace P08_MilitaryElite.Contracts
{

    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }
    }
}