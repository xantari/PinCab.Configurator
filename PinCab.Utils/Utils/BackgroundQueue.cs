using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    //https://stackoverflow.com/questions/15119974/creating-backgroundworker-with-queue
    public class BackgroundQueue
    {
        private Task previousTask = Task.FromResult(true);
        private object key = new object();
        public Task QueueTask(Action action)
        {
            lock (key)
            {
                previousTask = previousTask.ContinueWith(t => action()
                    , CancellationToken.None
                    , TaskContinuationOptions.None
                    , TaskScheduler.Default);
                return previousTask;
            }
        }

        public Task<T> QueueTask<T>(Func<T> work)
        {
            lock (key)
            {
                var task = previousTask.ContinueWith(t => work()
                    , CancellationToken.None
                    , TaskContinuationOptions.None
                    , TaskScheduler.Default);
                previousTask = task;
                return task;
            }
        }

        public bool IsEmpty() { return previousTask.IsCompleted; }
    }
}
