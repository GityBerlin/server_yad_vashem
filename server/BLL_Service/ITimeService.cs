using API.DAL_Repository.Model;
using System.Collections.Generic;

namespace API.BLL_Service
{
    public interface ITimeService
    {
        List<Time> GetAllJson();
        List<Time> GetDataByTimeOfDay(int timeOfDay);
        int SumTicket();
        Time UpdateaVailablePlaces(Time t);
       



    }
}