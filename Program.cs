using System;
using System.Xml.Serialization;
using System.IO;

namespace c_charp
{
    public enum EngineType
    {
        Petrol,
        Diesel
    }

    [Serializable]
    public class Engine
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public EngineType Type { get; set; }

        public Engine() {}

        public Engine(string name, string serialNumber, EngineType type)
        {
            Name = name;
            SerialNumber = serialNumber;
            Type = type;
        }
    }

    public enum СabinType
    {
        Standart,
        PolarDesign,
        TropicalDesign
    }

    [Serializable]
    public class Сabin
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public СabinType Type { get; set; }

        public Сabin() {}

        public Сabin(string name, string serialNumber, СabinType type)
        {
            Name = name;
            SerialNumber = serialNumber;
            Type = type;
        }
    }

    [Serializable]
    public class Tractor
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public Сabin Сabin { get; set; }
        public Engine Engine { get; set; }

        public Tractor() {}

        public Tractor(string name, string serialNumber, Сabin cabin, Engine engine)
        {
            Name = name;
            SerialNumber = serialNumber;
            Сabin = cabin;
            Engine = engine;
        }
    }

    class Program
    {
        static void Main(string[] args) 
        {
            var engine = new Engine("Turbo-Max-CrazyDazy-Disel", "1000HP", EngineType.Diesel);
            var cabin = new Сabin("Кабина 3000", "8-800-555", СabinType.TropicalDesign);
            var tractor = new Tractor("300-Трактариста", "34623-ДТ", cabin, engine);

            XmlSerializer formatter = new XmlSerializer(typeof(Tractor));
            using (FileStream fs = new FileStream("tractor.xml", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, tractor);
            }
        }
    }
}