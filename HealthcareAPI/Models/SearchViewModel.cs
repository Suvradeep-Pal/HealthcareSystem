namespace Healthcare.UI.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }

        public bool? Status { get; set; }

        public int? PageIndex { get; set; }

        public int PageSize { get; set; } = 10;
    }
}
