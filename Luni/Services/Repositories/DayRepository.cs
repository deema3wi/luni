
namespace Luni.Services.Repositories;

public class DayRepository(Db db) : Repository<Day>(db, db.Days)
{
	public override bool CanAdd(Day model)
	{
		for (int i = 0; i < model.LessonIds.Count; i++)
			if (!_db.Lessons.Any(x => x.Id == model.LessonIds[i]))
				return false;

		if (model.DayOfWeek < 1 || model.DayOfWeek > 7)
			return false;

		if (_db.Days.Any(d => d.Id == model.Id))
			return false;

		return true;
	}

	public override async Task LoadAsync()
	{
		await _db.LoadDaysAsync();
		_list = _db.Days;
	}
}