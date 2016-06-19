namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    /**
     * Problem 7. Timer & Problem 8.* Events
     * Using delegates write a class Timer that can execute certain method at each t seconds.
     * Read in MSDN about the keyword event in C# and how to publish events.
     * Re-implement the above using .NET events and following the best practices.
     */
    public class HomeworkTimer
    {
        private event Action OneSecond;

        private readonly Timer timer;

        private readonly ICollection<Action> oneOffs;

        public HomeworkTimer()
        {
            this.timer = new Timer { Interval = 1000 };
            this.timer.Elapsed += this.OnOneSecond;
            this.oneOffs = new HashSet<Action>();
        }

        public bool IsRunning => this.timer.Enabled;

        public HomeworkTimer Start()
        {
            this.timer.Start();
            return this;
        }

        public HomeworkTimer Stop()
        {
            this.timer.Stop();
            return this;
        }

        /// <summary>
        /// Subscribe a method to be called each second once the timer is started
        /// </summary>
        /// <param name="callback">A void method without arguments</param>
        public HomeworkTimer Subscribe(Action callback)
        {
            this.OneSecond += callback;
            return this;
        }

        public HomeworkTimer SubscribeOnce(Action callback)
        {
            this.oneOffs.Add(callback);
            this.Subscribe(callback);
            return this;
        }

        public HomeworkTimer Unsubscribe(Action callback)
        {
            this.OneSecond -= callback;
            this.oneOffs.Remove(callback);
            return this;
        }

        protected virtual void OnOneSecond(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            this.OneSecond?.Invoke();
            this.UnsubscribeOneOffs();
        }

        private void UnsubscribeOneOffs()
        {
            if (this.oneOffs.Count > 0)
            {
                foreach (var action in this.oneOffs)
                {
                    this.OneSecond -= action;
                }

                this.oneOffs.Clear();
            }
        }
    }
}