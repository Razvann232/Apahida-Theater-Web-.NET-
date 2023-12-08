using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Repositories;
using ApahidaTheatherWeb.Models;

namespace ApahidaTheatherWeb.BusinessLogic
{
    public class UserService
    {
        public readonly UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAll();
        }

        public async Task<User> Get(int id)
        {
            return await _unitOfWork.Users.Get(id);
        }

        public async void Create(User user)
        {
            await _unitOfWork.Users.Add(user);
        }

        public async void Update(User user)
        {
            _unitOfWork.Users.Update(user);
        }

        public async void Delete(User user)
        {
            _unitOfWork.Users.Delete(user);
        }

        public bool isDuplicate(User user)
        {
            return (_unitOfWork.Users.Get(user.Id) == null) ? false : true;
        }

        public bool Exists(User user) {
            if (_unitOfWork.Users.GetUser(user.Username) != null) return true;
            return false;
        }
    }
}
