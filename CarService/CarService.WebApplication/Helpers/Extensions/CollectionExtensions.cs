using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Helpers.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<TType, TKey>(this IEnumerable<TType> items,
             Func<TType, TKey> key,
             Func<TType, string> text)
        {
            return items
                    .Select(item =>
                            new SelectListItem
                            {
                                Text = text(item),
                                Value = key(item).ToString()
                            });
        }

    }
}