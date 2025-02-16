using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using HRMS.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class BaseController<T> : Controller 
        where T : BaseEntity
    {
        protected readonly IBaseService<T> _service;
        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(bool showDeleted = false)
        {
            var departments = await _service.GetAllAsync(showDeleted);
            ViewBag.ShowDeleted = showDeleted;

            // Check if the request is from HTMX
            if (Request.Headers["HX-Request"].Any())
            {
                return PartialView("_MasterList", departments); // Return only the table
            }

            return View("Index", departments); // Return full page for normal request
        }


        // Create - Show form
        public virtual IActionResult Create()
        {
            var model = new BaseMasterViewModel();
            ViewData["EntityName"] = typeof(T).Name;
            return PartialView("_MasterForm", model);
        }

        // Edit - Show form
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var model = new BaseMasterViewModel
            {
                Id = entity.Id,
                Name = (string)entity.GetType().GetProperty("Name")?.GetValue(entity),
                Description = (string)entity.GetType().GetProperty("Description")?.GetValue(entity)
            };

            ViewData["EntityName"] = typeof(T).Name;
            return PartialView("_MasterForm", model);
        }

        // Edit - Update record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(BaseMasterViewModel model)
        {
            if (!ModelState.IsValid) return View("_MasterForm", model);

            T entity;
            if (model.Id == Guid.Empty) // Create
            {
                entity = Activator.CreateInstance<T>();
            }
            else // Edit
            {
                entity = await _service.GetByIdAsync(model.Id);
                if (entity == null) return NotFound();
            }

            entity.GetType().GetProperty("Name")?.SetValue(entity, model.Name);
            entity.GetType().GetProperty("Description")?.SetValue(entity, model.Description);

            if (model.Id == Guid.Empty)
                await _service.AddAsync(entity);
            else
                await _service.UpdateAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                // Perform soft delete
                await _service.SoftDeleteAsync(id);

                // Return success message as a string
                return Content("Record deleted successfully.");
            }
            catch (Exception ex)
            {

                // Return error message as a string
                return Content("Error while deleting." + ex);
            }
        }

        // Restore Deleted Record
        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _service.RestoreAsync(id);
                return Content("Record restored successfully.");
            }
            catch (Exception ex)
            {
                return Content("Error while restoring." + ex);
            }
        }
    }
}
