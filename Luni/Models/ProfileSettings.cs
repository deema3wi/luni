namespace Luni.Models;

public class ProfileSettings
{
	public ShedType ShedType { get; set; }
	public List<int> WeekIds { get; set; } = [];
	public int SettingsId { get; set; }
}