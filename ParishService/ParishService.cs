using Parish.Domain;
using Parish.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parish
{
    public class ParishService : IParishService
    {
        ParishContext _context = new ParishContext();
        public void AddParish(ParishDTO parish)
        {
            _context.Parishes.Add(parish);
            _context.SaveChanges();
        }

        public ParishDTO GetParish(string id)
        {
            return _context.Parishes.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public List<ParishDTO> GetParishes()
        {
            return _context.Parishes.ToList();
        }
    }
}