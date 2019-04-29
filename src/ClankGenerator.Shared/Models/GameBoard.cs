using System;
using System.Collections.Generic;
using System.Linq;
using ClankGenerator.Shared.Enums;

namespace ClankGenerator.Shared.Models
{
    public class GameBoard
    {
	public List<List<GameSpace>> Spaces { get; set; }
	public List<Path> Paths { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	
	public GameBoard()
	{
	    Width = 5;
	    Height = 3;
	    var rand = new Random();
	    Paths = new List<Path>();

	    Spaces = new List<List<GameSpace>>();
	    for (var y = 0; y < Height; y++)
	    {
		var row = new List<GameSpace>();
		
		for (var x = 0; x < Width; x++)
		{
		    var space = new GameSpace(x, y);
		    row.Add(space);

		    if (x < (Width - 1))
		    {
			if (rand.Next(0,2) == 1)
			{
			    Paths.Add(new Path(x, y, x + 1, y));
			}
			
			if (y < (Height - 1))
			{
			    if (rand.Next(0,2) == 1)
			    {
				Paths.Add(new Path(x, y, x + 1, y + 1));
			    }
			}
		    }

		    if (y < (Height - 1))
		    {
			if (rand.Next(0,2) == 1)
			{
			    Paths.Add(new Path(x, y, x, y + 1));
			}
			
			if (x > 0)
			{
			    if (rand.Next(0,2) == 1)
			    {
				Paths.Add(new Path(x, y, x - 1, y + 1));
			    }
			}
		    }
		}

		Spaces.Add(row);
	    }
	}

	public override string ToString()
	{
	    var output = "";

	    for (var y = 0; y < Spaces.Count; y++)
	    {
		var row = Spaces[y];
		var verticalKeys = new List<string>();
		
		for (var x = 0; x < row.Count; x++)
		{
		    var space = row[x];
		    output += space.ToString();

		    if (x < (row.Count - 1))
		    {
			var key = $"{y}-{x}|{y}-{x+1}";
			var path = Paths.FirstOrDefault(p => p.Key == key);
			output += path == null ? "  " : "--";
		    }

		    verticalKeys
			.AddRange(Paths
				  .Where(p =>
					 p.Key.StartsWith($"{y}-{x}|{y+1}"))
				  .Select(k => k.Key));
		}
		output += "\n";

		if (y < (Spaces.Count - 1))
		{
		    // First Line of Path
		    for (var x = 0; x < row.Count; x++)
		    {
			var downLeft = $"{y}-{x}|{y+1}-{x-1}";
			var down = $"{y}-{x}|{y+1}-{x}";
			var downRight = $"{y}-{x}|{y+1}-{x+1}";

			output += (verticalKeys.Contains(downLeft)) && (x > 0) ? "/" : " ";
			output += (verticalKeys.Contains(down)) ? "|" : " ";
			output += (verticalKeys.Contains(downRight)) && (x < (row.Count - 1)) ? "\\" : " ";
		    }
		    output += "\n";

		    //Second Line of Path
		    for (var x = 0; x < row.Count; x++)
		    {
			var upLeft = $"{y}-{x-1}|{y+1}-{x}";
			var up = $"{y}-{x}|{y+1}-{x}";
			var upRight = $"{y}-{x+1}|{y+1}-{x}";

			output += (verticalKeys.Contains(upLeft)) && (x > 0) ? "\\" : " ";
			output += (verticalKeys.Contains(up)) ? "|" : " ";
			output += (verticalKeys.Contains(upRight)) && (x < (row.Count - 1)) ? "/" : " ";
		    }
		    output += "\n";
		}
	    }

	    return output;
	}
    }
}
