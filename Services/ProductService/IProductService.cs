using ShoxShop.Dtos.Product;
using ShoxShop.Model;

namespace ShoxShop.Services.Product;
public interface IProductService
{
    ValueTask<Result<ProductModel>> CreateProduct(
        ulong CategoryId,
        ulong SubCategoryId,
        ulong VendorId,
        CreateProductDto createProduct);
    ValueTask<Result<ProductModel>> UpdateProduct(ulong VendorId,CreateProductDto createProduct);
    ValueTask<Result<ProductModel>> DeleteProduct(ulong VendorId,ulong ProductId);
    ValueTask<Result<List<ProductModel>>> ChangeVisiblityProduct(ulong ProductId,bool Visiblity);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductByCategoryId(ulong CategoryId,ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductBySubCategoryId(ulong SubCategoryId,ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProduct(ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> GetProductInfoById(ulong ProductId);    
    ValueTask<Result<List<ProductModel>>> GetAllProductsByCategoryId(ulong CategoryId,ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllProductsByVendorId(ulong VendorId,ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllProductsBySubCategoryId(ulong SubCategoryId,ushort Limit=10,uint Page=1);
    ValueTask<Result<List<ProductModel>>> SearchProducts(string SearchText);
}