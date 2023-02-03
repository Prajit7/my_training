using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.DataComponent
{
    public class newspage
    {

        private readonly NewsDesDataContext _context = new NewsDesDataContext();
        public void AddNewNews(newsinfo info)
        {
            _context.newsinfos.InsertOnSubmit(info);

        }
        public List<newsinfo> GetAllNews() => _context.newsinfos.ToList();

        public newsinfo FindNews(string des) => _context.newsinfos.FirstOrDefault((c) => c.description == des);
    }
}