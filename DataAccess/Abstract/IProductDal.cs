﻿using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> ListProductWithCategory();
        List<Product> ListNewProduct();
        List<Product> ListHighPriceProduct();
        List<Product> ListLowPriceProduct();
        List<Product> ListLowStockProduct();
        List<Product> ListHighStockProduct();
    }
}