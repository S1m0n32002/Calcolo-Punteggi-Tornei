namespace Calcolo_Punteggi_Tornei.Models;

public class Obj
{
    static class Points
    {
        /// <summary>
        /// Punti per ogni obiettivo (Messi a cazzo, da correggere)
        /// </summary>
        public const int Primario = 1000;
        public const int Secondario = 500;
        public const int Terziario = 200;
        public const int DifesaNoPrimario = 100;
        public const int Difesa = 100;
        public const int Incursori = -100;
        public const int Highlander = -500;
    }

    /// <summary>
    /// Id dell'obiettivo
    /// </summary>
    public int Id { get; set; }
    public string Description { get; set; } = "";

    /// <summary>
    /// Obiettivo primario, secondario o terziario
    /// </summary>
    public bool Primario { set; get; }
    public bool Secondario { set; get; }
    public bool Terziario { set; get; }

    /// <summary>
    /// Caduti della difesa
    /// </summary>
    public int Difesa { get; set; }
    /// <summary>
    /// Caduti dell'attacco
    /// </summary>
    public int Incursori { get; set; }

    /// <summary>
    /// Tempi di obiettivo
    /// </summary>
    public DateTime Inizio { get; set; }
    public DateTime Fine { get; set; }
    public TimeSpan Durata { get; set; }

    public int Highlander { get; set; }
    public String Contestazioni { get; set; } = "";

    public int TotalPoints
    {
        get
        {
            int sum = 0;

            if (Primario) sum += Points.Primario;
            if (Secondario) sum += Points.Secondario;
            if (Terziario) sum += Points.Terziario;

            if (Difesa <= 3) sum += Points.Difesa * Difesa;
            if (Difesa == 3 && !Primario) sum += Points.DifesaNoPrimario;

            if (Incursori <= 6) sum += Points.Incursori * Incursori;

            
            return sum;
        }
    }
}
