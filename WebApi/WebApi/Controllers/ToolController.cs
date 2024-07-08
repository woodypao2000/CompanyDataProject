using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using WebApi.modle;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        public ISqlSugarClient _db;

        public ToolController(ISqlSugarClient db) { _db = db; }

        [HttpGet]

        public ActionResult<List<CompanyData>> GetEntities()
        {

            string res = "";
          //  return _db.Queryable<CompanyData>().Where(it => it.CompanyCode == "1101").ToList();
            return _db.Queryable<CompanyData>().ToList();

        }

        [HttpPost]
        public ActionResult PostCompanyData(CompanyData companyData)
        {
            try
            {
                string sql = "INSERT INTO CompanyData  VALUES (@ReportDate,@DataYearMonth,@CompanyCode, @CompanyName, @Industry,@MonthlyRevenue,@PreviousMonthlyRevenue,@LastYearMonthlyRevenue,@MonthlyComparisonPercentage,@LastYearComparisonPercentage,@CumulativeRevenue,@LastYearCumulativeRevenue,@PreviousComparisonPercentage,@Notes)";
                var parameters = new SugarParameter[]
                {
                          new SugarParameter("@ReportDate",companyData.ReportDate),
                          new SugarParameter("@DataYearMonth",companyData.DataYearMonth),
                          new SugarParameter("@CompanyCode",companyData.CompanyCode),          
                          new SugarParameter("@CompanyName", companyData.CompanyName),
                          new SugarParameter("@Industry", companyData.Industry),
                          new SugarParameter("@MonthlyRevenue",companyData.MonthlyRevenue),
                          new SugarParameter("@PreviousMonthlyRevenue", companyData.PreviousMonthlyRevenue),
                          new SugarParameter("@MonthlyComparisonPercentage", companyData.MonthlyComparisonPercentage),
                          new SugarParameter("@LastYearComparisonPercentage", companyData.LastYearComparisonPercentage),
                          new SugarParameter("@CumulativeRevenue", companyData.CumulativeRevenue),
                          new SugarParameter("@LastYearMonthlyRevenue", companyData.LastYearMonthlyRevenue),
                          new SugarParameter("@LastYearCumulativeRevenue", companyData.LastYearCumulativeRevenue),
                          new SugarParameter("@PreviousComparisonPercentage", companyData.PreviousComparisonPercentage),
                          new SugarParameter("@Notes", companyData.Notes),


                };

                int rowsAffected = _db.Ado.ExecuteCommand(sql, parameters);

                return Ok($"Inserted {rowsAffected} rows.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
