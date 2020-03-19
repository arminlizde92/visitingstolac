namespace VisitingStolac.DAL
{
    /// <summary>
    /// FAQ class
    /// </summary>
    public class FAQ
    {
        /// <summary> identification number </summary>
        public int Id { get; set; }

        /// <summary> id of text content (question) </summary>
        public int QuestionId { get; set; }

        /// <summary> virtual instance of text content (question) </summary>
        public virtual TextContent Question { get; set; }

        /// <summary> id of text content (answer) </summary>
        public int AnswerId { get; set; }

        /// <summary> virtual instance of text content (answer) </summary>
        public virtual TextContent Answer { get; set; }
    }
}
