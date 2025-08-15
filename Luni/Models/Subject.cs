namespace Luni.Models;

public partial class Subject : Model
{
	public string Name { get; set; } = string.Empty;

	public Subject() { }

	public Subject(int id, string name)
	{
		Id = id;
		Name = name;
	}
}

public partial class Subject : Model
{
	public override string ToRow()
		=> $"{Id}{Parser.ColumnSeparator}{Name}";

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		Id = int.Parse(sp[0]);
		Name = sp[1];
	}
}