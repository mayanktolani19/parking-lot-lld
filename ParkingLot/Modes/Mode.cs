using System;
using ParkingLot.Commands;
using ParkingLot.Exceptions;
using ParkingLot.Models;

namespace ParkingLot.Modes;

public abstract class Mode
{
    public CommandExecutorFactory CommandExecutorFactory { get; set; }
    public OutputPrinter OutputPrinter { get; set; }

    public Mode(CommandExecutorFactory commandExecutorFactory, OutputPrinter outputPrinter)
    {
        CommandExecutorFactory = commandExecutorFactory;
        OutputPrinter = outputPrinter;
    }

    protected void ProcessCommand(Command command)
    {
        CommandExecutor commandExecutor = CommandExecutorFactory.GetCommandExecutor(command);
        if (commandExecutor.Validate(command))
            commandExecutor.Execute(command);
        else
            throw new InvalidCommandException();
    }

    /*
    * Abstract method to process the mode. Each mode will process in its own way.
    */
    public abstract void Process();
}
