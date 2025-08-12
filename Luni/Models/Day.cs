namespace Luni.Models;

public partial class Day : Model
{
	public int DayOfWeek { get; set; }
	public int[] LessonIds { get; set; } = [];
}

public partial class Day
{
	public Day() { }
	public Day(int id, int dof, int[] lessonIds)
	{
		Id = id;
		DayOfWeek = dof;
		LessonIds = lessonIds;
	}
}

public partial class Day
{
	public static string ToRow(Day d)
	{
		char sep = Parser.ColumnSeparator;
		string comsep = string.Join(Parser.ArrayItemSeparator, d.LessonIds);
		return $"{d.Id}{sep}{d.DayOfWeek}{sep}{comsep}";
	}

	public static Day Parse(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		int[] ids = [.. sp[2].Split(Parser.ArrayItemSeparator).Select(int.Parse)];
		int id = int.Parse(sp[0]);
		int dof = int.Parse(sp[1]);
		return new(id, dof, ids);
	}

	public static string ToTable(Day[] days)
		=> Parser.ToTable(days, ToRow);

	public static Day[] ParseMany(string table)
		=> Parser.ParseMany(table, Parse);
}

public partial class Day
{
	public static string TablePath => PathProvider.DaysTable;

	public static async Task<Day[]> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(Day[] sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}