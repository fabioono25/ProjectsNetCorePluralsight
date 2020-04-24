using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    //[CourseTitleMustBeDifferentFromDescriptionAttribute(ErrorMessage = "Tittle different from description")]
    //public class CourseForCreationDto //: IValidatableObject
    //{
    //    [Required(ErrorMessage = "Fill title")]
    //    [MaxLength(100)]
    //    public string Title { get; set; }

    //    [MaxLength(1500)]
    //    public string Description { get; set; }

    //    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    //{
    //    //    if (Title == Description)
    //    //    {
    //    //        yield return new ValidationResult("The provided description should be different from the title.", new[] { "CourseForCreationDto" });
    //    //    }
    //    //}
    //    //it's proposital not to have authorId... we avoid one more verification if this id = author id from URI
    //}
    public class CourseForCreationDto : CourseForManipulationDto { }
}
