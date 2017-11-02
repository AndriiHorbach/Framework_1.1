//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using OpenQA.Selenium.Support.UI;
//using Framework.Pages;
//using Framework.Driver;
//using System.Diagnostics;
//using System.Threading;

//namespace Framework.Common
//{
//    class ProjectWaits
//    {
//        private ProjectWaits() { }

//        public WebDriverWait Wait = new WebDriverWait(SeleniumDriver.getDriver(), TimeSpan.FromSeconds(10));

//        public bool WaitUntil<T>(T testObject, Func<T, Boolean> condition)
//        {
//            Stopwatch stopwatch = new Stopwatch();
//            stopwatch.Start();
//            bool result = false;
//            while (stopwatch.Elapsed <= _timeout && !result)
//            {
//                try
//                {
//                    result = condition.Invoke(testObject);
//                    if (!result)
//                    {
//                        Thread.Sleep(_retryTimeout);
//                    }
//                }
//                catch (Exception e)
//                {
//                    if (_ignoreExceptions.All(ex => ex != e.GetType()))
//                        throw;
//                    Thread.Sleep(_retryTimeout);
//                }
//            }

//            return result;
//        }

//        public bool WaitUntil(IWebElement element, Func<IWebElement, Boolean> condition)
//        {
//            return WaitUntil<IWebElement>(element, condition);
//        }
//        public T WaitUntil<T>(Func<T> predicate)
//        {
//            Exception exception = null;
//            var stopwatch = Stopwatch.StartNew();
//            while (stopwatch.Elapsed < _timeout)
//            {
//                try
//                {
//                    var result = predicate();
//                    if (!EqualityComparer<T>.Default.Equals(result, default(T)))
//                        return result;
//                    Thread.Sleep(_retryTimeout);
//                }
//                catch (Exception e)
//                {
//                    if (!_ignoreExceptions.Any(ex => ex == e.GetType()))
//                        exception = e;
//                    Thread.Sleep(_retryTimeout);
//                }
//            }

//            if (exception != null)
//            {
//                _message += string.Format(">{0}. Timeout {1}", exception.Message, stopwatch.Elapsed);
//                throw (Exception)Activator.CreateInstance(exception.GetType(), _message);
//            }

//            if (!_ignoreExceptions.Any(ex => ex == typeof(TimeoutException)))
//            {
//                _message += string.Format("> Timeout {0}", stopwatch.Elapsed);
//                throw new TimeoutException(_message);
//            }

//            return default(T);
//        }
//    }
//}
