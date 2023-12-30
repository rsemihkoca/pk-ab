namespace Vb.Base.Schema;

public abstract class BaseResponse
{
    public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
}