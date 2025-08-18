
namespace Luni.Services.Repositories;

public class SettingsRepository(Db db) : Repository<Settings>(db, db.Settings)
{
	public override bool CanAdd(Settings model)
	{
		throw new NotImplementedException();
	}

	public override async Task LoadAsync()
	{
		await _db.LoadSettingsAsync();
		_list = _db.Settings;
	}
}