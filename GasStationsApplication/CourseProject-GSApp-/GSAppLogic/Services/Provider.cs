using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using GSAppLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.Services
{
    public class Provider
    {
        private static Provider provider;

        private Provider() { }

        public static Provider GetProvider()
        {
            return provider == null ? new Provider() : provider;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(UnitOfWork.userRepository.GetAll());
        }

        public IEnumerable<CompanyDTO> GetAllCompanies()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Company, CompanyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Company>, List<CompanyDTO>>(UnitOfWork.companyRepos.GetAll());
        }

        public IEnumerable<GasStationDTO> GetAllGS()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GasStation, GasStationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GasStation>, List<GasStationDTO>>(UnitOfWork.gasStationsRepos.GetAll());
        }

        public IEnumerable<FeedbackDTO> GetAllFeedbacks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Feedback, FeedbackDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Feedback>, List<FeedbackDTO>>(UnitOfWork.feedBackRepos.GetAll());
        }

        public IEnumerable<FuelTypeDTO> GetAllFuelTypes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FuelType, FuelTypeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FuelType>, List<FuelTypeDTO>>(UnitOfWork.fuelTypesRepos.GetAll());
        }

        public UserDTO SaveUser(UserDTO user)
        {
            UnitOfWork.userRepository.Save(new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });
            return user;
        }

        public FeedbackDTO SaveFeedback(FeedbackDTO feedback)
        {
            UnitOfWork.feedBackRepos.Save(new Feedback()
            {
                Name = feedback.Name,
                Content = feedback.Content,
                GasStationName = feedback.GasStationName,
                Stars = feedback.Stars,
                UserName = feedback.UserName
            });
            return feedback;
        }

        private Feedback GetCurrentFeedback(FeedbackDTO feedback)
        {
            return UnitOfWork.feedBackRepos.GetAll().FirstOrDefault(x => x.GasStationName == feedback.GasStationName && x.UserName == feedback.UserName);
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            var currentFB = GetCurrentFeedback(feedback);
            currentFB.Content = feedback.Content;
            currentFB.Stars = feedback.Stars;
            UnitOfWork.feedBackRepos.Update(currentFB);
            return feedback;
        }

        public FeedbackDTO RemoveFeedback(FeedbackDTO feedback)
        {
            UnitOfWork.feedBackRepos.Remove(GetCurrentFeedback(feedback));
            return feedback;
        }
    }
}
