namespace Luni.Models;

public sealed partial class UniSettings : Settings
{
	public int SemesterWeeksAmount { get; set; }

	public override DateTime EndDate()
		=> EndDate(SemesterStartDate, SemesterWeeksAmount);

	public static DateTime EndDate(DateTime start, int weeksPassed)
		=> start.AddDays(weeksPassed * 7);
}
