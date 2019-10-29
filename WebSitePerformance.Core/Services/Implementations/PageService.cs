using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Core.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _repository;
        private readonly IMapper _mapper;

        public PageService(IPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //
        public async Task<PageStatistic> Add(PageStatistic entity)
        {
            return _mapper.Map<PageStatistic>(await _repository.Add(_mapper.Map<PageStatisticDal>(entity)));
        }

        public async Task Delete(PageStatistic entity)
        {
            await _repository.Delete(_mapper.Map<PageStatisticDal>(entity));
        }

        public async Task<IEnumerable<PageStatistic>> GetAll()
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetAll());
        }

        public async Task<PageStatistic> GetById(int Id)
        {
            return _mapper.Map<PageStatistic>(await _repository.GetById(Id));
        }

        public IQueryable<PageStatistic> GetItems()
        {
            return _mapper.Map<IQueryable<PageStatistic>>(_repository.GetItems());
        }

        //
        public async Task<IEnumerable<PageStatistic>> GetPagesBySiteUrl(string siteUrl)
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetPagesBySiteUrl(siteUrl)).OrderByDescending(x => x.TestDate);
        }

        //
        public async Task<IEnumerable<PageStatistic>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl)
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetPagesBySiteUrlAndPageUrl(siteUrl, pageUrl)).OrderByDescending(x => x.PageUrl).OrderBy(p => p.TestDate);
        }

        //
        public async Task<IEnumerable<PageStatistic>> GetPagesByTestId(string testId)
        {
            var result = await _repository.GetPagesByTestId(testId);
            return _mapper.Map<IEnumerable<PageStatistic>>(result);
        }

        public async Task<PageStatistic> Update(PageStatistic entity)
        {
            return _mapper.Map<PageStatistic>(await _repository.Update(_mapper.Map<PageStatisticDal>(entity)));
        }
    }
}
