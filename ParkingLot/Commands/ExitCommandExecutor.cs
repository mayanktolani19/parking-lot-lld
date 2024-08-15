using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class ExitCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "exit";

    public ExitCommandExecutor(ParkingLotService parkingLotService, OutputPrinter outputPrinter)
        : base(parkingLotService, outputPrinter) { }

    public override bool Validate(Command command)
    {
        return command.Params.Count() == 0;
    }

    public override void Execute(Command command)
    {
        OutputPrinter.End();
    }
}
