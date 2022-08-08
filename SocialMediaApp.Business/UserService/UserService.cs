using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data.Dtoes;
using SocialMediaApp.Data.Models;
using SocialMediaApp.DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Business.UserService
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto Get(int id)
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.PostgreSqlRepository<UserModel>().GetById(id);
                var dtoResult = _mapper.Map<UserDto>(data);
                return dtoResult;
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.PostgreSqlRepository<UserModel>().GetAll().Include(x => x.Addresses).ToList();
                var dtoResult = _mapper.Map<IEnumerable<UserDto>>(data);
                return dtoResult;
            }
        }

        public void Add(UserDto model)
        {
            using (var uow = new UnitofWork())
            {
                var dtoResult = _mapper.Map<UserModel>(model);
                uow.PostgreSqlRepository<UserModel>().Add(dtoResult);
                uow.SaveChanges();
            }
        }

        public void Delete(UserDto model)
        {
            using (var uow = new UnitofWork())
            {
                var dtoResult = _mapper.Map<UserModel>(model);
                uow.PostgreSqlRepository<UserModel>().Delete(dtoResult);
                uow.SaveChanges();
            }
        }

        public void Update(UserDto model)
        {
            using (var uow = new UnitofWork())
            {
                var dtoResult = _mapper.Map<UserModel>(model);
                uow.PostgreSqlRepository<UserModel>().Update(dtoResult);
                uow.SaveChanges();
            }
        }
    }
}
