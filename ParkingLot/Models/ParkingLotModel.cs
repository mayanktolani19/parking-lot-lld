using System;
using ParkingLot.Exceptions;
using ParkingLot.Strategies;

namespace ParkingLot.Models;

public class ParkingLotModel
{
    public static int MaxCapacity { get; set; } = 100000;
    public int Capacity { get; set; }
    public Dictionary<int, Slot> Slots { get; set; }
    ParkingStrategy ParkingStrategy { get; set; }

    public ParkingLotModel(int capacity, ParkingStrategy parkingStrategy)
    {
        if (capacity > MaxCapacity || capacity <= 0)
        {
            throw new ParkingLotException("Invalid capacity");
        }
        Capacity = capacity;
        Slots = new Dictionary<int, Slot>();
        ParkingStrategy = parkingStrategy;
        for (int i = 1; i <= Capacity; i++)
        {
            parkingStrategy.AddSlot(i);
        }
    }

    private Slot GetSlot(int slotNumber)
    {
        if (slotNumber > Capacity || slotNumber <= 0)
            throw new InvalidSlotException();
        if (!Slots.ContainsKey(slotNumber))
        {
            Slots.Add(slotNumber, new Slot(slotNumber));
        }
        return Slots[slotNumber];
    }

    public Slot Park(Car car)
    {
        int slotNumber = ParkingStrategy.GetNextSlot();
        Slot slot = GetSlot(slotNumber);
        slot.AssignCar(car);
        ParkingStrategy.RemoveSlot(slotNumber);
        return slot;
    }

    public Slot MakeSlotFree(int slotNumber)
    {
        ParkingStrategy.AddSlot(slotNumber);
        Slot slot = GetSlot(slotNumber);
        slot.UnassignCar();
        return slot;
    }
}
