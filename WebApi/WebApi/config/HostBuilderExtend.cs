using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using SqlSugar;

namespace WebApi.config
{   /// <summary>
    /// 擴展類
    /// </summary>
    public static class HostBuilderExtend
    {
        public static void Register(this WebApplicationBuilder app )
        {
            app.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            app.Host.ConfigureContainer<ContainerBuilder>(builder => {
                #region 註冊 
                builder.Register<ISqlSugarClient>(content => 
                {
                    SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                    {

                        ConnectionString = "Server=DESKTOP-MVQ0JQU\\SQLEXPRESS;Database=db01;Integrated Security=True",
                        DbType =DbType.SqlServer,
                        IsAutoCloseConnection=true
                    });
                    db.Aop.OnLogExecuted = (sql, par) =>
                    {
                        Console.WriteLine("sql:"+sql+DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                    };
                    return db;
                 });
                #endregion
                //builder.RegisterModule(new AutofacModuleRegister());
            });
        }
    }
}
