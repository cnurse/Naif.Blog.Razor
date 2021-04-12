using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Naif.Blog.Models;

namespace Naif.Blog.Razor
{
    public class ListComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Post> Posts { get; set; }
	
        [Parameter]
        public Dictionary<string, string> RouteValues { get; set; }
    }
}