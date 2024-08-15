using System;
using System.Text;
using ParkingLot.Commands;
using ParkingLot.Models;

namespace ParkingLot.Modes;

public class FileMode : Mode
{
    public string FileName { get; set; }

    public FileMode(
        CommandExecutorFactory commandExecutorFactory,
        OutputPrinter outputPrinter,
        string fileName
    )
        : base(commandExecutorFactory, outputPrinter)
    {
        FileName = fileName;
    }

    public override void Process()
    {
        const Int32 BufferSize = 128;
        try
        {
            using (var fileStream = File.OpenRead(FileName))
            {
                using (
                    var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)
                )
                {
                    string? line = streamReader.ReadLine();
                    Console.WriteLine(line);
                    while (line != null)
                    {
                        Command command = new Command(line);
                        ProcessCommand(command);
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            OutputPrinter.PrintWithNewLine(e.Message);
            OutputPrinter.InvalidFile();
            return;
        }
        catch (Exception e)
        {
            OutputPrinter.PrintWithNewLine(e.Message);
            return;
        }
    }
}
