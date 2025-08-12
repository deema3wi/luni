using System.Linq;

namespace Luni.Utils;

public static class Parser
{
	public static char ColumnSeparator => ';';
	public static char RowSeparator => '|';
	public static char ArrayItemSeparator => ',';

	public static T[] ParseMany<T>(string context, Func<string, T> parser)
	{
		string[] sp = context.Split(RowSeparator);
		T[] result = new T[sp.Length];
		for (int i = 0; i < sp.Length; i++)
		{
			result[i] = parser(sp[i]);
		}

		return result;
	}

	public static string ToTable<T>(T[] vals, Func<T, string> converter)
		=> string.Join(RowSeparator, vals.Select(converter));
}
