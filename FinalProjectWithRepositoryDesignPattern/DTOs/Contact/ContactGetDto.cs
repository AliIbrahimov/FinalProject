namespace FinalProjectWithRepositoryDesignPattern.DTOs.Contact;

public class ContactGetDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
    public bool IsDeleted { get; set; }
}
