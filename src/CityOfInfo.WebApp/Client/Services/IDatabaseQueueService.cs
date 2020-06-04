using CityOfInfo.WebApp.Shared;
using System;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Services
{
    public interface IDatabaseQueueService
    {
        int Count { get; }

        event Func<Task> OnEnqueue;

        Database Dequeue();
        Task EnqueueAsync(Database database);
    }
}