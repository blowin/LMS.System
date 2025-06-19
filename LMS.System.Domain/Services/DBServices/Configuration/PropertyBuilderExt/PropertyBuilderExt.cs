using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.System.Domain.Services.DBServices.Configuration.PropertyBuilderExt
{
    /// <summary>
    /// Extension метод для enum.
    /// </summary>
    public static class PropertyBuilderExt
    {
        /// <summary>
        /// Extension метод для enum.
        /// </summary>
        /// <typeparam name="TProp">Шаблон.</typeparam>
        /// <param name="self">передаем шаблон enum.</param>
        /// <returns>Возвращаем комментарий к бд.</returns>
        public static PropertyBuilder<TProp> HasEnumComment<TProp>(this PropertyBuilder<TProp> self)
            where TProp : struct, Enum
        {
            var items = Enum.GetValues<TProp>().Select(e => ((int)(object)e) + " = " + e.ToString());
            return self.HasComment(string.Join(" , ", items));
        }
    }
}
