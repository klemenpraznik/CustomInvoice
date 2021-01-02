using CustomInvoice.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomInvoice.WebApp.ViewModels
{
    public class Stats
    {
        public int TotalProducts { get; set; }
        public int TotalServices { get; set; }
        public int NumberOfClients { get; set; }
        public int NumberOfDocuments { get; set; }

        public List<Article> BestSellingArticles { get; set; }
        public List<ClientTypeCount> ClientTypeCount { get; set; }
        public List<ClientTypeCount> ClientTypeCountByDocument { get; set; }
    }
}
