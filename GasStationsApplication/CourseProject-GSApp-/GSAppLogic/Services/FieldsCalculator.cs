using GSAppLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.Services
{
    public class FieldsCalculator
    {
        public GasStationDTO CalculateDistance(GasStationDTO gsDTO)
        {
            var geolocation = Geolocation.GetGeolocation();
            var currGS = UnitOfWork.gasStationsRepos.Get(gsDTO.Name);
            var length = geolocation.CalculateLengthToGS(currGS.Lat, currGS.Lng);
            currGS.distanceLength = length;
            gsDTO.distanceLength = length;
            return gsDTO;
        }

        public GasStationDTO CalculateAverageStarsNumber(GasStationDTO gsDTO)
        {
            var feedbacks = UnitOfWork.feedBackRepos.GetAll().Where(x => x.GasStationName == gsDTO.Name);
            var gs = UnitOfWork.gasStationsRepos.Get(gsDTO.Name);
            var averageStars = feedbacks.Count() == 0 ? 0 : (int)Math.Round((double)(feedbacks.Select(x => x.Stars).Sum() / feedbacks.Count()));
            gs.AverageStars = averageStars;
            UnitOfWork.gasStationsRepos.Update(gs);
            gsDTO.AverageStars = averageStars;
            return gsDTO;
        }

        public GasStationDTO CalculateFeedbacksNumber(GasStationDTO gsDTO)
        {
            var feedbacks = UnitOfWork.feedBackRepos.GetAll().Where(x => x.GasStationName == gsDTO.Name);
            var gs = UnitOfWork.gasStationsRepos.Get(gsDTO.Name);
            var feedbacksNumber = feedbacks.Count();
            gs.FeedbacksNumber = feedbacksNumber;
            UnitOfWork.gasStationsRepos.Update(gs);
            gsDTO.FeedbacksNumber = feedbacksNumber;
            return gsDTO;
        }
    }
}
