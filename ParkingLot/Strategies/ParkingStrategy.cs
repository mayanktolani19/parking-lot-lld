using System;

namespace ParkingLot.Strategies;

public interface ParkingStrategy
{
    public void AddSlot(int slotNumber);
    public void RemoveSlot(int slotNumber);
    public int GetNextSlot();
}
