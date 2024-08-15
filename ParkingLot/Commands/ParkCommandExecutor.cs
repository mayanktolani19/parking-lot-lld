using System;
using ParkingLot.Exceptions;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot.Commands;

public class ParkCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "park";

    public ParkCommandExecutor(ParkingLotService parkingLotService, OutputPrinter outputPrinter)
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        Car car = new Car(command.Params[0], command.Params[1]);
        try
        {
            int slotNumber = ParkingLotService.Park(car);
            OutputPrinter.PrintWithNewLine("Allocated slot number: " + slotNumber);
        }
        catch (NoFreeSlotAvailableException ex)
        {
            OutputPrinter.PrintWithNewLine("Exception occurred " + ex.Message);
            OutputPrinter.ParkingLotFull();
        }
    }

    public override bool Validate(Command command)
    {
        return command.Params.Count() == 2;
    }
}
