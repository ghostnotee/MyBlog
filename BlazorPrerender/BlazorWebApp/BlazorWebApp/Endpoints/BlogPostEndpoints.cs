using Data.Models;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApp.Endpoints;

public static class BlogPostEndpoints
{
    public static void MapBlogPostApi(this WebApplication app)
    {
        app.MapGet("/api/BlogPosts",
            async (IBlogApi api, [FromQuery] int numberofposts, [FromQuery] int startindex) =>
            Results.Ok((object?)await api.GetBlogPostsAsync(numberofposts, startindex)));

        app.MapGet("/api/BlogPostCount",
            async (IBlogApi api) => Results.Ok((object?)await api.GetBlogPostCountAsync()));

        app.MapGet("/api/BlogPosts/{*id}",
            async (IBlogApi api, string? id) => Results.Ok((object?)await api.GetBlogPostAsync(id)));

        app.MapPut("/api/BlogPosts",
            async (IBlogApi api, [FromBody] BlogPost item) => Results.Ok((object?)await api.SaveBlogPostAsync(item))).RequireAuthorization();

        app.MapDelete("/api/BlogPosts/{*id}", async (IBlogApi api, string? id) =>
        {
            await api.DeleteBlogPostAsync(id);
            return Results.Ok();
        }).RequireAuthorization();
    }
}