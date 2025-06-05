using System;

namespace lab2_7;

public class Computer : IComparable<Computer>
{
    public Computer(string processor, string ram, string videoCard, string drive, string soundCard,
        string networkCard, string operatingSystem)
    {
        Processor = processor;
        Ram = ram;
        VideoCard = videoCard;
        Drive = drive;
        SoundCard = soundCard;
        NetworkCard = networkCard;
        OperatingSystem = operatingSystem;
    }

    public string Processor { get; set; }
    public string Ram { get; set; }
    public string VideoCard { get; set; }
    public string Drive { get; set; }
    public string SoundCard { get; set; }
    public string NetworkCard { get; set; }
    public string OperatingSystem { get; set; }

    public double CalculatePrice()
    {
        double processorPrice = Processor.GetHashCode() / 100000f;
        double ramPrice = Ram.GetHashCode() / 100000f;
        double videoCardPrice = VideoCard.GetHashCode() / 100000f;
        double drivePrice = Drive.GetHashCode() / 100000f;
        double soundCardPrice = SoundCard.GetHashCode() / 100000f;
        double networkCardPrice = NetworkCard.GetHashCode() / 100000f;
        double operatingSystemPrice = OperatingSystem.GetHashCode() / 100000f;

        return Math.Round(Math.Abs(
            processorPrice + ramPrice + videoCardPrice + drivePrice + soundCardPrice
            + networkCardPrice + operatingSystemPrice), 2);
    }

    public int CompareTo(Computer? other)
    {
        return other == null ? 1 : CalculatePrice().CompareTo(other.CalculatePrice());
    }
}