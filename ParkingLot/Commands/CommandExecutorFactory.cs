using System;
using ParkingLot.Exceptions;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class CommandExecutorFactory
{
    public Dictionary<string, CommandExecutor> Commands { get; set; }

    public CommandExecutorFactory(ParkingLotService parkingLotService)
    {
        Commands = new Dictionary<string, CommandExecutor>();
        OutputPrinter outputPrinter = new OutputPrinter();
        Commands.Add(
            CreateParkingLotCommandExecutor.CommandName,
            new CreateParkingLotCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            ParkCommandExecutor.CommandName,
            new ParkCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            ColorToRegNumberCommandExecutor.CommandName,
            new ColorToRegNumberCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            ColorToSlotNumberCommandExecutor.CommandName,
            new ColorToSlotNumberCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            ExitCommandExecutor.CommandName,
            new ExitCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            LeaveCommandExecutor.CommandName,
            new LeaveCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            SlotForRegNumberCommandExecutor.CommandName,
            new SlotForRegNumberCommandExecutor(parkingLotService, outputPrinter)
        );
        Commands.Add(
            StatusCommandExecutor.CommandName,
            new StatusCommandExecutor(parkingLotService, outputPrinter)
        );
    }

    public CommandExecutor GetCommandExecutor(Command command)
    {
        CommandExecutor commandExecutor = Commands[command.CommandName];
        if (commandExecutor is null)
            throw new InvalidCommandException();
        return commandExecutor;
    }
}
