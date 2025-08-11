namespace Luni.Models;

public sealed partial class SchoolTimeSettings : ITimeSettings
{
	public TimeSpan LessonsStartAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public TimeSpan LessonDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public TimeSpan BreakDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public TimeSpan LunchBreakDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public int LunchBreakOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public DateTime EndDate()
	{
		throw new NotImplementedException();
	}

	public DateTime StartDate()
	{
		throw new NotImplementedException();
	}
}
