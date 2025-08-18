using System.Diagnostics.CodeAnalysis;

namespace Luni.Services;

public partial class ErrorCenter
{
	public static IErrorMessagePrinter Printer { get; set; } = new TerminalPrinter();
	public static List<Exception> Errors { get; set; } = [];
	public static Action? HandleError { get; set; }

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
		await Storage.WriteAsync<ErrorCenter>(journal);
	}
}

public partial class ErrorCenter
{
	public static void LengthError(string method, int asIs, string mustBe)
	{
		ArgumentOutOfRangeException err = new($"{method} format err. Length = {asIs} MUST BE {mustBe}");
		Add(err);
		if (HandleError is null)
			HandleErrorDefault();

		HandleError.Invoke();
	}

	[DoesNotReturn]
	public static void HandleErrorDefault() => Environment.Exit((int)ErrorCode.Format);
}