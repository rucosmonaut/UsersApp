namespace Users.Application.Users.Commands.UpdateUser;

using global::Users.Application.Common.Exceptions;
using global::Users.Application.Interfaces;
using global::Users.Domain;
using Microsoft.EntityFrameworkCore;

public class UpdateUserCommandHandler
    : IUpdateUserCommandHandler
{
    private readonly IUsersDbContext _dbContext;

    public UpdateUserCommandHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public void Handle(
        Guid id,
        string email,
        List<Profession> professionList)
    {
        var entity = this
            ._dbContext
            .Users
            .FirstOrDefault(user =>
                user.Id == id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(User), id);
        }

        entity.Email = email;
        entity.ProfessionList = professionList;
        entity.EditDate = DateTime.UtcNow;

        this
            ._dbContext
            .Users
            .Attach(entity);

        this
            ._dbContext
            .Users
            .Entry(entity)
            .CurrentValues
            .SetValues(entity);

        this
            ._dbContext
            .Users
            .Entry(entity).State = EntityState.Modified;

        this
            ._dbContext
            .SaveChanges();
    }
}
