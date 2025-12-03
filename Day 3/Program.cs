
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

string[] batteries = File.ReadAllLines("batteries.txt");

long total1 = 0;

foreach (string battery in batteries)
{
	int highest = 0;

	int batteryLength = battery.Length;
	for(int i = 0; i < batteryLength; i++)
	{
		int n1 = Convert.ToInt32(battery[i].ToString());
		for(int j = i+1; j < batteryLength; j++)
		{
			int n2 = Convert.ToInt32(battery[j].ToString());
			int number = Convert.ToInt32($"{n1}{n2}");

			if(number > highest)
			{
				highest = number;
			}
		}
	}

	total1 += highest;
}

Console.WriteLine($"Part 1: {total1}");

// Part 2

long total2 = 0;

long RecursiveFind(string battery, int loops, string returns)
{
	long highest = 0;
	int index = 0;
	for (int i = 0; i < battery.Length; i++)
	{
		int number = Convert.ToInt32(battery[i].ToString());

		if (number > highest && i < battery.Length - loops)
		{
			highest = number;
			index = i;
		}
	}
	returns += battery[index].ToString();
	if (loops == 0)
		return Convert.ToInt64(returns.ToString());
	long finalLoop = RecursiveFind(battery[(index + 1)..], loops - 1, returns);
	if (loops != 11)
		return finalLoop;

	long final = finalLoop;

	return final;
	
}

foreach (string battery in batteries)
{
	total2 += RecursiveFind(battery, 11, "");
}

Console.WriteLine($"Part 2: {total2}");