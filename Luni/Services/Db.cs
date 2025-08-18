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
	public async Task LoadSubjectsAsync() => Subjects = Parser.FromTable<Subject>(await Storage.ReadAsync<Subject>());
	public async Task LoadLessonsAsync() => Lessons = Parser.FromTable<Lesson>(await Storage.ReadAsync<Lesson>());
	public async Task LoadDaysAsync() => Days = Parser.FromTable<Day>(await Storage.ReadAsync<Day>());
	public async Task LoadWeeksAsync() => Weeks = Parser.FromTable<Week>(await Storage.ReadAsync<Week>());
	
	public async Task LoadAll()
	{
		Task subj = LoadSubjectsAsync();
		Task less = LoadLessonsAsync();
		Task day = LoadDaysAsync();
		Task week = LoadWeeksAsync();

		subj.Start(); less.Start(); day.Start(); week.Start();
		await Task.WhenAll(subj, less, day, week);
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

	public static async Task<bool> LoadAndAdd<TModel, TRepo>(string row, TRepo repo)
		where TModel : Model, new()
		where TRepo : Repository<TModel>
	{
		TModel model = new();
		model.Become(row);
		await repo.LoadAsync();
		return repo.Add(model);
	}
}