
namespace Luni.Models.Interfaces;

public abstract class Settings : ITimeSettings
{
	public TimeSpan LessonsStartAt { get ; set; }
	public TimeSpan LessonDuration { get; set; }
	public TimeSpan BreakDuration { get; set; }
	public TimeSpan LunchBreakDuration { get; set; }
	public int LunchBreakOrder { get; set; }
	public DateTime SemesterStartDate { get; set; }
	public TimeSpan StartTodayDifference
		=> new(DateTime.Today.Ticks - SemesterStartDate.Ticks);

	public abstract DateTime EndDate();
}
