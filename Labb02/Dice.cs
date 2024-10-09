public class Dice
{
    private int numberOfDice { get; set; }
    private int sidesPerDice { get; set; }
    public int modifier { get; set; }
    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
    }

    public int Throw()
    {
        int dicethrow = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            Random rnd = new Random();
            dicethrow += rnd.Next(1, sidesPerDice + 1);
        }

        return dicethrow + modifier;
    }
    public override string ToString()
    {
        return $"{numberOfDice}d{sidesPerDice}+{modifier}";
    }
}