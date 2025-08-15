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
	public async Task LoadSubjects() => Subjects = Parser.FromTable<Subject>(await Storage.Read<Subject>());
	public async Task LoadLessons() => Lessons = Parser.FromTable<Lesson>(await Storage.Read<Lesson>());
	public async Task LoadDays() => Days = Parser.FromTable<Day>(await Storage.Read<Day>());
	public async Task LoadWeeks() => Weeks = Parser.FromTable<Week>(await Storage.Read<Week>());
	
	public async Task LoadAll()
	{
		Task<string> subj = Storage.Read<Subject>();
		Task<string> less = Storage.Read<Lesson>();
		Task<string> day = Storage.Read<Day>();
		Task<string> week = Storage.Read<Week>();

		subj.Start(); less.Start(); day.Start(); week.Start();
		await Task.WhenAll(subj, less, day, week);

		Subjects = Parser.FromTable<Subject>(subj.Result);
		Lessons = Parser.FromTable<Lesson>(subj.Result);
		Days = Parser.FromTable<Day>(subj.Result);
		Weeks = Parser.FromTable<Week>(subj.Result);
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