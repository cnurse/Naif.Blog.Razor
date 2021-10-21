using Microsoft.AspNetCore.Components;

namespace Naif.Blog.Razor.Framework
{
    public class NaifComponentBase : ComponentBase
    {   
        [Parameter]
        public PageState PageState { get; set; }
    }
}