using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Domain.Utils;
using Bit.Synchronizer.Domain.Common.Constants;
using Bit.Synchronizer.Domain.Common.Dto;
using Bit.Synchronizer.Domain.Common.Entities;
using Bit.Synchronizer.Domain.Common.Interfaces.Repositories;
using Bit.Synchronizer.Domain.Common.QuerysMapper;
using Bit.Synchronizer.Infrastructure.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Infrastructure.Persistence.Repositories
{
    public class LicenceRepository : ILicenceRepository
    {
        private readonly IMongoContext _context;
        protected IMongoCollection<Licence> _licenceCollection;

        public LicenceRepository(IMongoContext context)
        {
            _context = context;
            _licenceCollection = _context.GetCollection<Licence>(PersistenceConstants.LICENCE);            
        }

        /// <summary>
        /// Obtener las licencias disponibles y sincronizadas
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PagedResult<LicenceDto>> GetByAllAsync(PagedQuery query)
        {
            var result = new List<LicenceDto>();

            var skiCustom = PaginatorUtils.fromSkipToPage(query.Page, query.Results);

            var filterActive = !string.IsNullOrEmpty(query.Filter);

            var resultTotal = (from c in _licenceCollection.AsQueryable().AsEnumerable()
                               where ((c.Name.ToLower().Contains((query.Filter ?? ""))
                               || c.FriendyName.ToLower().Contains(query.Filter ?? "")) && filterActive) || !filterActive
                               && !c.IsDeleted
                               orderby c.Name ascending
                               select new LicenceDto()
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   CatalogName = c.CatalogName,
                                   FriendyName=c.FriendyName,
                                   BillingType=c.BillingType,
                                   SupportedBillingCycles=c.SupportedBillingCycles,
                                   CatalogItemId=c.CatalogItemId,
                                   Cost=c.Cost,
                                   CreatedAt=c.CreatedAt,
                                   IsTrial=c.IsTrial,
                                   MaximumQuantity=c.MaximumQuantity,
                                   MinimumQuantity=c.MinimumQuantity,
                                   ProductId=c.ProductId,
                                   TermDuration=c.TermDuration,
                                   UpdatedAt= c.UpdatedAt,
                                   ProductDescription = c.ProductDescription,
                                   SkuDescription=c.SkuDescription,
                                   SkuId=c.SkuId,
                                   IsAutoRenewable= c.IsAutoRenewable
                               });

            result = resultTotal?.Skip(skiCustom).Take(query.Results).ToList();

            if (!string.IsNullOrEmpty(query.SortOrder) && !string.IsNullOrEmpty(query.OrderBy))
            {
                result = ListUtils.OrderByCustom<LicenceDto>(resultTotal, query.OrderBy, query.SortOrder)
                .Skip(skiCustom).Take(query.Results).ToList();
            }

            return await Task.FromResult(new PagedResult<LicenceDto>(result, query.Page, query.Results, resultTotal.Count()));
        }

        /// <summary>
        /// Obtener licencia por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Licence> GetByIdAsync(Guid Id)
        {
            var entity = await _licenceCollection.FindAsync(x => x.Id.Equals(Id) && !x.IsDeleted);
            return entity.FirstOrDefault();
        }

        /// <summary>
        /// Actualiza información de licencias o inserta en caso de ser nuevo en base al producto y al sku
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> syncronizedAll(IEnumerable<Licence> list)
        {
            foreach (var data in list)
            {
                var update = Builders<Licence>.Update
                    .Set(_ => _.UpdatedAt, DateTime.UtcNow)
                    .Set(_ => _.Name, data.Name)
                    .Set(_ => _.IsTrial, data.IsTrial)
                    .Set(_ => _.MaximumQuantity, data.MaximumQuantity)
                    .Set(_ => _.MinimumQuantity, data.MinimumQuantity)
                    .Set(_ => _.ProductDescription, data.ProductDescription)
                    .Set(_ => _.TermDuration, data.TermDuration)
                    .Set(_ => _.Cost, data.Cost)
                    .Set(_ => _.BillingType, data.BillingType)
                    .Set(_ => _.SupportedBillingCycles, data.SupportedBillingCycles)
                    .Set(_ => _.IsDeleted, false);
                var entity = await _licenceCollection.FindOneAndUpdateAsync(x => x.ProductId == data.ProductId && x.SkuId == data.SkuId, update);
                if (entity == null)
                {
                    await _licenceCollection.InsertOneAsync(data);
                }
            }
            

            /**if (list.FirstOrDefault()!=null) {
                
                var dataFilter = list.FirstOrDefault().ProductId;

                var licences = await _licenceCollection.Find(_ => _.ProductId == dataFilter).ToListAsync();

                var result = licences.Except(list);

                foreach (var data in result)
                {
                    var update = Builders<Licence>.Update
                        .Set(_ => _.UpdatedAt, DateTime.UtcNow)
                        .Set(_ => _.IsDeleted, true);
                    var entity = await _licenceCollection.FindOneAndUpdateAsync(x => x.ProductId == data.ProductId && x.SkuId == data.SkuId, update);
                }
            }  **/         

            return true;
        }

        public async Task<bool> syncronizedOne(Licence licence)
        {
            var update = Builders<Licence>.Update
                    .Set(_ => _.UpdatedAt, DateTime.UtcNow)
                    .Set(_ => _.Name, licence.Name)
                    .Set(_ => _.IsTrial, licence.IsTrial)
                    .Set(_ => _.MaximumQuantity, licence.MaximumQuantity)
                    .Set(_ => _.MinimumQuantity, licence.MinimumQuantity)
                    .Set(_ => _.ProductDescription, licence.ProductDescription)
                    .Set(_ => _.TermDuration, licence.TermDuration)
                    .Set(_ => _.Cost, licence.Cost)
                    .Set(_ => _.BillingType, licence.BillingType)
                    .Set(_ => _.SupportedBillingCycles, licence.SupportedBillingCycles);
            var entity = await _licenceCollection.FindOneAndUpdateAsync(x => x.ProductId == licence.ProductId && x.SkuId == licence.SkuId, update);
            if (entity == null)
            {
                await _licenceCollection.InsertOneAsync(licence);
            }
            return true;
        }
    }
}
