using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public abstract class CommandExecutor
{
    public ParkingLotService ParkingLotService { get; set; }
    public OutputPrinter OutputPrinter { get; set; }

    public CommandExecutor(ParkingLotService parkingLotService, OutputPrinter outputPrinter)
    {
        ParkingLotService = parkingLotService;
        OutputPrinter = outputPrinter;
    }

    public abstract bool Validate(Command command);
    public abstract void Execute(Command command);
}
