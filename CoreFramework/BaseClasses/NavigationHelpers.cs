using System;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {


        public T GoToPreviousPage<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        public T GoToDefaultWindow<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        public T GoToPreviousWindow<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        public T GoToDefaultFrame<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        public T GoToFrame<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
