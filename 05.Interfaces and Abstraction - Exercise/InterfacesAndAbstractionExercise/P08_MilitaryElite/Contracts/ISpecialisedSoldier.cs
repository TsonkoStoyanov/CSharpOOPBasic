
namespace P08_MilitaryElite.Contracts
{
    using Enums;

    using System;

    public interface ISpecialisedSoldier :IPrivate
    {
        Corps Corps { get;}
    }
}