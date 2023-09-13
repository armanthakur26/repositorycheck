using imageupload.Data;
using imageupload.Models;
using imageupload.Repository.Irepository;

namespace imageupload.Repository
{
    public class Bikes:Repository<bikes>,Ibikes
    {
        private readonly Applicationdbcontext _context;
        public Bikes(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }
    }
}
