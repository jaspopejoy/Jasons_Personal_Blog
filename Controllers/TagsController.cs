using Jasons_Personal_Blog.Data;
using Jasons_Personal_Blog.Models.Domain;
using Jasons_Personal_Blog.Models.ViewModels;
using Jasons_Personal_Blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jasons_Personal_Blog.Controllers
{
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITagRepository tagRepository;

        public TagsController(ApplicationDbContext context, ITagRepository tagRepository)
        {
            _context = context;
            this.tagRepository = tagRepository;
        }

        // GET: Tags
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //use _context to read the tags
            var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }

        // GET: Tags/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTagRequest createTagRequest)
        {
            //mapping add tag request to the tag model
            var tag = new Tag
            {
                Name = createTagRequest.Name,
                DisplayName = createTagRequest.DisplayName
            };
            
            await tagRepository.AddAsync(tag);

            return RedirectToAction("Index");
        }

        // GET: Tags/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    DisplayName = tag.DisplayName,
                };

                return View(editTagRequest);
            }

            return View(null);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                //show success notification
            }
            else
            {
                //Show Error Notification
            }

            return RedirectToAction("Index", new { id = editTagRequest.Id });
        }


        // GET: Tags/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deletedTag = await tagRepository.DeleteAsync(id);

            if (deletedTag != null)
            {
                //show success notification
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id });
        }

        private bool TagExists(Guid id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
