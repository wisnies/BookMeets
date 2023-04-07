namespace Contracts.Common
{
  public class BasePaginatedRequest
  {
    public int After { get; set; }
    public int Take { get; set; } = 8;
  }
}
