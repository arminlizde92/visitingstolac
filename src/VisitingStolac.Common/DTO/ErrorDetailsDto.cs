using Newtonsoft.Json;

namespace VisitingStolac.Common
{
    public class ErrorDetailsDto
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// overrides ToString method
        /// </summary>
        /// <returns>error details in json format</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
