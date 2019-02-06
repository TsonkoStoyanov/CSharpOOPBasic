
using System;
using System.Collections.Generic;

public class TyreFactory
{
    private Tyre tyre;

    public Tyre CreateTyre(List<string> args)
    {
        string type = args[0];
        double tyreHardness = double.Parse(args[1]);

        if (type == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        else if (type == "Ultrasoft")
        {
            double grip = double.Parse(args[2]);
            tyre = new UltrasoftTyre(tyreHardness, grip);

        }
        else
        {
            throw new ArgumentException("Invalid tyre type");
        }


        return tyre;
    }
}
