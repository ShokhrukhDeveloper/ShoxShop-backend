using ShoxShop.Dtos.Product;
using ShoxShop.Model;

namespace ShoxShop.Services.Product;
public interface IProductService
{
    ValueTask<Result<ProductModel>> CreateProduct(
        ulong SubCategoryId,
        ulong VendorId,
        CreateProductDto createProduct);
    ValueTask<Result<ProductModel>> UpdateProduct(ulong VendorId,ulong ProductId,UpdateProductDto dto);
    ValueTask<Result<ProductModel>> DeleteProduct(ulong VendorId,ulong ProductId);
    ValueTask<Result<ProductInfoModel>> ProductInfo(ulong ProductId);
    ValueTask<Result<ProductModel>> ChangeVisiblityProduct(ulong VendorId, ulong ProductId,bool Visiblity);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductByCategoryId(ulong CategoryId,ushort Limit=10,int Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProductBySubCategoryId(ulong SubCategoryId,ushort Limit=10,int Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllInvisibleProduct(ushort Limit=10,int Page=1);
    ValueTask<Result<ProductModel>> GetProductInfoByProductId(ulong ProductId);    
    ValueTask<Result<List<ProductModel>>> GetAllProductsByCategoryId(ulong CategoryId,ushort Limit=10,int Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllProductsByVendorId(ulong VendorId,ushort Limit=10,int Page=1);
    ValueTask<Result<List<ProductModel>>> GetAllProductsBySubCategoryId(ulong SubCategoryId,ushort Limit=10,int Page=1);
    ValueTask<Result<List<ProductModel>>> SearchProducts(string SearchText,ushort Limit = 10, int Page = 1);
}