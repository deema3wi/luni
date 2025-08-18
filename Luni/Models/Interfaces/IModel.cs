namespace Luni.Models.Interfaces;

public interface IModel
{
	int Id { get; set; }
	string ToRow();
	void Become(string row);
}
