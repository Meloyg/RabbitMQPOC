namespace Model.Dtos;

public class PayRunClosedEventDto
{
    public int PayRunId { get; set; }
    public DateTime PayRunClosedDate { get; set; }
    public string PayGroupName { get; set; }
}