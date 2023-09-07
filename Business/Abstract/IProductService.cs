﻿using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> ListNewProduct();
        List<Product> ListHighPriceProduct();
        List<Product> ListLowPriceProduct();
        List<Product> ListProductWith();
        List<Product> ListLowStockProduct();
        List<Product> ListHighStockProduct();
        List<Product> ListCategoryProduct(int id);
        List<Product> ListBrandProduct(int id);
        List<Product> ListMainCategoryProduct(int id);
        List<Product> ProductPage(int id);
        List<Product> ListElectronicProducts();
        List<Product> ListClothingProducts();
        List<Product> MainCategoryProducts(int id);
        List<Product> ListMostViewProduct();
        List<Product> ListCommentProduct();
        List<Product> ListSimilarCategoryProduct(int id);
        List<Product> ListBrandProducts(int id);
    }
}
