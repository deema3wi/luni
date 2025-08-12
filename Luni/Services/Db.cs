namespace Luni.Services;

public partial class Db
{
	public List<Subject> Subjects { get; set; } = [];
	public List<Lesson> Lessons { get; set; } = [];
	public List<Day> Days { get; set; } = [];
	public List<Week> Weeks { get; set; } = [];
	//public List<> s { get; set; } = [];
}

public partial class Db
{
	public async Task LoadSubjects() => Subjects = await Subject.ReadTableAsync();
	public async Task LoadLessons() => Lessons = await Lesson.ReadTableAsync();
	public async Task LoadDays() => Days = await Day.ReadTableAsync();
	public async Task LoadWeeks() => Weeks = await Week.ReadTableAsync();

	public async Task LoadAll()
	{
		Task subj = Subject.ReadTableAsync();
		Task less = Lesson.ReadTableAsync();
		Task day = Day.ReadTableAsync();
		Task week = Week.ReadTableAsync();
		subj.Start();
		less.Start();
		day.Start();
		week.Start();

		await Task.WhenAll(subj, less, day, week);
	}
}

public partial class Db
{
	public int NewId(List<Model> models)
		=> models.Count > 0 ? models.Max(x => x.Id) : 1;
}