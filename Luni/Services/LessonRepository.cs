namespace Luni.Services;

public class LessonRepository(Db db) : Repository<Lesson>(db, db.Lessons)
{
	public override bool CanAdd(Lesson model)
	{
		if (_db.Subjects.Count == 0)
			throw new ArgumentException("_db.Subjects is empty. Cannot create lesson without subject");

		bool validOrder = model.Order >= 1 && model.Order <= 8;
		bool subjExists = _db.Subjects.Any(s => s.Id == model.SubjId);

		return validOrder && subjExists;
	}

	public override async Task LoadAsync()
	{
		await _db.LoadLessonsAsync();
		_list = _db.Lessons;
	}
}