using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class SlotForRegNumberCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "slot_number_for_registration_number";

    public SlotForRegNumberCommandExecutor(
        ParkingLotService parkingLotService,
        OutputPrinter outputPrinter
    )
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        Slot? slot = ParkingLotService.FindSlotByRegNumber(command.Params[0]);
        if (slot is not null)
            OutputPrinter.PrintWithNewLine(slot.SlotNumber.ToString());
        else
            OutputPrinter.NotFound();
    }

    public override bool Validate(Command command)
    {
        return command.Params.Count() == 1;
    }
}
