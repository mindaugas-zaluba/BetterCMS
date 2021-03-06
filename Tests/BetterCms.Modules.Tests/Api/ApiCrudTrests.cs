﻿using System;
using System.Collections.Generic;
using System.Linq;

using BetterCms.Core.DataAccess.DataContext;

using BetterCms.Module.Api;
using BetterCms.Module.Api.Extensions;
using BetterCms.Module.Api.Operations.Blog.Authors.Author;
using BetterCms.Module.Api.Operations.Blog.BlogPosts;
using BetterCms.Module.Api.Operations.Blog.BlogPosts.BlogPost.Properties;
using BetterCms.Module.Api.Operations.Blog.BlogPosts.Settings;
using BetterCms.Module.Api.Operations.MediaManager.Files.File;
using BetterCms.Module.Api.Operations.MediaManager.Folders;
using BetterCms.Module.Api.Operations.MediaManager.Folders.Folder;
using BetterCms.Module.Api.Operations.MediaManager.Images;
using BetterCms.Module.Api.Operations.MediaManager.Images.Image;
using BetterCms.Module.Api.Operations.Pages.Contents.Content.Draft;
using BetterCms.Module.Api.Operations.Pages.Contents.Content.HtmlContent;
using BetterCms.Module.Api.Operations.Pages.Pages;
using BetterCms.Module.Api.Operations.Pages.Pages.Page.Contents.Content;
using BetterCms.Module.Api.Operations.Pages.Pages.Page.Properties;
using BetterCms.Module.Api.Operations.Pages.Redirects.Redirect;
using BetterCms.Module.Api.Operations.Pages.Sitemaps;
using BetterCms.Module.Api.Operations.Pages.Sitemaps.Sitemap;
using BetterCms.Module.Api.Operations.Pages.Sitemaps.Sitemap.Nodes;
using BetterCms.Module.Api.Operations.Pages.Sitemaps.Sitemap.Nodes.Node;
using BetterCms.Module.Api.Operations.Pages.Widgets.Widget.HtmlContentWidget;
using BetterCms.Module.Api.Operations.Pages.Widgets.Widget.ServerControlWidget;
using BetterCms.Module.Api.Operations.Root.Categories.Category;
using BetterCms.Module.Api.Operations.Root.Languages.Language;
using BetterCms.Module.Api.Operations.Root.Layouts.Layout;
using BetterCms.Module.Api.Operations.Root.Tags.Tag;

using NUnit.Framework;

