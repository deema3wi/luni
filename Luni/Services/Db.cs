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
		Task<List<Subject>> subj = Subject.ReadTableAsync();
		Task<List<Lesson>> less = Lesson.ReadTableAsync();
		Task<List<Day>> day = Day.ReadTableAsync();
		Task<List<Week>> week = Week.ReadTableAsync();
		subj.Start();
		less.Start();
		day.Start();
		week.Start();

		await Task.WhenAll(subj, less, day, week);
		(Subjects, Lessons, Days, Weeks) =
			(subj.Result, less.Result, day.Result, week.Result);
	}
}

public partial class Db
{
	public static int NewId(List<Model> models)
		=> models.Count > 0 ? models.Max(x => x.Id) : 1;

	public static (bool, List<Model>) AddIfOtherContainsId(List<Model> dest, List<Model> other, Model model)
	{
		if (other.Select(x => x.Id).Contains(model.Id))
		{
			dest.Add(model);
			return (true, dest);
		}

		return (false, dest);
	}
}