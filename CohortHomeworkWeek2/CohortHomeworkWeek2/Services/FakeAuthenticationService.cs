namespace CohortHomeworkWeek2.Services
{

    //Burada amaç Auth işlemlerini yapacak bir servis oluşturmak.
    public interface IAuthService
        {
            bool Authenticate(string username, string password);
        }

    //Burada FakeAuthService sınıfı IAuthService arayüzünden türetilmiştir ve bu sınıfın Authenticate metodu override edilmiştir.
    //Amaç sahte bir kullanıcı giriş sistemi oluşturmak.
    public class FakeAuthService : IAuthService
        {
            public bool Authenticate(string username, string password)
            {
                return username == "admin" && password == "1234";
            }
        }
    }
