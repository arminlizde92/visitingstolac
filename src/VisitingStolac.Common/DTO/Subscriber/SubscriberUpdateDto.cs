namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for subscriber update
    /// </summary>
    public class SubscriberUpdateDto
    {
        /// <summary>
        /// subscriber id
        /// </summary>
        public int Id { get; set; }

        /// <summary> is subscriber subscribed on news</summary>
        public bool IsSubscribedOnNews { get; set; }

        /// <summary> is subscriber subscribed on posts </summary>
        public bool IsSubscribedOnPosts { get; set; }

        /// <summary> subsriber status </summary>
        public bool IsActive { get; set; }
    }
}
