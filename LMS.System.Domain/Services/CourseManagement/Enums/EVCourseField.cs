using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.CourseManagement.Enums
{
    [Flags]
    public enum EVCourseField
    {
        Title = 1 << 0,
        Category = 1 << 1,
    }
}
