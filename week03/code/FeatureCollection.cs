using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

public class FeatureCollection
{

    public string Type { get; set; }

    public MetaData Metadata { get; set; }

    public List<Feature>   Features  { get; set; }

    public double[]  Bbox { get; set; }
    // TODO Problem 5 - ADD YOUR CODE HERE

    // Create additional classes as necessary
}

public class MetaData
{

    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }




}

public class Feature
{

    public string Type { get; set; }

    public Geometry  Geometry { get; set; }

    public Properties  Properties { get; set; }




    public string Id { get; set; }




}

public class Properties
{
    // public double? Mag { get; set; }
    // public string? Place { get; set; }
    // public long? Time { get; set; }
    // public long? Updated { get; set; }
    // public string? Tz { get; set; }
    // public string? Url { get; set; }
    // public string? Detail { get; set; }
    // public int? Felt { get; set; }
    // public int? Cdi { get; set; }
    // public string? Mmi { get; set; }
    // public string? Alert { get; set; }
    // public string? Status { get; set; }

    // public int? Tsunami { get; set; }
    // public int? Sig { get; set; }
    // public string? Net { get; set; }
    // public string? Code { get; set; }
    // public string? Ids { get; set; }
    // public string? Sources { get; set; }
    // public string? Types { get; set; }
    // public int? Nst { get; set; }
    // public double? Dmin { get; set; }
    // public double? Rms { get; set; }
    // public int? Gap { get; set; }
    // public string? MagType { get; set; }
    // public string? Type { get; set; }
    // public string? Title { get; set; }

     public double Mag { get; set; }
        public string Place { get; set; }
        public long Time { get; set; }
        public long Updated { get; set; }
        public double? Tz { get; set; }
        public string Url { get; set; }
        public string Detail { get; set; }
        public double? Felt { get; set; }
        public double? Cdi { get; set; }
        public double? Mmi { get; set; }
        public string Alert { get; set; }
        public string Status { get; set; }
        public double Tsunami { get; set; }
        public double Sig { get; set; }
        public string Net { get; set; }
        public string Code { get; set; }
        public string Ids { get; set; }
        public string Sources { get; set; }
        public string Types { get; set; }
        public double? Nst { get; set; }
        public double? Dmin { get; set; }
        public double? Rms { get; set; }
        public double? Gap { get; set; }
        public string MagType { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
}

public class Geometry
{

    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}