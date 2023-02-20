namespace FinalProjectWithRepositoryDesignPattern.DTOs.Contact;

public class ContactPostDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsDeleted { get; set; }
}
