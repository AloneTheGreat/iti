﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Controllers
{
    public class ChapterController : Controller
    {
        private IChapterRepository _chapterRepository;
        private IBookRepository _bookRepository;
        private ICommentRepository _commentRepository;
        private IUserCommentRepository _userCommentRepository;
        private UserManager<User> _userManager;
        public ChapterController(IChapterRepository chapterRepository, UserManager<User> userManager, IBookRepository bookRepository, ICommentRepository commentRepository, IUserCommentRepository userCommentRepository)
        {
            _chapterRepository = chapterRepository;
            _userManager = userManager;
            _bookRepository = bookRepository;
            _commentRepository = commentRepository;
            _userCommentRepository = userCommentRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (User != null)
            {
                User user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    Chapter chapter = await _chapterRepository.GetById(id);

                    List<Chapter> chapters = await _chapterRepository.GetAll(chapter.BookID);

                    Chapter next = chapters.Where(c => c.Order == chapter.Order + 1).FirstOrDefault();
                    Chapter prev = chapters.Where(c => c.Order == chapter.Order - 1).FirstOrDefault();
                    ViewBag.Next = next != null ? next.ID : 0;
                    ViewBag.Prev = prev != null ? prev.ID : 0;

                    Book book = await _bookRepository.GetById(chapter.BookID);
                    ViewBag.BookTitle = book.Name;
                    ViewBag.BookId = book.ID;

                    return View(chapter);
                }
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Chapters(int Id)
        {
            List<Chapter> chapters = await _chapterRepository.GetAll(Id);
            return View(chapters);
        }

        [HttpGet]
        public IActionResult Chapter()
        {
            return View(new Chapter());
        }

        [HttpPost]
        public async Task<IActionResult> Chapter(Chapter chapter)
        {
            if (chapter == null)
            {
                throw new ArgumentNullException(nameof(chapter));
            }
            await _chapterRepository.AddChapter(chapter);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _chapterRepository.Delete(Id);
            return Json(new { success = true });
        }

    }
}
