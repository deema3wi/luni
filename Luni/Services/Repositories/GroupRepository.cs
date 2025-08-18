
namespace Luni.Services.Repositories;

public class GroupRepository(Db db) : Repository<Group>(db, db.Groups)
{
	public override bool CanAdd(Group model)
	{
		if (model.WeekIds.Distinct().Count() != model.WeekIds.Count)
			return false;

		if (!_db.Settings.Any(s => s.Id == model.SettingsId))
			return false;

		bool any = _list.Any(g => g.Name.ToLower() == model.Name.ToLower());
		if (any) return false;

		return true;
	}

	public override async Task LoadAsync()
	{
		await _db.LoadGroupsAsync();
		_list = _db.Groups;
	}
}