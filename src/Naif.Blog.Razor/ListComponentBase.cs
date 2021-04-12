using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Naif.Blog.Models;

namespace Naif.Blog.Razor
{
    public class ListComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Post> Posts { get; set; }
	
        [Parameter]
        public RouteValueDictionary RouteValues { get; set; }
    }
}