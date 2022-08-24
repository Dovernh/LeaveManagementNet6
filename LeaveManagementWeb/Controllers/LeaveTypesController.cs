using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementWeb.Data;
using AutoMapper;
using LeaveManagementWeb.Contracts;
using LeaveManagementWeb.Models;

namespace LeaveManagementWeb.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = _mapper.Map<List<LeaveTypeVm>>(
                await _leaveTypeRepository.GetAllAsync()
            );

            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<LeaveTypeVm>(leaveType);
            return View(vm);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVm leaveTypeVm)
        {
            if (!ModelState.IsValid)
            {
                return View(leaveTypeVm);
            }
            
            var leaveType = _mapper.Map<LeaveType>(leaveTypeVm);
            await _leaveTypeRepository.AddAsync(leaveType);
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<LeaveTypeVm>(leaveType);
            return View(vm);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVm leaveTypeVm)
        {
            if (id != leaveTypeVm.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(leaveTypeVm);
            }
            
            try
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVm);
                await _leaveTypeRepository.UpdateAsync(leaveType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LeaveTypeExists(leaveTypeVm.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExists(int id)
        {
            return await _leaveTypeRepository.Exists(id);
        }
    }
}
