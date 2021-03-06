#nullable disable
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3.Data;
using Garage3.Entities;
using Garage3.Models;
using Garage3.Models.MemberViewModels;
using AutoMapper;

namespace Garage3.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage3Context _context;
        private readonly IMapper mapper;

        public MembersController(Garage3Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            /*var viewModel = _context.Member.OrderByDescending(m => m.Id)
                                            .Select(m => new MemberIndexViewModel(m.Id, m.PersonalNo, m.Age, m.Name.FullName))                         
                                            .Take(15);*/
            var viewModel = mapper.ProjectTo<MemberIndexViewModel>(_context.Member)
                                  .OrderByDescending(m => m.Id)
                                  .Take(15);
            

            return View(await viewModel.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var member = await mapper.ProjectTo<MemberDetailsViewModel>(_context.Member)
            //                         .Include(v => v.Vehicles)
            //                         .FirstOrDefaultAsync(m => m.Id == id);


            var member = await _context.Member
                .Include(m => m.Name)
                .Include(m => m.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);


            var viewModel = new MemberDetailsViewModel
            {
                Id = member.Id,
                Age = member.Age,
                PersonalNo = member.PersonalNo,
                NameFirstName = member.Name.FirstName,
                NameLastName = member.Name.LastName,
                Vehicles = member.Vehicles
            };

            if (member == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var member = new Member(viewModel.PersonalNo, viewModel.Age, new Name(viewModel.NameFirstName, viewModel.NameLastName));
                var member = mapper.Map<Member>(viewModel);

                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Members/Edit/5
        //public async Task<IActionResult> Edit(int? id, MemberEditViewModel viewModel)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .Include(m => m.Name)
                .FirstOrDefaultAsync(m => m.Id == id);

            var viewModel = new MemberEditViewModel 
                {     
                    Id = member.Id,
                    NameFirstName = member.Name.FirstName,
                    NameLastName = member.Name.LastName,
                PersonalNo = member.PersonalNo,
                Age = member.Age
            };
            
            //var member = await _context.Member.FindAsync(id, viewModel.NameFirstName, viewModel.NameLastName);
            if (member == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var member =  await _context.Member.Include(m => m.Name)
                        .FirstOrDefaultAsync(m => m.Id == id);

                    mapper.Map(viewModel, member);

                    //var member = _context.Map<Member>(viewModel);
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(viewModel.Id))
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
            return View(viewModel);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}
