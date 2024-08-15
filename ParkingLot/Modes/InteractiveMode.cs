using System;
using ParkingLot.Commands;
using ParkingLot.Models;

namespace ParkingLot.Modes;

public class InteractiveMode : Mode
{
    public InteractiveMode(
        CommandExecutorFactory commandExecutorFactory,
        OutputPrinter outputPrinter
    )
        : base(commandExecutorFactory, outputPrinter) { }

    public override void Process()
    {
        OutputPrinter.Welcome();
        while (true)
        {
            string? input = Console.ReadLine();
            Command command = new Command(input);
            ProcessCommand(command);
            if (command.CommandName.Equals(ExitCommandExecutor.CommandName))
            {
                break;
            }
        }
    }
}
