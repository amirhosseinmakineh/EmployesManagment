using EployeeManagment.ApplicationService.Contract.Dtos.WorkHour;

namespace EployeeManagment.ApplicationService.Contract.IService
{
    public interface IWorkHourService
    {
        bool Add(AddWorkHourDto dto,long userId);
        bool CheckUserHour(long userId);
    }
}
