using System;
using ParkingLot.Exceptions;

namespace ParkingLot.Models;

public class Command
{
    public string CommandName { get; set; } = "";
    public List<string> Params { get; set; } = new List<string>();

    public Command(string? inputLine)
    {
        List<string> tokenList = new List<string>();
        if (inputLine is not null)
        {
            tokenList = inputLine
                .Split(" ")
                .Select(s => s.Trim())
                .Where(token => token.Count() > 0)
                .ToList();
        }
        if (tokenList.Count() == 0)
            throw new InvalidCommandException();

        CommandName = tokenList[0];
        tokenList.RemoveAt(0);
        Params = tokenList;
    }
}
