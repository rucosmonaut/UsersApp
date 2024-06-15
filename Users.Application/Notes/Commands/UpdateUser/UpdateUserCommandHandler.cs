namespace Users.Application.Notes.Commands.UpdateUser;

using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain;

public class UpdateUserCommandHandler
    : IUpdateUserCommandHandler
{
    private readonly IUsersDbContext _dbContext;

    public UpdateUserCommandHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task HandleAsync(
        Guid id,
        string email,
        List<Profession> professionList)
    {
        var entity = await _dbContext
            .Users
            .FirstOrDefaultAsync(note =>
                note.Id == id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(User), id);
        }

        entity.Email = email;
        entity.ProfessionList = professionList;
        entity.EditDate = DateTime.UtcNow;

        this
            ._dbContext
            .SaveChanges();
    }
}
