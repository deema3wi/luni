namespace Luni.Services;

public partial class Db
{
	public Subject[] Subjects { get; set; } = [];
	public Lesson[] Lessons { get; set; } = [];
	public Day[] Days { get; set; } = [];
	public Week[] Weeks { get; set; } = [];
	//public [] s { get; set; } = [];
	//public [] s { get; set; } = [];
	//public [] s { get; set; } = [];
	//public [] s { get; set; } = [];
	//public [] s { get; set; } = [];
}

public partial class Db
{
	public async Task LoadSubjects() => Subjects = await Subject.ReadTableAsync();
	public async Task LoadLessons() => Lessons = await Lesson.ReadTableAsync();
	public async Task LoadDays() => Days = await Day.ReadTableAsync();
	public async Task LoadWeeks() => Weeks = await Week.ReadTableAsync();
}