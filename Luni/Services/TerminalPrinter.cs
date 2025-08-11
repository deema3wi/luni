namespace Luni.Services;

public class TerminalPrinter : IErrorMessagePrinter
{
	public void Print(string message) => Console.WriteLine(message);
}