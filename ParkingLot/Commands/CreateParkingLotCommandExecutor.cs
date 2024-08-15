using System;
using ParkingLot.Models;
using ParkingLot.Services;
using ParkingLot.Strategies;

namespace ParkingLot.Commands;

public class CreateParkingLotCommandExecutor : CommandExecutor
{
    public static string CommandName { get; set; } = "create_parking_lot";

    public CreateParkingLotCommandExecutor(
        ParkingLotService parkingLotService,
        OutputPrinter outputPrinter
    )
        : base(parkingLotService, outputPrinter) { }

    public override void Execute(Command command)
    {
        int parkingLotCapacity = int.Parse(command.Params[0]);
        ParkingLotModel parkingLotModel = new ParkingLotModel(
            parkingLotCapacity,
            new NaturalOrderingParkingStrategy()
        );
        ParkingLotService.CreateParkingLot(parkingLotModel);
        OutputPrinter.PrintWithNewLine(
            "Created a parking lot with " + parkingLotModel.Capacity + "slots"
        );
    }

    public override bool Validate(Command command)
    {
        if (command.Params.Count() != 1)
            return false;
        return int.TryParse(command.Params[0], out _);
    }
}
