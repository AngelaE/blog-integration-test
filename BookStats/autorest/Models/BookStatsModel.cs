// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace BookStats.Autorest.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class BookStatsModel
    {
        /// <summary>
        /// Initializes a new instance of the BookStatsModel class.
        /// </summary>
        public BookStatsModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BookStatsModel class.
        /// </summary>
        public BookStatsModel(int? bookId = default(int?), int? copiesSold = default(int?))
        {
            BookId = bookId;
            CopiesSold = copiesSold;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bookId")]
        public int? BookId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "copiesSold")]
        public int? CopiesSold { get; set; }

    }
}