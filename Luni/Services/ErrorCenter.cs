namespace Luni.Services;

public static class ErrorCenter
{
	public static IErrorMessagePrinter Printer { get; set; } = new TerminalPrinter();
	public static List<Exception> Errors { get; set; } = [];

	public static void Add(Exception err)
	{
		Errors.Add(err);
		Printer.Print(err.Message);
	}

	public static void JournalErrors()
	{
		string dateTime = DateTime.Now.ToString();
	}
}