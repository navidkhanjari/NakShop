using Common.Application;
using Shop.Application.Roles.Create;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission(f));
        });
        var role = new Role(request.Title, permissions);
        await _repository.AddAsync(role);
        await _repository.Save();

        return OperationResult.Success();
    }
}