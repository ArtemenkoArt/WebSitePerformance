using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Core.Services.Implementations
{
    public class SiteMapServices
    {
        private readonly IPageDataRepository _repository;
        private readonly IMapper _mapper;

        public SiteMapServices(IPageDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SiteStatisticViewModel> Add(SiteStatisticViewModel viewModel)
        {
            for (var i = 0; i > viewModel.PageList.Count; i++)
            {
                viewModel.PageList[i] = _mapper.Map<PageStatistic>(
                                                    await _repository.Add(
                                                        _mapper.Map<PageStatisticDal>(viewModel.PageList[i])));
            }
            return viewModel;
        }

        public async Task Delete(PageStatistic entity)
        {
            await _repository.Delete(_mapper.Map<PageStatisticDal>(entity));
        }

        public async Task<IEnumerable<PageStatistic>> GetPagesBySiteUrl(string siteUrl)
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetPagesBySiteUrl(siteUrl));
        }

        public async Task<IEnumerable<PageStatistic>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl)
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetPagesBySiteUrlAndPageUrl(siteUrl, pageUrl));
        }

        public async Task<IEnumerable<PageStatistic>> GetPagesBySiteUrlAndTestDate(string siteUrl, DateTime dateTime)
        {
            return _mapper.Map<IEnumerable<PageStatistic>>(await _repository.GetPagesBySiteUrlAndTestDate(siteUrl, dateTime));
        }

        public async Task<PageStatistic> Update(PageStatistic entity)
        {
            return _mapper.Map<PageStatistic>(await _repository.Update(_mapper.Map<PageStatisticDal>(entity)));
        }
    }
}
