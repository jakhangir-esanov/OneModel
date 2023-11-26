using Microsoft.AspNetCore.Mvc;
using OneModel.DTOs;

namespace OneModel.Tests.Controllers;

public class UserControllerTest
{
    private readonly IUserService userService;
    private readonly UserController userController;
    public UserControllerTest()
    {
        this.userService = A.Fake<IUserService>();
        this.userController = new UserController(this.userService);
    }

    [Fact]
    public async Task ShouldCreateUserSuccessfullyReturnStatusCodeOk()
    {
        //Arrange
        var newUser = new UserCreationDto()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "example@mail.com",
            Password = "password",
            DateOfBirth = DateTime.UtcNow
        };

        //Act
        var result = await userController.CreateAsync(newUser);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ShouldDeleteUserSuccessfullyReturnStatusCodeOk() 
    {
        //Arrange
        long id = 1;

        //Act
        var result = await userController.DeleteAsync(id);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ShouldUpdateUserSuccessfullyReturnStatusCodeOk() 
    {
        //Arrange
        var updatedUser = new UserUpdateDto()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "updated@mail.com",
            Password = "password",
            DateOfBirth = DateTime.UtcNow
        };

        //Act
        var result = await userController.UpdateAsync(updatedUser);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ShouldGetByIdUserSuccessfullyReturnStatusCodeOk()
    {
        //Arrange
        long id = 1;

        //Act
        var result =  userController.GetById(id);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ShouldGetAllUserSuccessfullyReturnStatusCodeOk()
    {
        //Arrange

        //Act
        var result = userController.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }
}
