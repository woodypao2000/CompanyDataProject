using SqlSugar;
namespace WebApi.modle
{
    public class CompanyData : Ibase
    {
        [SugarColumn(IsNullable =false)]
        public string ReportDate { get; set; }

        [SugarColumn(IsNullable = false)]
        public string DataYearMonth { get; set; }

        [SugarColumn(IsNullable = false)]
        public string CompanyName { get; set; }

        [SugarColumn(IsNullable = true)]
        public string Industry { get; set; }

        [SugarColumn(IsNullable = true)]
        public decimal MonthlyRevenue { get; set; }
        [SugarColumn(IsNullable = true)]
        public decimal PreviousMonthlyRevenue { get; set; }
        [SugarColumn(IsNullable = true)]

        public decimal LastYearMonthlyRevenue { get; set; }
        [SugarColumn(IsNullable = true)]
        public decimal MonthlyComparisonPercentage { get; set; }
        [SugarColumn(IsNullable = true)]
        public decimal LastYearComparisonPercentage { get; set; }
        [SugarColumn(IsNullable = true)]
        public decimal CumulativeRevenue { get; set; }
        [SugarColumn(IsNullable = true)]
        public decimal LastYearCumulativeRevenue { get; set; }

        [SugarColumn(IsNullable = true)]
        public decimal PreviousComparisonPercentage { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Notes { get;set; }
    }
}
