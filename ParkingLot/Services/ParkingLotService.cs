using System;
using ParkingLot.Exceptions;
using ParkingLot.Models;
using ParkingLot.Strategies;

namespace ParkingLot.Services;

public class ParkingLotService
{
    public ParkingLotModel? ParkingLot { get; set; }

    public void CreateParkingLot(ParkingLotModel parkingLot)
    {
        if (ParkingLot is not null)
            throw new ParkingLotException("Parking lot already exists");
        ParkingLot = parkingLot;
    }

    public int Park(Car car)
    {
        ValidateParkingLotExists();
        Slot? slot = ParkingLot?.Park(car);
        if (slot is null)
            throw new NoFreeSlotAvailableException();
        return slot.SlotNumber;
    }

    public void MakeSlotFree(int slotNumber)
    {
        ValidateParkingLotExists();
        ParkingLot?.MakeSlotFree(slotNumber);
    }

    public List<Slot> GetOccupiedSlots()
    {
        ValidateParkingLotExists();
        List<Slot> occupiedSlotsList = new List<Slot>();
        for (int i = 1; i <= ParkingLot?.Capacity; i++)
        {
            if (ParkingLot.Slots.ContainsKey(i))
            {
                Slot slot = ParkingLot.Slots[i];
                if (!slot.IsSlotFree())
                {
                    occupiedSlotsList.Add(slot);
                }
            }
        }
        return occupiedSlotsList;
    }

    public List<Slot> GetSlotsForColor(String color)
    {
        List<Slot> occupiedSlots = GetOccupiedSlots();
        return occupiedSlots.Where(s => s?.ParkedCar?.Color == color).ToList();
    }

    public Slot? FindSlotByRegNumber(string regNumber)
    {
        Slot? foundSlot = ParkingLot
            ?.Slots.Where(slot => slot.Value?.ParkedCar?.RegistrationNumber == regNumber)
            .Select(slot => slot.Value)
            .FirstOrDefault();
        return foundSlot;
    }

    private void ValidateParkingLotExists()
    {
        if (ParkingLot == null)
        {
            throw new ParkingLotException("Parking lot does not exists to park.");
        }
    }
}
