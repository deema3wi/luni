namespace Luni.Models;

public partial class Week : Model
{
	public int Order { get; set; }
	public List<int> DayIds { get; set; } = [];
}

public partial class Week
{
	public Week() { }
	public Week(int id, int order, List<int> dayIds)
	{
		Id = id;
		Order = order;
		DayIds = dayIds;
	}
}

public partial class Week
{
	public static string ToRow(Week w)
	{
		char sep = Parser.ColumnSeparator;
		string comsep = string.Join(',', w.DayIds);
		return $"{w.Id}{sep}{w.Order}{sep}{comsep}";
	}

	public static Week Parse(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		List<int> ids = [.. sp[2].Split(',').Select(int.Parse)];
		int id = int.Parse(sp[0]);
		int order = int.Parse(sp[1]);
		return new(id, order, ids);
	}

	public static string ToTable(List<Week> weeks)
		=> Parser.ToTable(weeks, ToRow);

	public static List<Week> ParseMany(string table)
		=> Parser.ParseMany(table, Parse);
}

public partial class Week
{
	public static string TablePath => PathProvider.WeeksTable;

	public static async Task<List<Week>> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(List<Week> sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}