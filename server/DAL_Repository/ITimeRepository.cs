
using System.Collections.Generic;
using API.DAL_Repository.Model;

namespace API.DAL_Repository
{
    public interface ITimeRepository
    {
        int getAll();
        List<Time> GetAllJson();
        Time UpdateaVailablePlaces(Time t);
    }
}