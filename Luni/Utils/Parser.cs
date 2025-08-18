namespace Luni.Utils;

public static partial class Parser
{
	public static char ColumnSeparator => ';';
	public static char RowSeparator => '|';
	public static char ArrayItemSeparator => ',';

	public static string ToTable<T>(List<T> vals) where T : Model
		=> string.Join(RowSeparator, vals.Select(x => x.ToRow()));

	public static List<T> FromTable<T>(string table) where T : Model, new()
	{
		if (table == string.Empty) return [];

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