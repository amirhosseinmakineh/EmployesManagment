using EployeeManagment.ApplicationService.Contract.Dtos.User;

namespace EployeeManagment.ApplicationService.Contract.IService
{
    public interface IUserService
    {
        bool AddUser(AddUserDto dto);
        bool CheckUserExist(string name , string family);
        IList<UserDto> GetAll();
    }
}
