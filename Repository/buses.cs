using imageupload.Data;
using imageupload.Repository.Irepository;

namespace imageupload.Repository
{
    public class buses:Repository<buses>,Ibuses
    {
        private readonly Applicationdbcontext _context;
        public buses(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }
    }
}
