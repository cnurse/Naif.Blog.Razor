using Microsoft.AspNetCore.Components;
using Naif.Core.Models;

namespace Naif.Blog.Razor.Framework
{
    public class NaifComponentBase : ComponentBase
    {   
        [Parameter]
        public PageState PageState { get; set; }
        
        protected string GetMenuLink(MenuItem menuItem)
        {
            string href;
            if (string.IsNullOrEmpty(menuItem.Link))
            {
                href = $"/{menuItem.Controller}/";
                if (!string.IsNullOrEmpty(menuItem.Action))
                {
                    href += $"{menuItem.Action}/";
                }
            }
            else
            {
                href = menuItem.Link;
            }

            return href;
        }


    }
}