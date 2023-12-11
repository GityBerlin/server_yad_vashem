using API.DAL_Repository;
using API.DAL_Repository.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.BLL_Service
{
    public class TimeService : ITimeService
    {
        private readonly DAL_Repository.ITimeRepository _ITimeDAl;

        public TimeService(DAL_Repository.ITimeRepository ITimeDAl)
        {
            _ITimeDAl = ITimeDAl;
        }
        public TimeService()
        {
        }
        public List<Time>  GetAllJson()
        {
            return _ITimeDAl.GetAllJson();
        }
        public List<Time> GetDataByTimeOfDay(int timeOfDay)
        {
            var data = _ITimeDAl.GetAllJson();
            switch (timeOfDay)
            {
                case 0:
                    data = data.Where(d =>
                     Int32.Parse(d.startTime.Split(':')[0]) >= 8 &&
                        Int32.Parse(d.startTime.Split(':')[0]) < 12).ToList();
                    break;
                case 1:
                    data = data.Where(d =>
                     Int32.Parse(d.startTime.Split(':')[0]) >= 12 &&
                        Int32.Parse(d.startTime.Split(':')[0]) < 15).ToList();
                    break;
                case 2:
                    data = data.Where(d =>
                     Int32.Parse(d.startTime.Split(':')[0]) >= 15).ToList();
                      
                    break;
            }
            return data;

        }
        public int SumTicket()
        {
            int sum = 0;
            var data = _ITimeDAl.GetAllJson();
            data.ForEach(x => sum += x.availablePlaces);
            return sum;
        }
        public Time UpdateaVailablePlaces(Time t)
        {
           Time b= _ITimeDAl.UpdateaVailablePlaces(t);
            return b;
        }
    }
}
