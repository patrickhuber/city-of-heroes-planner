using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Services
{
    public class DatabaseQueueService : IDatabaseQueueService
    {
        private Queue<WebApp.Shared.Database> _queue;
        public event Func<Task> OnEnqueue;

        public DatabaseQueueService()
        {
            _queue = new Queue<WebApp.Shared.Database>();
        }

        public async Task EnqueueAsync(WebApp.Shared.Database database)
        {
            // ensure work was not already queued
            foreach (var db in _queue)
                if (db.Id == database.Id)
                    return;

            _queue.Enqueue(database);
            if (OnEnqueue != null)
                await OnEnqueue.Invoke();
        }

        public WebApp.Shared.Database Dequeue()
        {
            return _queue.Dequeue();
        }

        public int Count => _queue.Count;
    }
}
