using System;

namespace ParkingLot.Models;

public class Slot
{
    public Car? ParkedCar { get; set; }
    public int SlotNumber { get; set; }

    public Slot(int slotNumber)
    {
        SlotNumber = slotNumber;
    }

    public bool IsSlotFree()
    {
        return ParkedCar is null;
    }

    public void AssignCar(Car car)
    {
        ParkedCar = car;
    }

    public void UnassignCar()
    {
        ParkedCar = null;
    }
}
