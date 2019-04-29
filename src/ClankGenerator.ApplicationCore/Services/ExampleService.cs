using System;
using System.Collections.Generic;
using ClankGenerator.DAL.Repositories;
using ClankGenerator.Shared.Models;

namespace ClankGenerator.ApplicationCore.Services
{
    public class ExampleService
    {
	public static GameBoard CreateBoard()
	{
	    var board = new GameBoard();

	    return board;
	}
	
        public static List<string> HelloWorld()
        {
	    var output = new List<string>();
	    var rand = new Random();
	    var pathCars = new List<char>{'-', '|', '/', '\\', 'X', ' '};
	    var horizontalPaths = new List<char>{'-', ' '};
	    var verticalPaths = new List<char>{'|', ' '};
	    var diagnolPaths = new List<char>{'/', '\\', 'X', ' '};

	    for (var i = 0; i < 3; i++)
	    {
		var line = "";
		for (var j = 0; j < 5; j++)
		{
		    var tile_int = rand.Next(1, 4);
		    var tile = 'N';
		    if (tile_int == 3) tile = 'C';
		    
		    line += tile;

		    if (j != 4)
		    {
			var num = rand.Next(0, horizontalPaths.Count);
			line += horizontalPaths[num];
		    }
		}
		output.Add(line);

		if (i != 2)
		{
		    var pathLine = "";

		    for (var x = 0; x < 9; x++)
		    {
			if (x % 2 == 0)
			{
			    var num = rand.Next(0, verticalPaths.Count);
			    pathLine += verticalPaths[num];
			}
			else
			{
			    var num = rand.Next(0, diagnolPaths.Count);
			    pathLine += diagnolPaths[num];
			}
		    }
		    
		    output.Add(pathLine);
		}
	    }
	    
	    return output;

        }
    }
}
