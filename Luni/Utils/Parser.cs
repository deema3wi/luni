using System.Linq;

namespace Luni.Utils;

public static class Parser
{
	public static T[] ParseMany<T>(string context, Func<string, T> parser)
	{
		string[] sp = context.Split(ConverterUtil.Row);
		T[] result = new T[sp.Length];
		for (int i = 0; i < sp.Length; i++)
		{
			result[i] = parser(sp[i]);
		}

		return result;
	}

	public static string ToTable<T>(T[] vals, Func<T, string> converter)
		=> string.Join(ConverterUtil.Row, vals.Select(converter));
}
