namespace Luni.Models;

public partial class Day : Model
{
	public int DayOfWeek { get; set; }
	public List<int> LessonIds { get; set; } = [];
}

public partial class Day
{
	public Day() { }
	public Day(int id) { Id = id; }
	public Day(int id, int dof, List<int> lessonIds)
	{
		Id = id;
		DayOfWeek = dof;
		LessonIds = lessonIds;
	}
	public Day(string row) => Become(row);
}

public partial class Day
{
	public override string ToRow()
	{
		char sep = Parser.ColumnSeparator;
		string comsep = string.Join(Parser.ArrayItemSeparator, LessonIds);
		return $"{Id}{sep}{DayOfWeek}{sep}{comsep}";
	}

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		if (sp.Length == 3)
			Id = int.Parse(sp[0]);
		else if (sp.Length < 2 || sp.Length > 3)
			ErrorCenter.LengthError("Day.Become", sp.Length, "2-3");

		DayOfWeek = int.Parse(sp[^2]);
		LessonIds = [.. sp[^1].Split(Parser.ArrayItemSeparator).Select(int.Parse)];
	}
}