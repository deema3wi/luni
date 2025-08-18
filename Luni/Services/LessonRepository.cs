namespace Luni.Services;

public class LessonRepository(Db db) : Repository<Lesson>(db, db.Lessons)
{
	public override bool CanAdd(Lesson model)
	{
		bool validOrder = model.Order >= 1 && model.Order <= 8;
		bool subjExists = _db.Subjects.Any(s => s.Id == model.SubjId);

		return validOrder && subjExists;
	}
}