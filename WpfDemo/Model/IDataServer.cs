namespace WpfDemo
{
    public interface IDataServer
    {
        PM25Data GetData();
        void Refresh();
    }
}