﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Controllers
{
    public class ReviewController : Controller
    {
        private IBookRepository _bookRepository;
        private UserManager<User> _userManager;
        private IUserReviewRepository _userReviewRepository;
        private IReviewRepository _reviewRepository;
        private IChapterRepository _chapterRepository;
        private IUserRepository _userRepository;

        public ReviewController(IBookRepository bookRepository, IUserReviewRepository userReviewRepository, UserManager<User> userManager, IReviewRepository reviewRepository, IChapterRepository chapterRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userReviewRepository = userReviewRepository;
            _userManager = userManager;
            _reviewRepository = reviewRepository;
            _chapterRepository = chapterRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int Id)
        {
            List<Review> reviews = await _reviewRepository.GetAll(Id);
            return View(reviews);
        }

        [HttpGet]
        public async Task<IActionResult> Review()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    return View(new Review());
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Review(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }
            await _reviewRepository.AddReview(review);
            await _bookRepository.CalculateRating(review.BookID);
            int rating = _bookRepository.GetById(review.BookID).Result.Rating;
            return Json(new { success = true, r = rating });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            int bookId = _reviewRepository.GetById(Id).Result.BookID;
            await _reviewRepository.Delete(Id);
            await _bookRepository.CalculateRating(bookId);
            int rating = _bookRepository.GetById(bookId).Result.Rating;
            return Json(new { success = true, r = rating });
        }

        [HttpPost]
        public async Task<IActionResult> UpVote(int reviewId, int vote)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    int currentVote = 0;
                    UserReview userReview = await _userReviewRepository.GetUserReviewAsync(user.Id, reviewId);
                    if (userReview != null)
                    {
                        currentVote = userReview.Likes;
                    }
                    await _userReviewRepository.SetUserReviewAsync(user.Id, reviewId, vote);
                    for (int i = 0; i < (vote - currentVote); i++)
                    {
                        await _reviewRepository.UpVote(reviewId);
                    }
                }
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DownVote(int reviewId, int vote)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    int currentVote = 0;
                    UserReview userReview = await _userReviewRepository.GetUserReviewAsync(user.Id, reviewId);
                    if (userReview != null)
                    {
                        currentVote = userReview.Likes;
                    }
                    await _userReviewRepository.SetUserReviewAsync(user.Id, reviewId, vote);
                    for (int i = 0; i < Math.Abs(vote - currentVote); i++)
                    {
                        await _reviewRepository.DownVote(reviewId);
                    }
                }
            }
            return Json(new { success = true });
        }

    }
}
