using SqlSugar;

namespace WebApi.modle
{
    public class Ibase {

        [SugarColumn(IsPrimaryKey =true ,IsIdentity =true)]

        public string CompanyCode { get; set; }
    }
}
