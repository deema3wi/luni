using Luni.Services;

namespace Luni.Models;

public partial class Week
{
	public int Id { get; set; }
	public int Order { get; set; }
	public int[] DayIds { get; set; } = [];
}

public partial class Week
{
	public Week() { }
	public Week(int id, int order, int[] dayIds)
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
		string sep = ConverterUtil.Col;
		string comsep = string.Join(',', w.DayIds);
		return $"{w.Id}{sep}{w.Order}{sep}{comsep}";
	}

	public static Week Parse(string row)
	{
		string[] sp = row.Split(ConverterUtil.Col);
		int[] ids = [.. sp[2].Split(',').Select(int.Parse)];
		int id = int.Parse(sp[0]);
		int order = int.Parse(sp[1]);
		return new(id, order, ids);
	}

	public static string ToTable(Week[] weeks)
		=> Parser.ToTable(weeks, ToRow);

	public static Week[] ParseMany(string table)
		=> Parser.ParseMany(table, Parse);
}

public partial class Week
{
	public static string TablePath => PathProvider.WeeksTable;

	public static async Task<Week[]> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(Week[] sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}