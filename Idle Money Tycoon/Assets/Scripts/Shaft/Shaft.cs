using Newtonsoft.Json;
using Newtonsoft.Json.Shims;

public class Shaft
{
    public int ShaftNummer { get; set; }

    public int Lvl { get; set; }

    public double Costs { get; set; }

    public double Income { get; set; }

    public float ProducingTime { get; set; }

    public bool Locked { get; set; }

    [Preserve] [JsonConstructor]
    public Shaft(){}

    public Shaft(int shaftNummer, float costs)
    {
        ShaftNummer = shaftNummer;
        Costs = costs;
        Locked = true;
    }
   
    public Shaft(int shaftNummer ,int lvl, float costs, float income, float producingTime)
    {
        ShaftNummer = shaftNummer;
        Lvl = lvl;
        Costs = costs;
        Income = income;
        ProducingTime = producingTime;
        Locked = false;
    }
}