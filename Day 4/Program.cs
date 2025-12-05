
string[] Maze = File.ReadAllLines("maze.txt");

int total = 0;

int runTotal;
int iteration = 0;

do {
	iteration++;
	runTotal = 0;
	string[] newMaze = [];
	for (int i = 0; i < Maze.Length; i++)
	{
		char[] splicedMaze = Maze[i].ToCharArray();

		for (int j = 0; j < Maze[i].Length; j++)
		{
			if(Maze[i][j] == '@')
			{
				int adj = 0;

				int[][][] interval = [
					[[i-1, j-1], [i-1, j], [i-1, j+1]],
					[[i, j-1], [i, j], [i, j+1]],
					[[i+1, j-1], [i+1, j], [i+1, j+1]]
				];

				for (int l1 = 0; l1 < 3; l1++)
				{
					for (int l2 = 0; l2 < 3; l2++)
					{
						int cy = interval[l2][l1][0];
						int cx = interval[l2][l1][1];
						if(cy < 0 || cx < 0 || cy >= Maze.Length || cx >= Maze[i].Length || (cy == i && cx == j))
							continue;
						//Console.WriteLine($"Checking {i+1};{j+1}, for {cy+1};{cx+1}, found {Maze[cy][cx]}");
						if(Maze[cy][cx] == '@' || Maze[cy][cx] ==  'R')
						{
							adj++;
							//Console.WriteLine($"Found {Maze[cy][cx]} at {i+1};{j+1}, new total: {adj}");
						}
					}
				}
				if (adj < 4)
				{
					total++;
					runTotal++;
					//Console.WriteLine($"CAN BE REMOVED: {i+1};{j+1} FINAL total: {total}");
					// Part 2: Build new diagram
					splicedMaze[j] = 'R';
				}
			}
		}

		Maze[i] = string.Join("", splicedMaze);
	}

	if(iteration == 1)
		Console.WriteLine($"Part 1: {total}");
	Console.WriteLine($"Iteration #{iteration}: Removed {runTotal} blocks of paper.");

	
	for (int i = 0; i < Maze.Length; i++)
	{
		Maze[i] = Maze[i].Replace('R', '.');
	}
} while (runTotal != 0);

Console.WriteLine($"Total: {total}");