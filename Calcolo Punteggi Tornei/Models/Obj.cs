namespace Calcolo_Punteggi_Tornei.Models;

public class Obj
{
    /// <summary>
    /// Id dell'obiettivo
    /// </summary>
    public int Id { get; set; }
    public string Description { get; set; } = "";

    public Task Primario { set; get; }
    public Task Secondario { set; get; }
    public Task Terziario { set; get; }
    public Task DifesaNoPrimario { set; get; }
    /// <summary>
    /// Caduti della difesa
    /// </summary>
    public Task Difesa { get; set; }
    /// <summary>
    /// Caduti dell'attacco
    /// </summary>
    public Task Incursori { get; set; }
    public Task Highlander { get; set; }

    /// <summary>
    /// Tempi di obiettivo
    /// </summary>
    public DateTime Inizio { get; set; }
    public DateTime Fine { get; set; }
    public TimeSpan Durata { get; set; }

    public String Contestazioni { get; set; } = "";

    public Obj()
    {
        Primario = new Task()
        {
            Description = "Obiettivo Primario",
            Points = Points.Primario,
            Notes = ""
        };
        Secondario = new Task()
        {
            Description = "Obiettivo Secondario",
            Points = Points.Secondario,
            Notes = ""
        };
        Terziario = new Task()
        {
            Description = "Obiettivo Terziario",
            Points = Points.Terziario,
            Notes = ""
        };
        Difesa = new Task()
        {
            Description = "Difensori eliminati",
            Points = Points.Difensori,
            Range = (0,3),
            Notes = ""
        };
        DifesaNoPrimario = new Task()
        {
            Description = "Eliminazione completa della difesa e mancato completamento dell'obiettivo primario",
            Points = Points.DifesaNoPrimario,
            Notes = ""
        };
        Incursori = new Task()
        {
            Description = "Incursori eliminati",
            Points = Points.Incursori,
            Range = (0, 6),
            Notes = ""
        };
        Highlander = new Task()
        {
            Description = "Incursori highlander",
            Points = Points.Highlander,
            Notes = ""
        };
    }

    public int TotalPoints
    {
        get
        {
            int sum = 0;

            sum += Primario.EarnedPoints;
            sum += Secondario.EarnedPoints;
            sum += Terziario.EarnedPoints;
            sum += Difesa.EarnedPoints;

            if (!(Primario.Result > Primario.Range.Min)
                && (Difesa.Result == Difesa.Range.Max))
                sum += DifesaNoPrimario.Result = 1;

            sum += DifesaNoPrimario.EarnedPoints;
            sum += Incursori.EarnedPoints;
            sum += Highlander.EarnedPoints;

            return sum;
        }
    }
}
