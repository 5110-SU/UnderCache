using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Product Model Class used for Product Data
    /// </summary>
    public class ProductModel
    {   
        // Product Id
        public string Id { get; set; }

        // Product Owner/Maker
        public string Maker { get; set; }

        // Product Image Url
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Product Website Url
        public string Url { get; set; }
        
        // Product Name
        [Required (ErrorMessage = "Title is required")]
        [StringLength (maximumLength: 33, MinimumLength = 2, ErrorMessage = "Provide more than {2} and less than {1} charactors")]
        public string Title { get; set; }

        // Product Description
        public string Description { get; set; }

        // Product Address
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$",
           ErrorMessage = "Please Enter a valid address!")]
        [StringLength(80)]
        public string Address { get; set; }

        // Product Hours
        public string[] Hours { get; set; }

        // Product Ratings
        public int[] Ratings { get; set; }

        // Product Enum Type
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        // Product Quantity
        public string Quantity { get; set; }

        // Product Price
        [Range (-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        // Comment List for Product
        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        /// <summary>
        /// Convert ProductModel to Json String
        /// </summary>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}