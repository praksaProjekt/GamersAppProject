﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamersApp.Data;
using GamersApp.Entities;
using GamersApp.Services.PostServices;
using GamersApp.DTO;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices postService;

        public PostsController(IPostServices postService)
        {
            this.postService = postService;
        }
        [HttpPost("addpost")]
        public async Task<IActionResult> AddPost(PostModel postData)
        {
            var newPost = await postService.AddPost(postData);

            if (newPost != null)
                return Ok(newPost);

            return BadRequest();

        }

        [HttpGet("findpost")]
        public async Task<IActionResult> FindPost(int postId)
        {
            var post = await postService.FindPost(postId);

            if (post != null)
                return Ok(post);

            return BadRequest();

        }

        [HttpGet("getuserposts")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var post = await postService.GetUserPosts(userId);

            if (post != null)
                return Ok(post);

            return BadRequest();

        }

        [HttpPost("changeLikes")]
        public async Task<IActionResult> changeLikes(int postId, bool value, int userId)
        {
            await postService.ChangeLikes(postId, value, userId);
            return Ok();
        }

        [HttpDelete("removeLike")]
        public async Task<IActionResult> removeLike(int likeId)
        {
            await postService.RemoveLike(likeId);
            return Ok();
        }




    }
}
