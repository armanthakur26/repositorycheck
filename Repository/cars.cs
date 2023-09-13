using imageupload.Data;
using imageupload.Repository.Irepository;

namespace imageupload.Repository
{
    public class cars:Repository<cars>,Icars
    {
        private readonly Applicationdbcontext _context;
        public cars(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }
    }
}
