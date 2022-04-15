namespace Users.Api.Services
{
    public interface IMessageService
    {
        void Enqueue(string message);
    }
}
