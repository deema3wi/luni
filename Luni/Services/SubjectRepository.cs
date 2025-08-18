
namespace Luni.Services;

public class SubjectRepository(Db db) : Repository<Subject>(db, db.Subjects)
{
	public override bool CanAdd(Subject model)
	{
		bool duplicateName = _db.Subjects
			.Any(x => x.Name.Equals(model.Name, StringComparison.CurrentCultureIgnoreCase));
		return !duplicateName;
	}

	public override async Task LoadAsync()
	{
		await _db.LoadSubjectsAsync();
		_list = _db.Subjects;
	}
}