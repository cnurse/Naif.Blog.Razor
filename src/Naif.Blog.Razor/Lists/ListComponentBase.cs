using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Naif.Blog.Models;
using Naif.Blog.Razor.Framework;

namespace Naif.Blog.Razor
{
    public class ListComponentBase : NaifComponentBase
    {
        [Parameter]
        public IEnumerable<Post> Posts { get; set; }
	
        [Parameter]
        public RouteValueDictionary RouteValues { get; set; }
    }
}