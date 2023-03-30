using FullSearchSample.Services;
using FullSearchSample.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FullSearchSample
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => {

                    #region Configure EF DBContext Service (CardStorageService Database)

                    services.AddDbContext<DocumentDbContext>(options =>
                    {
                        options.UseSqlServer(@"data source=DESKTOP-DEE7E1K\SQLEXPRESS;initial catalog=DocumentsDatabase;User Id=DocumentsDatabaseUser;Password=12345;MultipleActiveResultSets=True;App=EntityFramework");
                    });

                    #endregion

                    #region Configure Repositories

                    services.AddTransient<IDocumentRepository, DocumentRepository>();

                    #endregion


                })
                .Build();

            // Сохраним документы в БД
            host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();


        }
    }
}