namespace BetterCms.Test.Module.Api
{
    [TestFixture]
    public class ApiCrudTrests : TestBase
    {
        [Ignore]
        [Test]
        public void Synch_Crud_Examples()
        {
            using (var api = ApiFactory.Create())
            {
                // Tags:
                var tag = api.Root.Tag.Get(new GetTagRequest());
                api.Root.Tags.Post(tag.ToPostRequest());
                api.Root.Tag.Put(tag.ToPutRequest());
                api.Root.Tag.Delete(new DeleteTagRequest());

                // Categories:
                var category = api.Root.Category.Get(new GetCategoryRequest());
                api.Root.Categories.Post(category.ToPostRequest());
                api.Root.Category.Put(category.ToPutRequest());
                api.Root.Category.Delete(new DeleteCategoryRequest());

                // Layouts:
                var getLayoutRequest = new GetLayoutRequest();
                getLayoutRequest.Data.IncludeOptions = true;
                getLayoutRequest.Data.IncludeRegions = true;
                var layout = api.Root.Layout.Get(getLayoutRequest);
                api.Root.Layouts.Post(layout.ToPostRequest());
                api.Root.Layout.Put(layout.ToPutRequest());
                api.Root.Layout.Delete(new DeleteLayoutRequest());

                // Folders:
                var folder = api.Media.Folder.Get(new GetFolderRequest());
                api.Media.Folders.Post(folder.ToPostRequest());
                api.Media.Folder.Put(folder.ToPutRequest());
                api.Media.Folder.Delete(new DeleteFolderRequest());

                // Images:
                var image = api.Media.Image.Get(new GetImageRequest());
                api.Media.Images.Post(image.ToPostRequest());
                api.Media.Image.Put(image.ToPutRequest());
                api.Media.Image.Delete(new DeleteImageRequest());

                // Files:
                var file = api.Media.File.Get(new GetFileRequest());
                api.Media.Files.Post(file.ToPostRequest());
                api.Media.File.Put(file.ToPutRequest());
                api.Media.File.Delete(new DeleteFileRequest());

                // Languages:
                var language = api.Root.Language.Get(new GetLanguageRequest());
                api.Root.Languages.Post(language.ToPostRequest());
                api.Root.Language.Put(language.ToPutRequest());
                api.Root.Language.Delete(new DeleteLanguageRequest());

                // Redirects:
                var redirect = api.Pages.Redirect.Get(new GetRedirectRequest());
                api.Pages.Redirects.Post(redirect.ToPostRequest());
                api.Pages.Redirect.Put(redirect.ToPutRequest());
                api.Pages.Redirect.Delete(new DeleteRedirectRequest());

                // Server Widget:
                var getSWRequest = new GetServerControlWidgetRequest();
                getSWRequest.Data.IncludeOptions = true;
                var serverWidget = api.Pages.Widget.ServerControl.Get(getSWRequest);
                api.Pages.Widget.ServerControl.Post(serverWidget.ToPostRequest());
                api.Pages.Widget.ServerControl.Put(serverWidget.ToPutRequest());
                api.Pages.Widget.ServerControl.Delete(new DeleteServerControlWidgetRequest());

                // Html Widgets:
                var getHWRequest = new GetHtmlContentWidgetRequest();
                getHWRequest.Data.IncludeOptions = true;
                var htmlWidget = api.Pages.Widget.HtmlContent.Get(getHWRequest);
                api.Pages.Widget.HtmlContent.Post(htmlWidget.ToPostRequest());
                api.Pages.Widget.HtmlContent.Put(htmlWidget.ToPutRequest());
                api.Pages.Widget.HtmlContent.Delete(new DeleteHtmlContentWidgetRequest());

                // Html Contents:
                var html = api.Pages.Content.Html.Get(new GetHtmlContentRequest());
                // TODO: implement post.
                api.Pages.Content.Html.Put(html.ToPutRequest());
                api.Pages.Content.Html.Delete(new DeleteHtmlContentRequest());

                // Pages:
                var getPageRequest = new GetPagePropertiesRequest();
                getPageRequest.Data.IncludeAccessRules = true;
                getPageRequest.Data.IncludePageOptions = true;
                getPageRequest.Data.IncludeMetaData = true;
                getPageRequest.Data.IncludeTags = true;
                var page = api.Pages.Page.Properties.Get(getPageRequest);
                api.Pages.Page.Properties.Post(page.ToPostRequest());
                api.Pages.Page.Properties.Put(page.ToPutRequest());
                api.Pages.Page.Properties.Delete(new DeletePagePropertiesRequest());

                // Page Contents:
                var getPCrequest = new GetPageContentRequest();
                getPCrequest.Data.IncludeOptions = true; // Only when options should be retrieved and saved
                var pageContent = api.Pages.Page.Content.Get(getPCrequest);
                api.Pages.Page.Content.Put(pageContent.ToPutRequest());
                api.Pages.Page.Content.Delete(new DeletePageContentRequest());

                // Blog Post:
                var getBlogRequest = new GetBlogPostPropertiesRequest();
                getBlogRequest.Data.IncludeHtmlContent = true;
                getBlogRequest.Data.IncludeAccessRules = true;
                getBlogRequest.Data.IncludeMetaData = true;
                getBlogRequest.Data.IncludeTags = true;
                var blog = api.Blog.BlogPost.Properties.Get(getBlogRequest);
                api.Blog.BlogPost.Properties.Post(blog.ToPostRequest());
                api.Blog.BlogPost.Properties.Put(blog.ToPutRequest());
                api.Blog.BlogPost.Properties.Delete(new DeleteBlogPostPropertiesRequest());
                var author = api.Blog.Author.Get(new GetAuthorRequest());
                api.Blog.Authors.Post(author.ToPostRequest());
                api.Blog.Author.Put(author.ToPutRequest());
                api.Blog.Author.Delete(new DeleteAuthorRequest());
                var settings = api.Blog.Settings.Get(new GetBlogPostsSettingsRequest());
                api.Blog.Settings.Put(settings.ToPutRequest());

                // Sitemap:
                var sitemap = api.Pages.SitemapNew.Get(new GetSitemapRequest());
                api.Pages.Sitemaps.Post(sitemap.ToPostRequest());
                api.Pages.SitemapNew.Put(sitemap.ToPutRequest());
                api.Pages.SitemapNew.Delete(new DeleteSitemapRequest());

                // Sitemap nodes:
                var node = api.Pages.SitemapNew.Node.Get(new GetNodeRequest());
                api.Pages.SitemapNew.Nodes.Post(node.ToPostRequest());
                api.Pages.SitemapNew.Node.Put(node.ToPutRequest());
                api.Pages.SitemapNew.Node.Delete(new DeleteNodeRequest());

                // Destroyed draft (should be called on event BetterCms.Events.PageEvents.Instance.ContentDraftDestroyed)
                var destroyDraftRequest = new DestroyContentDraftRequest();
                // destroyDraftRequest.ContentId = contentId;
                api.Pages.Content.Draft.Delete(destroyDraftRequest);
            }
        }

