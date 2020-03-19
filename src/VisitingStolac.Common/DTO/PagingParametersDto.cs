namespace VisitingStolac.Common
{
    /// <summary>
    /// parameters for paging
    /// </summary>
    public class PostPagingParametersDto
    {
        /// <summary>
        /// tells how many items we show per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// tells us which page we show
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// tells us on which language we want the posts
        /// </summary>
        public Locale Locale { get; set; }
    }
}
