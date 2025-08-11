using Luni.Services;

namespace Luni.Models;

public partial class Subject
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
}

public partial class Subject
{
	public Subject() { }

	public Subject(int id, string name)
	{
		Id = id;
		Name = name;
	}
}

public partial class Subject
{
	public static string ToRow(Subject sb)
		=> $"{sb.Id}{ConverterUtil.Col}{sb.Name}";

	public static Subject Parse(string row)
	{
		string[] sp = row.Split(ConverterUtil.Col);
		return new(int.Parse(sp[0]), sp[1]);
	}

	public static string ToTable(Subject[] sbs)
		=> Parser.ToTable(sbs, ToRow);

	public static Subject[] ParseMany(string table)
		=> Parser.ParseMany(table, Parse);
}

public partial class Subject
{
	public static string TablePath => PathProvider.SubjectsTable;

	public static async Task<Subject[]> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(Subject[] sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}