using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneModel.DTOs;
using OneModel.Interfaces;
using OneModel.Models;
using System.Diagnostics.Eventing.Reader;

namespace OneModel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.AddAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RemoveAsync(id)
        });

    [HttpGet("get-by-id/{id:long}")]
    public IActionResult GetById(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = this.userService.RetrieveById(id)
        });

    [HttpGet("get-all")]
    public IActionResult GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = this.userService.RetrieveAll()
        });
}
