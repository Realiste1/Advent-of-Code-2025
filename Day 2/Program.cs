string[] patterns = File.ReadAllText("input.txt").Split(',');

long result = 0;

foreach (string pattern in patterns)
{
	long start = Convert.ToInt64(pattern.Split('-')[0]);
	long end = Convert.ToInt64(pattern.Split('-')[1]);

	for (long i = start; i <= end; i++)
	{
		int length = i.ToString().Length;
		if (length % 2 == 1)
			continue;
		long half = Convert.ToInt32(i.ToString().Remove(length / 2));
		if (i == Convert.ToInt64($"{half}{half}"))
		{
			result += i;
		}
	}
}


Console.WriteLine($"Partie 1 = {result}");

// Part 2
result = 0;

List<long> invalids = new List<long>();

foreach (string pattern in patterns)
{
	long start = Convert.ToInt64(pattern.Split('-')[0]);
	long end = Convert.ToInt64(pattern.Split('-')[1]);

	for (long i = start; i <= end; i++)
	{
		int length = i.ToString().Length;
		for (int j = 1; j <= length/2; j++)
		{
			if (length % j != 0)
				continue;
			long loop = Convert.ToInt64(i.ToString().Remove(j));
			string loopedNumber = "";
			for (int k = 1; k <= length / j; k++)
				loopedNumber += loop;
			if (i.ToString() == loopedNumber)
			{
				if(!invalids.Contains(i))
					invalids.Add(i);
			}
		}
	}
}

foreach (long invalid in invalids)
{
	result += invalid;
}

Console.WriteLine($"Partie 2 = {result}");