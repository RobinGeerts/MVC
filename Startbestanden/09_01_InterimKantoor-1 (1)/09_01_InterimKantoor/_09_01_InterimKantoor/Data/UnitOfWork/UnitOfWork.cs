

namespace _09_01_InterimKantoor
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InterimKantoorContext _context;

        public UnitOfWork(InterimKantoorContext context)
        {
            _context = context;

            JobRepository = new Repository<Job>(_context);
            KlantRepository = new Repository<Klant>(_context);
            KlantJobRepository = new Repository<KlantJob>(_context);
        }

        public IRepository<Job> JobRepository { get; }
        public IRepository<Klant> KlantRepository { get; }
        public IRepository<KlantJob> KlantJobRepository { get; }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
}
}
