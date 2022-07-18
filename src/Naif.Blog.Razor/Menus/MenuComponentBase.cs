using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Naif.Blog.Models;
using Naif.Blog.Razor.Framework;
using Naif.Core.Models;

namespace Naif.Blog.Razor
{
    public class MenuComponentBase : NaifComponentBase
    {
        [Parameter]
        public string CssClass { get; set; }
    
        [Parameter]
        public int Depth { get; set; } = 1;
        
        [Parameter]
        public string HeadingText { get; set; }

        [Parameter] 
        public bool IncludeHeading { get; set; } = true;

        [Parameter] 
        public bool IncludeParent { get; set; } = false;
        
        protected Menu Menu { get; set; }

        [Parameter]
        public string PostId { get; set; }
        
        [Parameter]
        public IList<Post> Posts { get; set; }
        
        [Parameter]
        public string SubMenuCssClass { get; set; }
        
        protected virtual MenuItem CreateMenuItem(Post post)
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
        
        protected override void OnParametersSet()
        {
            Menu = new Menu
            {
                Depth = Depth,
                IsActiveCssClass = "active",
                Items = new List<MenuItem>()
            };
    
            //Include Parent
            if (IncludeParent && Depth == 1 && !string.IsNullOrEmpty(PostId))
            {
                var currentPost = Posts.SingleOrDefault(p => p.PostId == PostId);
    
                if (currentPost != null && !string.IsNullOrEmpty(currentPost.ParentPostId))
                {
                    AddParentPost(Menu, currentPost);
                }
            }
    
            //Add Pages to Menu
            var posts = Posts.Where(p => p.ParentPostId == PostId).OrderBy(p => p.PageOrder);
            AddMenuItems(Menu, posts, 1);
        }
    
        private void AddMenuItems(BaseMenuItem menuItem, IEnumerable<Post> posts, int level)
        {
            foreach(var post in posts)
            {
                var childItem = CreateMenuItem(post);
                menuItem.Items.Add(childItem);
    
                if (level < Depth)
                {
                    var childPosts = Posts.Where(p => p.ParentPostId == post.PostId).OrderBy(p => p.PageOrder).ToList();
                    if (IncludeParent)
                    {
                        childPosts.Insert(0, post);
                    }
                    AddMenuItems(childItem, childPosts, level + 1);
                }
            }
        }
    
        private void AddParentPost(BaseMenuItem menuItem, Post currentPost)
        {
            var parentPost = Posts.SingleOrDefault(p => p.PostId == currentPost.ParentPostId);
            if (parentPost != null)
            {
                var childItem = CreateMenuItem(parentPost);
                menuItem.Items.Add(childItem);
            }
        }
    }
}