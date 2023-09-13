namespace imageupload.Repository.Irepository
{
    public interface Iunitofwork
    {
        Icars Cars { get; }
        Ibikes Bikes { get; }
        Ibuses Buses { get; }

        void save();
    }
}
