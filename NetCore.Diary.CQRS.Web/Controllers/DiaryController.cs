using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCore.Diary.CQRS.Commands;
using NetCore.Diary.CQRS.Exceptions;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.Web.Controllers
{
    public class DiaryController : Controller
    {
        private readonly IReportDatabase _db;
        private readonly IMediator _mediator;
        public DiaryController(IReportDatabase db,IMediator mediator)
        {
            _db = db;
            _mediator = mediator;

        }
        public ActionResult Index()
        {
            ViewBag.Model = _db.GetItems();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var item = _db.GetById(id);
            _mediator.Send(new DeleteItemCommand(item.Id,item.Version));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(DiaryItemDto item)
        {
            _mediator.Send(new CreateItemCommand(Guid.NewGuid(),item.Title,item.Description,-1,item.From,item.To));

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var item = _db.GetById(id);
            var model = new DiaryItemDto()
            {
                Description = item.Description,
                From = item.From,
                Id = item.Id,
                Title = item.Title,
                To = item.To,
                Version = item.Version
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DiaryItemDto item)
        {
            try
            {
                _mediator.Send(new ChangeItemCommand(item.Id, item.Title, item.Description, item.From, item.To, item.Version));
            }
            catch (ConcurrencyException err)
            {

                ViewBag.error = err.Message;
                ModelState.AddModelError("", err.Message);
                return View();

            }
            
            return RedirectToAction("Index");
        }
    }
}