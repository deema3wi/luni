using System.Linq;

namespace Luni.Utils;

public static partial class Parser
{
	public static char ColumnSeparator => ';';
	public static char RowSeparator => '|';
	public static char ArrayItemSeparator => ',';

	public static List<T> ParseMany<T>(string context, Func<string, T> parser)
	{
		string[] sp = context.Split(RowSeparator);
		List<T> result = new(sp.Length);
		for (int i = 0; i < sp.Length; i++)
		{
			result[i] = parser(sp[i]);
		}

		return result;
	}

	public static string ToTable<T>(List<T> vals, Func<T, string> converter)
		=> string.Join(RowSeparator, vals.Select(converter));
}

public static partial class Parser
{
	// EXTENSIONS

	public static string ToTable(List<Model> models)
		=> string.Join(RowSeparator, models.Select(x => x.ToRow()));

	public static List<T> FromTable<T>(string table) where T : Model, new()
	{
		string[] rows = table.Split(RowSeparator);
		List<T> models = new(rows.Length);
		for (int i = 0; i < rows.Length; i++)
		{
			models[i] = new();
			models[i].Become(rows[i]);
		}

		return models;
	}
}