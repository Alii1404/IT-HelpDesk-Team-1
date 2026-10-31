namespace ITHelpDesk
{
    public class TicketService
    {
        private static readonly List<Ticket> _tickets = new();
        private static int _idCounter = 1;

        public List<Ticket> GetAllTickets() => _tickets;

        public Ticket GetTicketById(int id) => _tickets.FirstOrDefault(t => t.Id == id);

        public void CreateTicket(Ticket ticket)
        {
            ticket.Id = _idCounter++;
            ticket.CreatedAt = DateTime.Now;
            ticket.Status = "New";
            _tickets.Add(ticket);
        }

        public void UpdateTicketStatus(int id, string status)
        {
            var ticket = GetTicketById(id);
            if (ticket != null)
            {
                ticket.Status = status;
            }
        }

        public List<Ticket> FilterTickets(string category, string status)
        {
            var query = _tickets.AsEnumerable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(status))
                query = query.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            return query.ToList();
        }

        public int GetTotalCount() => _tickets.Count;

        public Dictionary<string, int> GetStatsByStatus()
        {
            return _tickets.GroupBy(t => t.Status)
                           .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
