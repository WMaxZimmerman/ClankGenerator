using System;
using ClankGenerator.Shared.Enums;

namespace ClankGenerator.Shared.Models
{
    public class GameSpace
    {
	public string Key { get; set; }
	public SpaceType Type { get; set; }

	public int X { get; set; }
	public int Y { get; set; }
	
	public GameSpace(int x, int y)
	{
	    X = x;
	    Y = y;
	    Key = $"{X}-{Y}";

	    var values = Enum.GetValues(typeof(SpaceType));
	    var random = new Random();
	    Type = (SpaceType)values.GetValue(random.Next(values.Length));
	}

	public override string ToString()
	{
	    var output = "";

	    switch(Type)
	    {
		case SpaceType.Cave:
		    output = "C";
		    break;
		case SpaceType.Normal:
		    output = "N";
		    break;
		default:
		    output = "N";
		    break;
	    }
	    
	    return output;
	}
    }
}
