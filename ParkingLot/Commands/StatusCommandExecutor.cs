using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class StatusCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "status";

    public StatusCommandExecutor(ParkingLotService parkingLotService, OutputPrinter outputPrinter)
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        List<Slot> occupiedSlots = ParkingLotService.GetOccupiedSlots();
        if (occupiedSlots.Count() == 0)
            OutputPrinter.ParkingLotEmpty();
        else
        {
            OutputPrinter.StatusHeader();
            foreach (Slot slot in occupiedSlots)
            {
                Car? parkedCar = slot.ParkedCar;
                string slotNumber = slot.SlotNumber.ToString();
                OutputPrinter.PrintWithNewLine(
                    PadString(slotNumber, 12)
                        + PadString(parkedCar?.RegistrationNumber, 19)
                        + parkedCar?.Color
                );
            }
        }
    }

    public override bool Validate(Command command)
    {
        return command.Params.Count() == 0;
    }

    private static string? PadString(string? word, int length)
    {
        string? newWord = word;
        for (int count = word?.Length ?? 0; count < length; count++)
        {
            newWord += " ";
        }
        return newWord;
    }
}
