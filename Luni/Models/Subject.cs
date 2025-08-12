using Luni.Services;

namespace Luni.Models;

public partial class Subject : Model
{
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
		=> $"{sb.Id}{Parser.ColumnSeparator}{sb.Name}";

	public static Subject Parse(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		return new(int.Parse(sp[0]), sp[1]);
	}

	public static string ToTable(List<Subject> sbs)
		=> Parser.ToTable(sbs, ToRow);

	public static List<Subject> ParseMany(string table)
		=> Parser.ParseMany(table, Parse);
}

public partial class Subject
{
	public static string TablePath => PathProvider.SubjectsTable;

	public static async Task<List<Subject>> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(List<Subject> sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}