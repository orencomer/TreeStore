using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStore.Data.Interface;
using TreeStore.Data.Repositories;
using TreeStore.Models;

namespace TreeStore.Services
{
   
    public interface ICampaignService
    {
        IEnumerable<Campaign> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Campaign> GetCampaings();
        //List<Campaign> GetFeedbackValueByFeedbackId(long id);
        List<Campaign> GetCampaigns(string User, long id);
        Campaign GetCampaign(long id);
        //void FeedbackPost(IFormCollection collection, string filePath);
        //void FeedbackPostMail(string body, long id);
        void CreateCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        void DeleteCampaign(long id);
        int CountCampaign();
        void SaveCampaign();
    }

    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;
        private readonly IUnitOfWork unitOfWork;

        #region ICampaignService Members
        public CampaignService(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork)
        {
            this.campaignRepository = campaignRepository;
            this.unitOfWork = unitOfWork;
        }
        public int CountCampaign()
        {
            return campaignRepository.GetAll().Count();
        }

        public void CreateCampaign(Campaign campaign)
        {
            campaignRepository.Add(campaign);
        }

        public void DeleteCampaign(long id)
        {
            campaignRepository.Delete(c => c.Id == id);
        }

        public List<Campaign> GetCampaigns(string User, long id)
        {
            return campaignRepository.GetMany(c => c.CreatedBy == User && c.Id == id).ToList();
        }

        public IEnumerable<Campaign> GetCampaings()
        {
            var Campaigns = campaignRepository.GetAll();
            return Campaigns;
                 
        }

        public Campaign GetCampaign(long id)
        {
            var campaign = campaignRepository.GetById(id);
            return campaign;
        }

        public void SaveCampaign()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Campaign> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var searchedCampaign = campaignRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return searchedCampaign;
        }

        public void UpdateCampaign(Campaign campaign)
        {
            campaignRepository.Update(campaign);
        }
        #endregion
    }
}
