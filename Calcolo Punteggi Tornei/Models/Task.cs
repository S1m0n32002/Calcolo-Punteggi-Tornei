namespace Calcolo_Punteggi_Tornei.Models;

public class Task()
{
    public (int Min, int Max) Range { get; internal set; } = (0, 1);
    public string Description { get; internal set; } = "";
    public int Points { get; internal set; }
    public int Result
    {
        get => _Result;
        set
        {
            if (value < Range.Min)
                _Result = Range.Min;
            else if (value > Range.Max)
                _Result = Range.Max;
            else
                _Result = value;
        }
    }
    public int EarnedPoints { get => Points * Result; }
    public string Notes { get; set; } = "";

    private int _Result;
}
