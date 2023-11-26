using OneModel.DTOs;

namespace OneModel.Interfaces;

public interface IUserService
{
    public Task<UserResultDto> AddAsync(UserCreationDto dto);   
    public Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    public Task<bool> RemoveAsync(long id);
    public UserResultDto RetrieveById(long id);
    public IEnumerable<UserResultDto> RetrieveAll();
}