//using System;
//using System.Diagnostics;
//using System.Threading;
//using Context;

//namespace Framework.Common
//{
//    class WaitByVadym
//    {
//        public static class Actions
//        {
//            public static void Persist(Action action, Action callBack = null, string message = null, double timeout = -1)
//            {
//                Exception exception = null;
//                var settings = Context.Timeouts;
//                if (timeout < 0)
//                    timeout = settings.PageTimeout.TotalMilliseconds;
//                var stopwatch = new Stopwatch();
//                stopwatch.Start();
//                while (stopwatch.ElapsedMilliseconds <= timeout)
//                    try
//                    {
//                        action();
//                        break;
//                    }
//                    catch (Exception lastException)
//                    {
//                        exception = lastException;
//                        if (callBack == null)
//                            Thread.Sleep(settings.RetryTimeout);
//                        else
//                            Persist(callBack);
//                    }
//                stopwatch.Stop();
//                if (exception != null && stopwatch.ElapsedMilliseconds >= timeout)
//                    throw new Exception(message, exception);
//            }

//            public static T Return<T>(Func<T> func, Action callBack = null, string message = "", double timeout = -1)
//            {
//                var result = default(T);
//                Persist(() => result = func(), callBack, message, timeout);
//                return result;
//            }
//        }
//    }
//    public static void For(Func<bool> condition, Action callBack = null, string message = "", double timeout = -1)
//        => Persist(() =>
//        {
//            if (!condition())
//                throw new Exception("Condition wasn't reached in specified timeout");
//        }, callBack, message, timeout);
//}
//}
