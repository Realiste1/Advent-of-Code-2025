
string[] Lines = File.ReadAllLines("code.txt");

int dial = 50;
int counter = 0;

foreach (string line in Lines)
{
	int number = Convert.ToInt32(line.Remove(0, 1));

	if (line[0] == 'L')
		dial -= number;
	else
		dial += number;

	dial %= 100;

	if (dial == 0)
		counter++;
}

Console.WriteLine($"Part 1: {counter}");

// Part 2
counter = 0;
dial = 50;

foreach (string line in Lines)
{
	int number = Convert.ToInt32(line.Remove(0, 1));

	for (int i = 0; i < number; i++)
	{
		if (line[0] == 'L')
			dial--;
		else
			dial++;

		if (dial == 0)
			counter++;
		if (dial < 0)
			dial += 100;
		if (dial == 100)
		{
			counter++;
			dial -= 100;
		}
	}
}

Console.WriteLine($"Part 2: {counter}");