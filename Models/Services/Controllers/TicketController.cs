using Microsoft.AspNetCore.Mvc;

namespace ITHelpDesk
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Index(string category, string status)
        {
            var tickets = _ticketService.FilterTickets(category, status);
            ViewBag.TotalCount = _ticketService.GetTotalCount();
            ViewBag.Stats = _ticketService.GetStatsByStatus();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.CreateTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public IActionResult Details(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            _ticketService.UpdateTicketStatus(id, status);
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
