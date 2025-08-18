
using System.Net.Security;

namespace Luni.Models.Interfaces;

public class Settings : Model, ITimeSettings
{
	public TimeSpan LessonsStartAt { get ; set; }
	public TimeSpan LessonDuration { get; set; }
	public TimeSpan BreakDuration { get; set; }
	public TimeSpan LunchBreakDuration { get; set; }
	public int LunchBreakOrder { get; set; }
	public DateTime SemesterStartDate { get; set; }
	public TimeSpan StartTodayDifference
		=> new(DateTime.Today.Ticks - SemesterStartDate.Ticks);
	public virtual DateTime EndDate { get; set; }

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator, StringSplitOptions.RemoveEmptyEntries);
		if (sp.Length == 8)
			Id = int.Parse(sp[0]);
		else if (sp.Length < 7 || sp.Length > 8)
			ErrorCenter.LengthError("Settings.Become", sp.Length, "7-8");

		char sep = Parser.ArrayItemSeparator;
		int lbo = int.Parse(sp[^7]);
		int[] ls = [.. sp[^6].Split(sep, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
		int[] ld = [.. sp[^5].Split(sep, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
		int bd = int.Parse(sp[^4]);
		int lbd = int.Parse(sp[^3]);
		int[] ssd = [.. sp[^2].Split(sep, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
		int[] ed = [.. sp[^1].Split(sep, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];

		LessonsStartAt = new(ls[0], ls[1], 0);
		LessonDuration = new(ld[0], ld[1], 0);
		LessonDuration = new(0, bd, 0);
		LunchBreakDuration = new(0, lbd, 0);
		LunchBreakOrder = lbo;
		SemesterStartDate = new(ssd[2], ssd[1], ssd[0]);
		EndDate = new(ed[2], ed[1], ed[0]);
	}

	public override string ToRow()
	{
		char sep = Parser.ArrayItemSeparator;
		string ls = $"{LessonsStartAt.Hours}{sep}{LessonsStartAt.Minutes}";
		string ld = $"{LessonsStartAt.Hours}{sep}{LessonsStartAt.Minutes}";
		string bd = BreakDuration.Minutes.ToString();
		string lbd = LunchBreakDuration.Minutes.ToString();
		string ssd = $"{SemesterStartDate.Day}{sep}" +
			$"{SemesterStartDate.Month}{sep}" +
			$"{SemesterStartDate.Year}";
		string ed = $"{EndDate.Day}{sep}" +
			$"{EndDate.Month}{sep}" +
			$"{EndDate.Year}";
		string[] vals = [Id.ToString(), LunchBreakOrder.ToString(), ls, ld, bd, lbd, ssd, ed];
		string res = string.Join(Parser.ColumnSeparator, vals);
		return res;
	}
}
