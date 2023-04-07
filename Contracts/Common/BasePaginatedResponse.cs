namespace Contracts.Common
{
  public class BasePaginatedResponse<T> where T : class
  {
    public bool HasMore { get; set; }
    public IEnumerable<T> Data { get; set; }
  }
}
