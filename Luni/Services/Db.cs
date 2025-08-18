using System.Linq;

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
	public async Task LoadSubjects() => Subjects = Parser.FromTable<Subject>(await Storage.ReadAsync<Subject>());
	public async Task LoadLessons() => Lessons = Parser.FromTable<Lesson>(await Storage.ReadAsync<Lesson>());
	public async Task LoadDays() => Days = Parser.FromTable<Day>(await Storage.ReadAsync<Day>());
	public async Task LoadWeeks() => Weeks = Parser.FromTable<Week>(await Storage.ReadAsync<Week>());
	
	public async Task LoadAll()
	{
		Task<string> subj = Storage.ReadAsync<Subject>();
		Task<string> less = Storage.ReadAsync<Lesson>();
		Task<string> day = Storage.ReadAsync<Day>();
		Task<string> week = Storage.ReadAsync<Week>();

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
	public static int NewId<T>(List<T> models) where T : Model
		=> models.Count > 0 ? models.Max(x => x.Id) + 1 : 1;

	public static bool AddIfOtherContainsId<T>(List<T> dest, List<T> other, T model) where T : Model
	{
		bool contains = other.Any(x => x.Id == model.Id);
		if (contains)
			dest.Add(model);

		return contains;
	}

	public static bool AddIfOtherContainsId<TDest, TOther>
		(List<TDest> dest, List<TOther> other, TDest model, int? searchedId = null)
		where TDest : Model
		where TOther : Model
	{
		bool contains = other.Any(x => x.Id == searchedId);
		if (contains)
			dest.Add(model);

		return contains;
	}
}