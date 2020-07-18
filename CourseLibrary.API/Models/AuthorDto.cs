using System;

namespace CourseLibrary.API.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //First Name + Last Name
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}
