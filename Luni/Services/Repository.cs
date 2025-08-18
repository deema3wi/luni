namespace Luni.Services;

public abstract class Repository<T>(Db db, List<T> list) where T : Model
{
	protected readonly Db _db = db;
	protected List<T> _list = list;

	public bool Add(T model)
	{
		if (model.Id == 0) SetId(model);
		bool canAdd = CanAdd(model);
		if (canAdd)
			_list.Add(model);

		return canAdd;
	}

	public bool Remove(T model) => _list.Remove(model);
	public void SetId(T model) => model.Id = Db.NewId(_list);
	public abstract bool CanAdd(T model);
	public abstract Task LoadAsync();
}