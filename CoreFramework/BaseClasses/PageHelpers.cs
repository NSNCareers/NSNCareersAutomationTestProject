namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {

        public string PageUrl
        {
            get { return driver.Url; }
            set { driver.Url = value; }
        }

        public string PageName
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Titel
        {
            get;
            set;
        }
    }
}
