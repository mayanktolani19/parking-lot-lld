using System;

namespace ParkingLot;

public class OutputPrinter
{
    public void Welcome()
    {
        PrintWithNewLine("Welcome to Go-Jek Parking lot.");
    }

    public void End()
    {
        PrintWithNewLine("Thanks for using Go-Jek Parking lot service.");
    }

    public void NotFound()
    {
        PrintWithNewLine("Not found");
    }

    public void StatusHeader()
    {
        PrintWithNewLine("Slot No.    Registration No    Colour");
    }

    public void ParkingLotFull()
    {
        PrintWithNewLine("Sorry, parking lot is full");
    }

    public void ParkingLotEmpty()
    {
        PrintWithNewLine("Parking lot is empty");
    }

    public void InvalidFile()
    {
        PrintWithNewLine("Invalid file given.");
    }

    public void PrintWithNewLine(String msg)
    {
        Console.WriteLine(msg);
    }
}
