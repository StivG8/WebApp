using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.IRepositories;
using WebApp.Domain.Commons.Configurations;
using WebApp.Domain.Entities.Users;
using WebApp.Service.DTOs.Users;
using WebApp.Service.Exceptions;
using WebApp.Service.Extensions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IMapper mapper;
        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserForViewDTO> CreateAsnyc(UserForCreationDTO userForCreationDTO)
        {
            var alreadyExistUserEmail = await userRepository.GetAsync(u => u.Email == userForCreationDTO.Email);
                if (alreadyExistUserEmail != null)
                throw new WebAppSystemException(400, $"Email {alreadyExistUserEmail.Email} already exist");

            var user = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));
            await userRepository.SaveChangesAsync();
            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User,bool>> expression)
        {
            var user = await userRepository.GetAsync(expression);
            if (user == null)
                throw new WebAppSystemException(404, "User not found");
            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression=null)
        {
            var users = userRepository.GetAll(expression);
            return mapper.Map<List<UserForViewDTO>>(await users.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<bool> DeleteAsnyc(int id)
        {
            var isDeleted = await userRepository.DeleteAsync(u=>u.Id==id);
            if (!isDeleted)
                throw new WebAppSystemException(404, "User not found");
            await userRepository.SaveChangesAsync();
            return true;
        }

        
        public async ValueTask<UserForViewDTO> UpdateAsnyc(int id, UserForUpdateDTO userForUpdateDTO)
        {
            var existUser = await userRepository.GetAsync(u=>u.Id==id);
            existUser.UpdatedAt = DateTime.UtcNow;

            existUser = userRepository.Update(mapper.Map(userForUpdateDTO,existUser));
            await userRepository.SaveChangesAsync();
            return mapper.Map<UserForViewDTO>(existUser);
        }
    }
}
