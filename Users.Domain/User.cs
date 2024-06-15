namespace Users.Domain;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = default!;

    public List<Profession> ProfessionList { get; set; } = default!;

    public DateTime CreationDate { get; set; }

    public DateTime? EditDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
