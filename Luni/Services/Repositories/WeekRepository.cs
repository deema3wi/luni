
namespace Luni.Services.Repositories;

public class WeekRepository(Db db) : Repository<Week>(db, db.Weeks)
{
	public override bool CanAdd(Week model)
	{
		if (_db.Days.Count == 0) return false;

		for (int i = 0; i < model.DayIds.Count; i++)
			if (!_db.Days.Any(x => x.Id == model.DayIds[i]))
				return false;

		if (model.DayIds.Distinct().Count() != model.DayIds.Count)
			return false;

		return true;
	}

	public override async Task LoadAsync()
	{
		await _db.LoadWeeksAsync();
		_list = _db.Weeks;
	}
}