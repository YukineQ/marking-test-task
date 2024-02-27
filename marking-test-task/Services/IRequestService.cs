namespace marking_test_task.Services
{
    public interface IRequestService
    {
        Responce<TResult?> Get<TResult>(string url);

        Task<Responce<TResult>> PostAsync<TRequest, TResult>();
    }
}