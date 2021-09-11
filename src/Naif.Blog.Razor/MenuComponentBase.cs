using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Naif.Blog.Models;
using Naif.Core.Models;

namespace Naif.Blog.Razor
{
    public class MenuComponentBase : ComponentBase
    {
        protected MenuItem CreateMenuItem(Post post)
        {
            MenuItem item = null;
            switch (post.PostType)
            {
                case PostType.Post:
                    item = new MenuItem
                    {
                        IsActive = false,
                        Link = $"/post/{post.Slug}",
                        Text = post.Title
                    };
                    break;
                case PostType.Page:
                    item = new MenuItem
                    {
                        IsActive = false,
                        Link = $"/page/{post.Slug}",
                        Text = post.Title
                    };
                    break;
                case PostType.Blog:
                    item = new MenuItem
                    {
                        Link = $"/page/blog/{post.PostTypeDetail}",
                        IsActive = false,
                        Text = post.Title
                    };
                    break;
                case PostType.Category:
                    item = new MenuItem
                    {
                        Link = $"/page/category/{post.PostTypeDetail}",
                        IsActive = false,
                        Text = post.Title
                    };
                    break;
                case PostType.Tag:
                    item = new MenuItem
                    {
                        Link = $"/page/tag/{post.PostTypeDetail}",
                        IsActive = false,
                        Text = post.Title
                    };
                    break;
                case PostType.Url:
                    item = new MenuItem
                    {
                        Link = $"{post.PostTypeDetail}",
                        IsActive = false,
                        Text = post.Title
                    };
                    break;
            }

            item.Items = new List<MenuItem>();

            return item;
        }

    }
}