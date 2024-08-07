using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WaterLogger.Models;
using WaterLogger.Repositories.Interfaces;

namespace WaterLogger.Pages.HabitUnits
{
    public class DeleteModel : PageModel
    {
        private readonly IHabitUnitRepository _repository;

        public DeleteModel(IHabitUnitRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public HabitUnit HabitUnit { get; set; }

        public IActionResult OnGet(int id)
        {
            HabitUnit = _repository.GetById(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _repository.Delete(id);
            return RedirectToPage("./Index");
        }

    }
}