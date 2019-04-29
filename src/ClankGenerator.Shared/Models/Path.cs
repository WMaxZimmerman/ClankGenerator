using System;
using ClankGenerator.Shared.Enums;

namespace ClankGenerator.Shared.Models
{
    public class Path
    {
	public string Key { get; set; }
	public PathType Type { get; set; }
	
	public Path(int x1, int y1, int x2, int y2)
	{
	    Key = $"{y1}-{x1}|{y2}-{x2}";
	}

	public override string ToString()
	{
	    var output = "";
	    
	    return output;
	}
    }
}
