
namespace _09_01_InterimKantoor
{
    public interface IUnitOfWork
    {
        IRepository<Job> JobRepository { get; }
        IRepository<Klant> KlantRepository { get; }
        IRepository<KlantJob> KlantJobRepository { get; }
        public void SaveChanges();
    }
}
