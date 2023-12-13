﻿using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
    
    Task<IBaseResponse<bool>> DeleteProducts(int id);
    
    Task<IBaseResponse<ProductDBO>> Create(ProductDBO productDbo);
    
    Task<IBaseResponse<Product>> GetProduct(int id);

    Task<IBaseResponse<Product>> Edit(int id, ProductDBO productDbo);
}