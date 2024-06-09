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
        readonly ParishContext _context = new ParishContext();
        public void AddParish(ParishModel parish)
        {
            _context.Parishes.Add(parish);
            _context.SaveChanges();
        }

        public ParishModel GetParish(string id)
        {
            return _context.Parishes.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public List<ParishModel> GetParishes()
        {
            return _context.Parishes.ToList();
        }
    }
}