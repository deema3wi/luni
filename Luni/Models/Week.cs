namespace Luni.Models;

public partial class Week : Model
{
	public int Order { get; set; }
	public List<int> DayIds { get; set; } = [];
}

public partial class Week
{
	public Week() { }
	public Week(int id) { Id = id; }
	public Week(int id, int order, List<int> dayIds)
	{
		Id = id;
		Order = order;
		DayIds = dayIds;
	}
	public Week(string row) => Become(row);
}

public partial class Week
{
	public override string ToRow()
	{
		char sep = Parser.ColumnSeparator;
		string comsep = string.Join(',', DayIds);
		return $"{Id}{sep}{Order}{sep}{comsep}";
	}

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		if (sp.Length == 3)
			Id = int.Parse(sp[0]);
		else if (sp.Length < 2 || sp.Length > 3)
			ErrorCenter.LengthError("Week.Become", sp.Length, "2-3");

		Order = int.Parse(sp[^2]);
		DayIds = [.. sp[^1].Split(',').Select(int.Parse)];
	}
}