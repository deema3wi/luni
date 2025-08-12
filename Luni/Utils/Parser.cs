using System.Linq;

namespace Luni.Utils;

public static class Parser
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
