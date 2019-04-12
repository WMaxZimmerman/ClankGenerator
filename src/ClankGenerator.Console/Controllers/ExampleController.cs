using ClankGenerator.ApplicationCore.Services;
using CommandAndConquer.CLI.Attributes;

namespace ClankGenerator.Console.Controllers
{
    [CliController("example", "An example of a CLI Controller")]
    public class ExampleController
    {
        [CliCommand("hello", "A Hello World for a CLI Project")]
        public void HelloWorld()
        {
	    var output = ExampleService.HelloWorld();

	    foreach (var line in output)
	    {
		System.Console.WriteLine(line);
	    }
        }
    }
}
