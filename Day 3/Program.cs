
string[] batteries = File.ReadAllLines("batteries.txt");

long total = 0;

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

	total += highest;
}

Console.WriteLine($"Part 1: {total}");

// Part 2

total = 0;

foreach (string battery in batteries)
{
	string sortedBattery = string.Join("", battery.OrderDescending());
	string highestVals = sortedBattery[..12];

	string newBattery = "";

	for(int i = 0; i < battery.Length; i++)
	{
		if(highestVals.Contains(battery[i].ToString()))
		{
			newBattery += battery[i];
		}
	}

	Stack<int> candidates = new Stack<int>();
	bool found = false;
	while (!found)
	{
		for(int i = 0; i < newBattery.Length; i++)
		{	
			
		}	
	}
}