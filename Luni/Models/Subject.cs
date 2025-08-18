namespace Luni.Models;

public partial class Subject : Model
{
	public string Name { get; set; } = string.Empty;

	public Subject() { }
	public Subject(int id) { Id = id; }
	public Subject(int id, string name)
	{
		Id = id;
		Name = name;
	}
	public Subject(string row) => Become(row);
}

public partial class Subject : Model
{
	public override string ToRow()
		=> $"{Id}{Parser.ColumnSeparator}{Name}";

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		if (sp.Length == 2)
			Id = int.Parse(sp[0]);
		else if (sp.Length < 1 || sp.Length > 2)
			ErrorCenter.LengthError("Subject.Become", sp.Length, "1-2");

		Name = sp[^1];
	}
}