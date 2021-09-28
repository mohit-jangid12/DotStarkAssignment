using DotStarkTest.Core.ViewModel;
using DotStarkTest.Data.EntityModel;
using DotStarkTest.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotStarkTest.Core.Services
{
    public class ProductServices
    {
        private Repository<Products> _proRepo;
        public ProductServices(IUnitOfWork unitOfWork)
        {
            _proRepo = unitOfWork.Repository<Products>();
        }

        public ProductVM fillObj(Products x)
        {
            var model = new ProductVM();
            try
            {
                model.ID = x.ID;
                model.Is_Active = x.Is_Active;
                model.ProductID = x.ProductID;
                model.ProductName = x.ProductName;
                model.StockAvailable = x.StockAvailable;
                model.Created_At = x.Created_At;
                model.Updated_At = x.Updated_At;
            }
            catch (Exception)
            {
            }
            return model;
        }

        public List<ProductVM> GetAll()
        {
            var result = new List<ProductVM>();
            try
            {
                var query = _proRepo.Table.Where(x => !x.Is_Delete);

                foreach (var item in query)
                {
                    try
                    {
                        var model = fillObj(item);
                        result.Add(model);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public ProductVM GetByID(long ID)
        {
            var model = new ProductVM();
            try
            {
                var entity = _proRepo.GetById(ID);
                if (entity != null)
                    model = fillObj(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public bool GetAvailableProducts(string ID, long stockQty)
        {
            var result = false;
            try
            {
                var query = _proRepo.Table.Where(x => !x.Is_Delete && x.ProductID == ID && x.StockAvailable > stockQty).FirstOrDefault();
                if (query != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Save(ProductVM model)
        {
            var returnFlag = false;
            try
            {
                var entity = _proRepo.GetById(model.ID);
                entity = entity ?? new Products();

                entity.ProductName = model.ProductName;
                entity.StockAvailable = model.StockAvailable;

                if (model.ID > 0)
                {
                    entity.Updated_At = DateTime.UtcNow;
                    
                    _proRepo.Update(entity);
                }
                else
                {
                    entity.Is_Active = true;
                    entity.ProductID = Convert.ToString(Guid.NewGuid()).ToUpper();
                    entity.Created_At = DateTime.UtcNow;
                    entity.Updated_At = DateTime.UtcNow;
                    _proRepo.Insert(entity);
                }
                returnFlag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnFlag;
        }
    }
}
