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

    public Guid Id { get; }

    public string Email { get; }

    public List<Profession> ProfessionList { get; }

    public DateTime CreationDate { get; }

    public DateTime? EditDate { get; }

    public DateTime? DeletedDate { get; }
}
