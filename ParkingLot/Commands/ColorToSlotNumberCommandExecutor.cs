using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class ColorToSlotNumberCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "slot_numbers_for_cars_with_colour";

    public ColorToSlotNumberCommandExecutor(
        ParkingLotService parkingLotService,
        OutputPrinter outputPrinter
    )
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        List<Slot> slotsForColor = ParkingLotService.GetSlotsForColor(command.Params[0]);
        if (slotsForColor.Count() == 0)
            OutputPrinter.NotFound();
        else
        {
            string result = string.Join(
                ", ",
                slotsForColor.Select(slot => slot?.SlotNumber).ToList()
            );
            OutputPrinter.PrintWithNewLine(result);
        }
    }

    public override bool Validate(Command command)
    {
        return command.Params.Count() == 1;
    }
}
