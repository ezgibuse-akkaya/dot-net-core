using System.Threading.Tasks;

namespace AuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Geriye task dönecek. Task asenkrondan void'e karşılık geliyor.
        Task CommmitAsync();

        //Bir tane de asenkron olmayanlar için metot oluşturuldu.
        void Commit();
    }
}
