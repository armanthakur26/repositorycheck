using imageupload.Data;
using imageupload.Repository.Irepository;

namespace imageupload.Repository
{
    public class Unitofwork : Iunitofwork
    {
        private readonly Applicationdbcontext _context;
        public Unitofwork(Applicationdbcontext context)
        {
            _context = context;
            Cars = new cars(context);
            Bikes = new Bikes(context);
            Buses = new buses(context);

        }

        public Icars Cars { get; private set; }

        public Ibikes Bikes { get; private set; }

        public Ibuses Buses { get; private set; }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}