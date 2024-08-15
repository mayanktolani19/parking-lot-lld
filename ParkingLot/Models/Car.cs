using System;

namespace ParkingLot.Models;

public class Car
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }

    public Car(string RegistrationNumber, string Color)
    {
        this.RegistrationNumber = RegistrationNumber;
        this.Color = Color;
    }
}
