namespace Luni.Models;

public sealed partial class UniSettings : Settings
{
	public int SemesterWeeksAmount { get; set; }

	public override DateTime EndDate
	{
		get => CalculateEndDate(SemesterStartDate, SemesterWeeksAmount);
		set
		{
			// TODO: set weeks count
			throw new NotImplementedException();
		}
	}


	public static DateTime CalculateEndDate(DateTime start, int weeksPassed)
		=> start.AddDays(weeksPassed * 7);
}
