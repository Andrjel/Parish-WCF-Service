using Parish.Domain;
using Parish.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Parish
{
    /// <summary>
    /// Parish service implementation
    /// </summary>
    public class ParishService : IParishService
    {
        readonly ParishContext _context = new ParishContext();

        /// <summary>
        /// Add a new parish
        /// </summary>
        /// <param name="parish">Parish model object</param>
        /// <exception cref="FaultException"></exception>
        public void AddParish(ParishModel parish)
        {
            try
            {
                if (_context.Parishes.Any(x => x.Name.Equals(parish.Name)))
                    throw new FaultException("Parish already exists.");
                _context.Parishes.Add(parish);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Get a parish by id
        /// </summary>
        /// <param name="id">Id of searched Parish</param>
        /// <returns>Parish object</returns>
        /// <exception cref="FaultException"></exception>
        public ParishModel GetParish(string id)
        {
            try
            {
                var parish = _context.Parishes.FirstOrDefault(x => x.Id.ToString() == id);
                if (parish == null)
                    throw new FaultException("Parish not found.");

                return parish;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Get all parishes
        /// </summary>
        /// <returns>List of Parishes</returns>
        /// <exception cref="FaultException"></exception>
        public List<ParishModel> GetParishes()
        {
            try
            {
                var parishes = _context.Parishes.ToList();

                return parishes;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}