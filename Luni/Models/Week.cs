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
		if (sp.Length > 2 )
			Id = int.Parse(sp[0]);
		Order = int.Parse(sp[^2]);
		DayIds = [.. sp[^1].Split(',').Select(int.Parse)];
	}
}