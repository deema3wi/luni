namespace Luni.Models.Interfaces;

public abstract class Model : IModel
{
	public int Id { get; set; }

	public Model() { }
	public Model(int id) { Id = id; }
	public Model(string row) => Become(row);

	public abstract string ToRow();
	public abstract void Become(string row);

	public static T Clone<T>(T orig) where T : Model, new()
	{
		string row = orig.ToRow();
		T model = new();
		model.Become(row);
		return model;
	}
}