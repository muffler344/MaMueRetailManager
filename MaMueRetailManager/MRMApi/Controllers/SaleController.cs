using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRMDataManager.Library.DataAccess;
using MRMDataManager.Library.Models;

namespace MRMApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleData _saleData;
        public SaleController(ISaleData saleData)
        {
            _saleData = saleData;
        }

        [HttpPost]
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _saleData.SaveSale(sale, userId);
        }

        [HttpGet]
        [Route("GetSalesReport")]
        [Authorize(Roles = "Admin,Manager")]
        public List<SaleReportModel> GetSaleReport()
        {
            return _saleData.GetSaleReport();
        }
    }
}
