using System.Collections.Generic;

namespace Business.Support
{
    public class Paginate<T>
    {
        public int Page { get; set; }
        public int Total { get; set; }

        public int PerPage { get; set; }

        public List<T> Items { get; set; }

        public Paginate(List<T> items, int total, int perPage = 10)
        {
            Items = items;
            Total = total;
            PerPage = perPage;
        }


        public Paginate()
        {
        }

        public int Skip => (Page - 1) * PerPage;
        public int? Next => HasNext ? Page + 1 : (int?) null;
        public int? Previous => HasPrevious ? Page - 1 : (int?) null;
        public bool HasNext => (Skip + PerPage) < Total;
        public bool HasPrevious => Skip > 0;

        public bool DoesNotHaveNext => HasNext == false;
        public bool DoesNotHavePrevious => HasPrevious == false;
        public int Remaining => DoesNotHaveNext ? 0 : Total - (Skip + PerPage);
    }
}