﻿using CourseLibrary.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot()
        {
            // create links for root
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetRoot", new { }),
              "self",
              "GET"),

                new LinkDto(Url.Link("GetAuthors", new { }),
              "authors",
              "GET"),

                new LinkDto(Url.Link("CreateAuthor", new { }),
              "create_author",
              "POST")
            };

            return Ok(links);

        }
    }
}
