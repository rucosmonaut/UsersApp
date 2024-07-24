namespace Users.Application.Users.Queries.GetUserList;

using global::Users.Domain;

public class UserLookupDto
{
    public UserLookupDto(
        Guid id,
        string email,
        List<Profession> professionList,
        DateTime creationDate,
        DateTime? editDate,
        DateTime? deletedDate)
    {
        this.Id = id;
        this.Email = email;
        this.ProfessionList = professionList;
        this.CreationDate = creationDate;
        this.EditDate = editDate;
        this.DeletedDate = deletedDate;
    }

    public Guid Id { get; set; }

    public string Email { get; set; }

    public List<Profession> ProfessionList { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? EditDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
