namespace Luni.Services;

public class ErrorCenter
{
	public static IErrorMessagePrinter Printer { get; set; } = new TerminalPrinter();
	public static List<Exception> Errors { get; set; } = [];

	public static void Add(Exception err)
	{
		Errors.Add(err);
		Printer.Print(err.Message);
	}

	public static async Task JournalErrorsAsync()
	{
		string journal = DateTime.Now.ToString();
		for (int i = 0; i < Errors.Count; i++)
		{
			journal = Errors[i].ToString() + Environment.NewLine + journal;
		}

		string path = PathProvider.GetPath<ErrorCenter>();
		await Storage.Write<ErrorCenter>(journal);
	}
}