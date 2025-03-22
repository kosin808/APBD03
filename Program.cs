namespace ConsoleApp1
{
public class MainClass
{
    public static void Main(string[] args)
    {
        Kontener kon1 = new Kontener(1000, 200, 100, 400, "A", 2000);
        Console.WriteLine(kon1.MasaLadunku+", "+kon1.Wysokosc+", "+kon1.WagaWlasna+", "+kon1.Glebokosc+", "+kon1.NumerSeryjny+", "+kon1.MaksymalnaLadownosc);
        Kontener kon2 = new Kontener(2000, 300, 200, 500, "A", 3000);
        Console.WriteLine(kon2.MasaLadunku+", "+kon2.Wysokosc+", "+kon2.WagaWlasna+", "+kon2.Glebokosc+", "+kon2.NumerSeryjny+", "+kon2.MaksymalnaLadownosc);
        kon2.OproznijKontener();
        Console.WriteLine(kon1.MasaLadunku+", "+kon1.Wysokosc+", "+kon1.WagaWlasna+", "+kon1.Glebokosc+", "+kon1.NumerSeryjny+", "+kon1.MaksymalnaLadownosc);
        Kontener.ZaladujKontener(kon2,100);
        Console.WriteLine(kon2.MasaLadunku+", "+kon2.Wysokosc+", "+kon2.WagaWlasna+", "+kon2.Glebokosc+", "+kon2.NumerSeryjny+", "+kon2.MaksymalnaLadownosc);
        KontenerPlyny kontenerPlyny = new KontenerPlyny(200, 300, 200, 500, "A", 3000,null,"Mleko");
        Console.WriteLine(kontenerPlyny.MasaLadunku+", "+kontenerPlyny.Wysokosc+", "+kontenerPlyny.WagaWlasna+", "+kontenerPlyny.Glebokosc+", "+kontenerPlyny.NumerSeryjny+", "+kontenerPlyny.MaksymalnaLadownosc+", "+ kontenerPlyny.LadunekNiebezpieczny+", "+kontenerPlyny.LadunekZwykly);
        Kontener.ZaladujKontener(kontenerPlyny,2500);
        Console.WriteLine(kontenerPlyny.MasaLadunku+", "+kontenerPlyny.Wysokosc+", "+kontenerPlyny.WagaWlasna+", "+kontenerPlyny.Glebokosc+", "+kontenerPlyny.NumerSeryjny+", "+kontenerPlyny.MaksymalnaLadownosc+", "+ kontenerPlyny.LadunekNiebezpieczny+", "+kontenerPlyny.LadunekZwykly);
        KontenerPlyny kontenerPlyny2 = new KontenerPlyny(200, 300, 200, 500, "A", 3000,null,"Mleko");
        Console.WriteLine(kontenerPlyny2.MasaLadunku+", "+kontenerPlyny2.Wysokosc+", "+kontenerPlyny2.WagaWlasna+", "+kontenerPlyny2.Glebokosc+", "+kontenerPlyny2.NumerSeryjny+", "+kontenerPlyny2.MaksymalnaLadownosc+", "+ kontenerPlyny2.LadunekNiebezpieczny+", "+kontenerPlyny2.LadunekZwykly);
        KontenerGaz kontenerGaz = new KontenerGaz(0, 200, 300, 100, "G", 2000, 10000);
        Console.WriteLine(kontenerGaz.Pressure);
        kontenerPlyny.OproznijKontener();
        kontenerGaz.OproznijKontener();
        Kontener.ZaladujKontener(kontenerGaz,100);
        KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy(0, 200, 300, 100, "G", 2000, "Banana",13.3);
        kontenerChlodniczy.OproznijKontener();
        Kontenerowiec kontenerowiec = new Kontenerowiec(100, 10, 500);
        kontenerowiec.ZaladujKontenerowiec(kon1);
        kontenerowiec.ZaladujKontenerowiec(kon2);
        List<Kontener> list = new List<Kontener>() {kontenerGaz,kontenerPlyny2,kontenerChlodniczy };
        kontenerowiec.ZaladujKontenerowiec(list);
        Kontenerowiec kontenerowiec2 = new Kontenerowiec(80, 3, 500);
        kontenerowiec.PrzeniesKontener(kontenerowiec2,kon1);
        kontenerowiec.WypiszZawartosc();
        Console.WriteLine(kontenerowiec);
    }
}
public class Kontener
{
    private static int Numer ;
    public double MasaLadunku { get; set; }
    public int Wysokosc { get; set; }
    public double WagaWlasna  { get; set; }
    public int Glebokosc { get; set; }
    
    public string NumerSeryjny = "KON-";
    public double MaksymalnaLadownosc { get; set; }
    public Kontener(double masaLadunku, int wysokosc, double wagaWlasna,int glebokosc,string numerSeryjny, double maksymalnaLadownosc )
    {
        MasaLadunku = masaLadunku;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        NumerSeryjny =NumerSeryjny+numerSeryjny+"-"+Numer++;
        MaksymalnaLadownosc = maksymalnaLadownosc; 
    }

   

    public virtual void OproznijKontener()
    {
        MasaLadunku = 0;
    }
    
    

    public static void ZaladujKontener(Kontener kontener, double masaLadunkuDoZaladunku)
    {
        try
        {
            if (masaLadunkuDoZaladunku>kontener.MaksymalnaLadownosc-kontener.MasaLadunku)
            {
                throw new OverfillException("Za duża masa załadunku");
            }
            kontener.MasaLadunku += masaLadunkuDoZaladunku;
            
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void ZaladujKontener(KontenerPlyny kontenerPlyny, double masaLadunkuDoZaladunku)
    {
        try
        {
            if (kontenerPlyny.Notify())
            {
                if (masaLadunkuDoZaladunku>kontenerPlyny.MaksymalnaLadownosc*0.5-kontenerPlyny.MasaLadunku)
                {
                    throw new OverfillException("Za duża masa załadunku");
                }
                kontenerPlyny.MasaLadunku += masaLadunkuDoZaladunku;
            }

            if (masaLadunkuDoZaladunku>kontenerPlyny.MaksymalnaLadownosc*0.9-kontenerPlyny.MasaLadunku)
            {
                throw new OverfillException("Za duża masa załadunku");
            }
            kontenerPlyny.MasaLadunku += masaLadunkuDoZaladunku;
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}
public class OverfillException : Exception
{
    public OverfillException()
    {
        
    }
    public OverfillException(String message) : base(message)
    {
        
    }
}

public class KontenerPlyny : Kontener, IHazardNotifier
{
    public KontenerPlyny(double masaLadunku, int wysokosc, double wagaWlasna, int glebokosc, string numerSeryjny, double maksymalnaLadownosc,string ladunekNiebezpieczny, string ladunekZwykly) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, numerSeryjny, maksymalnaLadownosc)
    {
        NumerSeryjny =NumerSeryjny.Remove(4,1);
        NumerSeryjny =NumerSeryjny.Insert(4, "L");
        LadunekNiebezpieczny = ladunekNiebezpieczny;
        LadunekZwykly = ladunekZwykly;
    }
    public string? LadunekNiebezpieczny { get; set; }
    public string? LadunekZwykly { get; set; }
    public bool Notify()
    {
        if (LadunekNiebezpieczny != null)
        {
            Console.WriteLine(NumerSeryjny + " zawiera "+ LadunekNiebezpieczny);
            return true;
        }
        return false;
    }
   
}

public class KontenerGaz : Kontener,IHazardNotifier
{
    public double Pressure { get; set; }
    public KontenerGaz(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, string numerSeryjny, int maksymalnaLadownosc,double pressure) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, numerSeryjny, maksymalnaLadownosc)
    {
        NumerSeryjny =NumerSeryjny.Remove(4,1);
        NumerSeryjny =NumerSeryjny.Insert(4, "G");
        Pressure = pressure;
    }
    public bool Notify()
    {
        Console.WriteLine(NumerSeryjny + " niebezpieczne zdarzenie");
        return true;
    }
    public override void OproznijKontener()
    {
        MasaLadunku *=0.05;
    }
}

public class KontenerChlodniczy:Kontener
{
    private string ProductType;
    private double Temperature;
    
    public KontenerChlodniczy(int masaLadunku, int wysokosc, int wagaWlasna, int glebokosc, string numerSeryjny, int maksymalnaLadownosc, string productType, double temperature) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, numerSeryjny, maksymalnaLadownosc)
    {
        NumerSeryjny =NumerSeryjny.Remove(4,1);
        NumerSeryjny =NumerSeryjny.Insert(4, "C");
        ProductType = productType;
        Temperature = temperature;
    }
}

public class Kontenerowiec
{
    private static int Id;
    public static List<Kontener> Konteners ;
    public int MaxSpeed { get; set; }
    public int MaxKonteners { get; set; }
    public double MaxWeight { get; set; }
    

    public Kontenerowiec(int maxSpeed, int maxKonteners, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxKonteners = maxKonteners;
        MaxWeight = maxWeight;
        Konteners = new List<Kontener>(MaxKonteners);
        Id++;
    }
    private double GetCurrentWeight(List<Kontener> konteners)
    {
        double currentWeight = 0;
        foreach (var kontener in konteners)
        {
            currentWeight += kontener.MasaLadunku*0.001;
        }

        return currentWeight;
    }
    public void ZaladujKontenerowiec(Kontener kontener)
    {
        if (Konteners.Count>=MaxKonteners)
        {
            throw new OverfillException("Przekroczono liczbe dostępnych miejsc dla kontenerów");
        }
        if (GetCurrentWeight(Konteners)+kontener.MasaLadunku*0.001>MaxWeight)
        {
            throw new OverfillException("Kontenerowiec nie udźwignie tego kontenera");
        }
        Konteners.Add(kontener);
    }
    public void ZaladujKontenerowiec(List<Kontener> kontenerList)
    {
        if (Konteners.Count+kontenerList.Count>MaxKonteners)
        {
            throw new OverfillException("Przekroczono liczbe dostępnych miejsc dla listy kontenerów");
        }

        if (GetCurrentWeight(Konteners)+GetCurrentWeight(kontenerList)>MaxWeight)
        {
            throw new OverfillException("Kontenerowiec nie udźwignie tej listy kontenerów");

        }
        foreach (var container in kontenerList)
        {
            Konteners.Add(container);
        }
    }

    public static void UsunKontener(Kontener kontener)
    {
        Konteners.Remove(kontener);
    }

    public void ZamienKontener(int numerKontenera,Kontener kontener)
    {
        Konteners[numerKontenera] = kontener;
    }

    public void PrzeniesKontener(Kontenerowiec statek2, Kontener kontener)
    {
        UsunKontener(kontener);
        statek2.ZaladujKontenerowiec(kontener);
    }

    public override string ToString()
    {
        return "Id "+Id+" MaxSpeed " + MaxSpeed + " MaxKonteners " + MaxKonteners + " MaxWeight" + MaxWeight;
    }

    public void WypiszZawartosc()
    {
        foreach (var kontener in Konteners)
        {
            Console.WriteLine(kontener.NumerSeryjny+", "+kontener.MasaLadunku+", "+kontener.Glebokosc+", "+kontener.Wysokosc+", "+kontener.MaksymalnaLadownosc+", "+kontener.WagaWlasna);
        }
    }
    
}
public interface IHazardNotifier
{
    bool Notify();
}

}