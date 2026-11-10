namespace portal_defesa_civil.DTOs
{
    public class NoticiaPagedResultDTO
    {
        public List<NoticiaDTO>? Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
