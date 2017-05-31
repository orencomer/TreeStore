using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStore.Data.Interface;
using TreeStore.Models;

namespace TreeStore.Data.Repositories
{
    public class CampaignRepository : RepositoryBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Campaign> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            string localSearch = search.Trim();
            var searchWords = localSearch.Split(' ');
            var query = this.DbContext.Campaigns.AsQueryable();

            foreach(string sSearch in searchWords)
            {
                if(sSearch != null && sSearch != "")
                {
                    DateTime dDate;
                    bool dateParsed = false;
                    if (DateTime.TryParse(sSearch, out dDate))
                    {
                        dDate = DateTime.Parse(sSearch);
                        dateParsed = true;
                    }
                    query = query.Where(c=> c.Name.Contains(sSearch) || c.Slogan.Contains(sSearch) || (dateParsed == true ? c.StartedDate == dDate : false) || (dateParsed == true ? c.EndDate == dDate : false));
                }
            }
            var allCampaigns = query;

            IEnumerable<Campaign> filteredCampaigns = allCampaigns;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.Name);
                        break;
                    case 1:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.Slogan);
                        break;
                    case 2:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.StartedDate);
                        break;
                    case 3:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.EndDate);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.Name);
                        break;
                    case 1:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.Slogan);
                        break;
                    case 2:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.StartedDate);
                        break;
                    case 3:
                        filteredCampaigns = filteredCampaigns.OrderBy(c => c.EndDate);
                        break;
                    default:
                        break;
                }
            }

            var displayedCampaigns = filteredCampaigns.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedCampaigns = displayedCampaigns.Take(displayLength);
            }
            totalRecords = allCampaigns.Count();
            totalDisplayRecords = filteredCampaigns.Count();
            return displayedCampaigns.ToList();
        }
    }
    public interface ICampaignRepository : IRepository<Campaign>
    {
        IEnumerable<Campaign> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}






