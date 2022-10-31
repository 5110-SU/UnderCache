﻿using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Index page
    /// </summary>
    public class IndexModel : PageModel
    {
        // Logger for Index.cshtml.cs
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Request for IndexModel logger 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Get method returns Product Service
        /// </summary>
        public JsonFileProductService ProductService { get; }

        public IEnumerable<ProductModel> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}