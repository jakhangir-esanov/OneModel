using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneModel.Contexts;
using OneModel.DTOs;
using OneModel.Entities;
using OneModel.Exceptions;
using OneModel.Interfaces;
using System;

namespace OneModel.Services;

public class UserService : IUserService
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;
    public UserService(AppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = context.Users.FirstOrDefault(x => x.Email.Equals(dto.Email));
        if (user is not null)
            throw new AlreadyExistException("Already exist!");

        var mapUser = mapper.Map<User>(dto);
        await context.AddAsync(mapUser);
        await context.SaveChangesAsync();

        var res = mapper.Map<UserResultDto>(mapUser);
        return res;
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var user = context.Users.FirstOrDefault(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("User is not found!");

        var mapUser = mapper.Map(dto, user);
        context.Users.Update(mapUser);
        await context.SaveChangesAsync();

        var res = mapper.Map<UserResultDto>(mapUser);
        return res;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id.Equals(id))
            ?? throw new NotFoundException("User is not found!");

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return true;
    }
    public UserResultDto RetrieveById(long id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id.Equals(id))
            ?? throw new NotFoundException("User is not found!");

        var res = mapper.Map<UserResultDto>(user);
        return res;
    }

    public IEnumerable<UserResultDto> RetrieveAll()
    {
        var users = context.Users.AsNoTracking().ToList();
        var res = mapper.Map<IEnumerable<UserResultDto>>(users);
        return res;
    }
}
