using Microsoft.EntityFrameworkCore;
using ShoxShop.Dtos.Product;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Product;
public partial class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork,ILogger<ProductService> logger)
    {
        _logger=logger;
        _unitOfWork=unitOfWork;
    }
    public async ValueTask<Result<ProductModel>> ChangeVisiblityProduct(ulong ProductId, bool Visiblity)
    {
        try
        {
            var product =_unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id Product not found"
                };
            }
            product.Visiblity=Visiblity;
            var result= await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.RollbackAsync();
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="Error occured while updating product"
                };
            }
            return new(true)
            {
                Data=ToProductModel(result)
            };

        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<ProductModel>> CreateProduct(ulong SubCategoryId, ulong VendorId, CreateProductDto createProduct)
    {
        try
        {
            var category =_unitOfWork.CategoryRepository.GetById(SubCategoryId);
            if (category is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id SubCategory not found"
                };
            }
            Entities.Product newProduct= new()
            {
                Name=createProduct.Name!,
                Description=createProduct.Description!,
                Price=createProduct.Price,
                Quantity=createProduct.Quantity,
                SubCategoryId=SubCategoryId,
                CategoryId=category.CategoryId,
                VendorId=VendorId,
                Visiblity=category.Visiblity,
                Model=category.Model
            }; 

            var result = await _unitOfWork.ProductRepository.AddAsync(newProduct);
            await _unitOfWork.RollbackAsync();
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="Error occured while updating product"
                };
            }
            return new(true)
            {
                Data=ToProductModel(result)
            };

        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<ProductModel>> DeleteProduct(ulong VendorId, ulong ProductId)
    {
        try
        {
            var vendor =_unitOfWork.VendorRepository.GetById(VendorId);
            if (vendor is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id Vendor not found"
                };
            }
            var product = _unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id product not found"
                };
            }
            if (product.VendorId!=VendorId)
            {
                return new(false)
                {
                    ErrorMessage="This product Added by another Vendor "
                };
            }
            product.Delete=true;
            var result = await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.RollbackAsync();
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="Error occured while updating product"
                };
            }
            return new(true)
            {
                Data=ToProductModel(result)
            };

        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetAllInvisibleProduct(ushort Limit = 10, int Page = 1)
    {
        try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>!e.Visiblity);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductByCategoryId(ulong CategoryId, ushort Limit = 10, int Page = 1)
    {
        try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>!e.Visiblity&&e.CategoryId==CategoryId);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductBySubCategoryId(ulong SubCategoryId, ushort Limit = 10, int Page = 1)
    {
        try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>!e.Visiblity&&e.SubCategoryId==SubCategoryId);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }
    
    public async ValueTask<Result<List<ProductModel>>> GetAllProductsByCategoryId(ulong CategoryId, ushort Limit = 10, int Page = 1)
    {
    try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>!e.Visiblity&&e.CategoryId==CategoryId);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetAllProductsBySubCategoryId(ulong SubCategoryId, ushort Limit = 10, int Page = 1)
    {
    try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>e.Visiblity&&e.SubCategoryId==SubCategoryId);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetAllProductsByVendorId(ulong VendorId, ushort Limit = 10, int Page = 1)
    {
        try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>e.Visiblity&&e.VendorId==VendorId);
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<ProductModel>> GetProductInfoByProductId(ulong ProductId)
    {
        try
        {
            var result =  _unitOfWork.ProductRepository.GetById(ProductId);
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id product not found"
                };
            }
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToProductModel(result)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<ProductModel>>> SearchProducts(string SearchText, ushort Limit = 10, int Page = 1)
    {
        try
        {
        var query =  _unitOfWork
                    .ProductRepository
                    .GetEntities
                    .Where(e=>e.Visiblity&&(e.Name.Contains(SearchText)));
        var count=query.Count();
        var result =await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit).ToListAsync();
        var totalPage=  (int)Math.Ceiling(count/(double)Limit);
        return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=result.Select(ToProductModel).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(GetAllInvisibleProductByCategoryId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<ProductModel>> UpdateProduct(ulong VendorId,ulong ProductId, CreateProductDto createProduct)
    {
        try
        {
            var category =_unitOfWork.ProductRepository.GetById(ProductId);
            if (category is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id Product not found"
                };
            }
            var product= _unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id product not found"
                };
            }
            
                product.Name=createProduct.Name!;
                product.Description=createProduct.Description!;
                product.Price=createProduct.Price;
                product.Quantity=createProduct.Quantity;
                product.CategoryId=category.CategoryId;
                product.VendorId=VendorId;
                product.Visiblity=category.Visiblity;
                product.Model=category.Model;
             

            var result = await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.RollbackAsync();
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="Error occured while updating product"
                };
            }
            return new(true)
            {
                Data=ToProductModel(result)
            };

        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(ChangeVisiblityProduct)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }
}