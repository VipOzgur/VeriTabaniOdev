namespace VtOdev.Models
{
    public  class DbLogger : ILoggerr
    {
        private readonly DbodevContext _context;

        public DbLogger()
        {
            _context = new DbodevContext();
        }

        public void Log(string message)
        {
           dbLog dblog = new dbLog();
        dblog.Message = message;
           _context.Add(dblog);
            _context.SaveChanges();
        }
    }
}
