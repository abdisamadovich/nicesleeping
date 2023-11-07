namespace Nicesleeping.Domain.Entities.Characteristics;

public class Characteristic : Auditable
{
    public long ProductId { get; set; }
    public string Textile { get; set; } = string.Empty;
    public long Height { get; set; }
    public long LoadPerBerth { get; set; }
    public string Rigidty { get; set; } = string.Empty;
    public long Waranty { get; set; }
}
