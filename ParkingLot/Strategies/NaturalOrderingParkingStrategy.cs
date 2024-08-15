using System;
using ParkingLot.Exceptions;

namespace ParkingLot.Strategies;

public class NaturalOrderingParkingStrategy : ParkingStrategy
{
    public SortedSet<int> SlotSet { get; set; }

    public NaturalOrderingParkingStrategy()
    {
        SlotSet = new SortedSet<int>();
    }

    public void AddSlot(int slotNumber)
    {
        SlotSet.Add(slotNumber);
    }

    public int GetNextSlot()
    {
        if (SlotSet.Count == 0)
            throw new NoFreeSlotAvailableException();
        return SlotSet.First();
    }

    public void RemoveSlot(int slotNumber)
    {
        SlotSet.Remove(slotNumber);
    }
}
