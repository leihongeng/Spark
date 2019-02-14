namespace Spark.Core.Values
{
    public class QueryPageRequest
    {
        private int _pageIndex;

        public int PageIndex
        {
            get
            {
                return _pageIndex <= 0 ? 1 : _pageIndex;
            }
            set
            {
                if (value <= 0)
                    _pageIndex = 1;
                else
                    _pageIndex = value;
            }
        }

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value >= 100)
                {
                    pageSize = 100;
                }
                else if (value <= 0)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = value;
                }
            }
        }

        public int Offset { get { return (PageIndex - 1) * PageSize; } }
    }
}