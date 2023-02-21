﻿using System.ComponentModel;

List<int> playerOne = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

List<int> playerTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

int sum = 0;

while (true)
{
    if (playerOne[0] > playerTwo[0])
    {
        playerOne.Add(playerOne[0]);
        playerOne.Add(playerTwo[0]);
    }
    else if (playerOne[0] < playerTwo[0])
    {
        playerTwo.Add(playerTwo[0]);
        playerTwo.Add(playerOne[0]);
    }

    playerOne.Remove(playerOne[0]);
    playerTwo.Remove(playerTwo[0]);

    if (playerOne.Count == 0)
    {
        sum = playerTwo.Sum();
        Console.WriteLine($"Second player wins! Sum: {sum}");
        break;
    }
    else if (playerTwo.Count == 0)
    {
        sum = playerOne.Sum();
        Console.WriteLine($"First player wins! Sum: {sum}");
        break;
    }
}
