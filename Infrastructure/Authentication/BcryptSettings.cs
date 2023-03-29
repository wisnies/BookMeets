namespace Infrastructure.Authentication
{
  public class BcryptSettings
  {
    public const string SectionName = "BcryptSettings";
    public int KeySize { get; set; }
    public int Iterations { get; set; }
  }
}
