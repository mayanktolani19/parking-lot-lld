using System;

namespace ParkingLot.Exceptions;

public class ParkingLotException : ApplicationException
{
    public ParkingLotException() { }

    public ParkingLotException(string message)
        : base(message) { }
}
