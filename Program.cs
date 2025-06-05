namespace lab2_7;

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "computers.bin";
        var computers = new List<Computer>();

        new WriteComputersBinary().Use();

        if (File.Exists(filePath))
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var br = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                string processor = br.ReadString();
                string ram = br.ReadString();
                string videoCard = br.ReadString();
                string drive = br.ReadString();
                string soundCard = br.ReadString();
                string networkCard = br.ReadString();
                string operatingSystem = br.ReadString();

                computers.Add(new Computer(processor, ram, videoCard, drive, soundCard, networkCard, operatingSystem));
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        void PrintComputers(List<Computer> computers)
        {
            Console.WriteLine(
                $"{"Processor",-22} {"RAM",-12} {"VideoCard",-20} {"Drive",-12} {"SoundCard",-18} {"NetworkCard",-18} {"OS",-15} {"Price",8}");
            Console.WriteLine(new string('-', 125));
            foreach (var comp in computers)
            {
                Console.WriteLine(
                    $"{comp.Processor,-22} {comp.Ram,-12} {comp.VideoCard,-20} {comp.Drive,-12} {comp.SoundCard,-18} {comp.NetworkCard,-18} {comp.OperatingSystem,-15} {comp.CalculatePrice(),8}");
            }

            Console.WriteLine(new string('-', 125));
        }

        Console.WriteLine("Невідсортований список комп'ютерів:");
        PrintComputers(computers);
        computers.Sort();
        Console.WriteLine("Відсортований список комп'ютерів:");
        PrintComputers(computers);

        Console.WriteLine("Додаємо новий комп'ютер до списку:");
        var newComputer = new Computer("Intel i9", "32GB", "NVIDIA RTX 3080", "1TB SSD", "Realtek HD Audio",
            "Intel Wi-Fi 6", "Windows 11");
        computers.Add(newComputer);
        PrintComputers(computers);

        Console.WriteLine("Сортуємо список комп'ютерів після додавання нового:");
        computers.Sort();
        PrintComputers(computers);
        
        Console.WriteLine("Видаляжемо останній комп'ютер зі списку:");
        if (computers.Count > 0)
        {
            computers.RemoveAt(computers.Count - 1);
        }
        else
        {
            Console.WriteLine("Список комп'ютерів порожній.");
        }

        PrintComputers(computers);
    }
}