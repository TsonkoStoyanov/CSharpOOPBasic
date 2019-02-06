public class Track
{
    private int lapsNumber;
    private int lapLenght;

    public Track(int lapsNumber, int lapLenght)
    {
        LapsNumber = lapsNumber;
        LapLenght = lapLenght;
    }

    public int LapsNumber { get => lapsNumber; set => lapsNumber = value; }
    public int LapLenght { get => lapLenght; set => lapLenght = value; }
}

