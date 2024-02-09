using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Commons.Configurations;
using WebApp.Domain.Entities.Users;
using WebApp.Service.DTOs.Users;

namespace WebApp.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserForViewDTO> CreateAsnyc(UserForCreationDTO userForCreationDTO);
        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User,bool>> expression);
        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params,Expression<Func<User, bool>> expression = null);
        ValueTask<bool> DeleteAsnyc(int id);
        ValueTask<UserForViewDTO> UpdateAsnyc(int id, UserForUpdateDTO userForUpdateDTO);
    }
}
