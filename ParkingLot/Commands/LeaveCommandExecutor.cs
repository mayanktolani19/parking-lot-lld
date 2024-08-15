using System;
using ParkingLot.Models;
using ParkingLot.Services;
using ParkingLot.Strategies;

namespace ParkingLot.Commands;

public class LeaveCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "leave";

    public LeaveCommandExecutor(ParkingLotService parkingLotService, OutputPrinter outputPrinter)
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        int slotNumber = int.Parse(command.Params[0]);
        ParkingLotService.MakeSlotFree(slotNumber);
        OutputPrinter.PrintWithNewLine("Slot Number: " + slotNumber + " is free");
    }

    public override bool Validate(Command command)
    {
        if (command.Params.Count() != 1)
            return false;
        return int.TryParse(command.Params[0], out _);
    }
}
