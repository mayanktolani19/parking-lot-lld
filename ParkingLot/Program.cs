// See https://aka.ms/new-console-template for more information
using ParkingLot;
using ParkingLot.Commands;
using ParkingLot.Exceptions;
using ParkingLot.Modes;
using ParkingLot.Services;

public class Program
{
    public static void Main(string[] args)
    {
        OutputPrinter outputPrinter = new OutputPrinter();

        ParkingLotService parkingLotService = new ParkingLotService();

        CommandExecutorFactory commandExecutorFactory = new CommandExecutorFactory(
            parkingLotService
        );

        if (IsInteractiveMode(args))
            new InteractiveMode(commandExecutorFactory, outputPrinter).Process();
        else if (IsFileInputMode(args))
            new ParkingLot.Modes.FileMode(commandExecutorFactory, outputPrinter, args[0]).Process();
        else
            throw new InvalidModeException();
    }

    private static bool IsInteractiveMode(string[] args) => args.Length == 0;

    private static bool IsFileInputMode(string[] args) => args.Length == 1;
}
