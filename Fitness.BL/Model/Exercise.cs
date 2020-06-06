﻿using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get;}
        public DateTime Finish { get;}
        public Activity Activity { get;}

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user) {
            //проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