        [Ignore]
        [Test]
        public void Synch_Flow_Example()
        {
            using (var api = ApiFactory.Create())
            {
                // Blogs:
                var blogs = api.Blog.BlogPosts.Get(new GetBlogPostsRequest());
                var blog = api.Blog.BlogPost.Properties.Get(new GetBlogPostPropertiesRequest()
                                                                {
                                                                    BlogPostId = blogs.Data.Items.FirstOne().Id,
                                                                    Data = new GetBlogPostPropertiesModel
                                                                               {
                                                                                   IncludeAccessRules = true,
                                                                                   IncludeAuthor = true,
                                                                                   IncludeLanguage = true,
                                                                                   IncludeCategory = true,
                                                                                   IncludeHtmlContent = true,
                                                                                   IncludeImages = true,
                                                                                   IncludeLayout = true,
                                                                                   IncludeMetaData = true,
                                                                                   IncludeTags = true,
                                                                                   IncludeTechnicalInfo = true
                                                                               }
                                                                });
                api.Blog.BlogPost.Properties.Post(blog.ToPostRequest());
                api.Blog.BlogPost.Properties.Put(blog.ToPutRequest());

                // Pages:
                var pages = api.Pages.Pages.Get(new GetPagesRequest());
                var page = api.Pages.Page.Properties.Get(new GetPagePropertiesRequest
                                                             {
                                                                 PageId = pages.Data.Items.FirstOne().Id,
                                                                 Data = new GetPagePropertiesModel
                                                                            {
                                                                                IncludeAccessRules = true,
                                                                                IncludeCategory = true,
                                                                                IncludeImages = true,
                                                                                IncludeLanguage = true,
                                                                                IncludeLayout = true,
                                                                                IncludeMetaData = true,
                                                                                IncludePageContents = true,
                                                                                IncludePageOptions = true,
                                                                                IncludePageTranslations = true,
                                                                                IncludeTags = true
                                                                            }
                                                             });

                var updatedContent = new List<Guid>();
                foreach (var pageContentModel in page.PageContents)
                {
                    if (updatedContent.All(id => id != pageContentModel.ContentId))
                    {
                        updatedContent.Add(pageContentModel.ContentId);
                        switch (pageContentModel.ContentType)
                        {
                            case BetterCms.Module.Pages.Accessors.HtmlContentAccessor.ContentWrapperType:
                                var content = api.Pages.Content.Html.Get(new GetHtmlContentRequest { ContentId = pageContentModel.ContentId, });
                                api.Pages.Content.Html.Put(content.ToPutRequest());
                                break;
                            case BetterCms.Module.Pages.Accessors.ServerControlWidgetAccessor.ContentWrapperType:
                                var serverWidget =
                                    api.Pages.Widget.ServerControl.Get(
                                        new GetServerControlWidgetRequest
                                            {
                                                WidgetId = pageContentModel.ContentId,
                                                Data = new GetServerControlWidgetModel
                                                           {
                                                               IncludeOptions = true
                                                           }
                                            });
                                api.Pages.Widget.ServerControl.Post(serverWidget.ToPostRequest());
                                api.Pages.Widget.ServerControl.Put(serverWidget.ToPutRequest());
                                break;
                            case BetterCms.Module.Pages.Accessors.HtmlContentWidgetAccessor.ContentWrapperType:
                                var htmlWidget = api.Pages.Widget.HtmlContent.Get(
                                    new GetHtmlContentWidgetRequest
                                        {
                                            WidgetId = pageContentModel.ContentId,
                                            Data = new GetHtmlContentWidgetModel
                                                       {
                                                           IncludeOptions = true
                                                       }
                                        });
                                api.Pages.Widget.HtmlContent.Post(htmlWidget.ToPostRequest());
                                api.Pages.Widget.HtmlContent.Put(htmlWidget.ToPutRequest());
                                break;
                            default:
                                throw new NotSupportedException(string.Format("Content type '{0}' not supported.", pageContentModel.ContentType));
                        }
                    }
                }

                api.Pages.Page.Properties.Post(page.ToPostRequest());
                api.Pages.Page.Properties.Put(page.ToPutRequest());

                // Sitemaps:
                var sitemaps = api.Pages.Sitemaps.Get(new GetSitemapsRequest());
                var sitemap = api.Pages.SitemapNew.Get(new GetSitemapRequest
                                                           {
                                                               SitemapId = sitemaps.Data.Items.FirstOne().Id,
                                                               Data = new GetSitemapModel
                                                                          {
                                                                              IncludeAccessRules = true,
                                                                              IncludeNodes = true,
                                                                          }
                                                           });
                api.Pages.Sitemaps.Post(sitemap.ToPostRequest());
                api.Pages.SitemapNew.Put(sitemap.ToPutRequest());

                var nodes = api.Pages.SitemapNew.Nodes.Get(new GetSitemapNodesRequest
                                                               {
                                                                   SitemapId = sitemap.Data.Id
                                                               });
                var node = api.Pages.SitemapNew.Node.Get(new GetNodeRequest
                                                             {
                                                                 SitemapId = sitemap.Data.Id,
                                                                 NodeId = nodes.Data.Items.FirstOne().Id
                                                             });
                api.Pages.SitemapNew.Nodes.Post(node.ToPostRequest());
                api.Pages.SitemapNew.Node.Put(node.ToPutRequest());

                // Media:
                var images =
                    api.Media.Images.Get(new GetImagesRequest
                                             {
                                                 Data = new GetImagesModel
                                                            {
                                                                IncludeImages = true,
                                                                IncludeArchived = true,
                                                                IncludeFolders = false
                                                            }
                                             });
                var image = api.Media.Image.Get(new GetImageRequest
                                                    {
                                                        ImageId = images.Data.Items.FirstOne().Id,
                                                        Data = new GetImageModel
                                                                   {
                                                                       IncludeTags = true
                                                                   }
                                                    });
                api.Media.Images.Post(image.ToPostRequest());
                api.Media.Image.Put(image.ToPutRequest());
            }
        }

        [Ignore]
        [Test]
        public void Sitemap_Crud()
        {
            using (var api = ApiFactory.Create())
            {
                var sitemaps = api.Pages.Sitemaps.Get(new GetSitemapsRequest());

                // Sitemap:
                var sitemap = api.Pages.SitemapNew.Get(new GetSitemapRequest
                {
                    SitemapId = sitemaps.Data.Items.First().Id,
                    Data = new GetSitemapModel
                    {
                        IncludeAccessRules = true,
                        IncludeNodes = true,
                    }
                });
                var saveSitmapRequest = sitemap.ToPutRequest();

                // Sitemap nodes:
                var node = api.Pages.SitemapNew.Node.Get(new GetNodeRequest
                {
                    SitemapId = sitemap.Data.Id,
                    NodeId = sitemap.Nodes.First().Id
                });
                var saveNodeRequest = node.ToPutRequest();
            }
        }

        [Ignore]
        [Test]
        public void Folder_Crud()
        {
            using (var api = ApiFactory.Create())
            {
                var folders =
                    api.Media.Folders.Get(
                        new GetFoldersRequest { Data = new BetterCms.Module.Api.Operations.MediaManager.Folders.GetFolderModel() { IncludeArchived = true } });
            }
        }
    }
}
