using CohortHomeworkWeek2.Repositories;

namespace CohortHomeworkWeek2.Extensions
{
    //Burada servisleri genişletmek için bir sınıf oluşturduk. 
    public static class ServiceExtensions
    {
        //Burada AddRepositories adında bir metot oluşturduk ve bu metot IServiceCollection tipinde bir parametre alıyor.
        public static void AddRepositories(this IServiceCollection services)
        {
            //Burada IProductRepository arayüzünü ProductRepository sınıfına bağladık.
            services.AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}
