using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Repositories;
using ApahidaTheatherWeb.Models;

namespace ApahidaTheatherWeb.BusinessLogic
{
    public class PlayService
    {
        public readonly UnitOfWork _unitOfWork;

        public PlayService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async void Create(Play play)
        {
            await _unitOfWork.Plays.Add(play);
        }
        public async Task<IEnumerable<Play>> GetAll()
        {
            return await _unitOfWork.Plays.GetAll();
        }

        public async Task<Play> Get(int id)
        {
            return await _unitOfWork.Plays.Get(id);
        }

        public async void Update(Play play)
        {
            _unitOfWork.Plays.Update(play);
        }

        public async void Delete(Play play)
        {
            _unitOfWork.Plays.Delete(play);
        }
        public bool Exists(Play play)
        {
            if (_unitOfWork.Plays.GetPlay(play.Title, play.Director, play.Premiere) != null) return true;
            return false;
        }
    }
}
