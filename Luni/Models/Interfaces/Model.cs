namespace Luni.Models.Interfaces;

public abstract class Model
{
	public int Id { get; set; }

	public abstract string ToRow();
	public abstract void Become(string row);
	public T Clone<T>() where T : Model, new()
	{
		string row = ToRow();
		T model = new();
		model.Become(row);
		return model;
	}
}