namespace Domain.Common.Models
{
  public abstract class BaseEntity
  {
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
  }
}
