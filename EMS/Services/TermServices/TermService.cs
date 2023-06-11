using System.Collections.Generic;
using System.Linq;
using EMS.Entities;
using System;

namespace EMS.Services.TermServices

{
    public class TermService
    {
        private readonly EMSContext _context;
        public TermService()
        {
            _context = new EMSContext();
        }
        public void Insert(TermInsertDto input)
        {
            Term t = new Term();
            t.Cid = input.CId;
            t.Sem = input.Sem;
            t.Pid = input.PId;
            _context.Add(t);
            _context.SaveChanges();
        }
        public List<TermSearchDto> Search(TermSearchDto input)
        {
              var query = _context.Terms.AsQueryable();
         
                if (input.Sem != null)
                {
                    query = query.Where(t => t.Sem == input.Sem);
                }
                if (input.PId != null)
                {
                    query = query.Where(t => t.Pid == input.PId);
                }
                if (input.CId != null)
                {
                    query = query.Where(t => t.Cid == input.CId);
                }

            var results = query.ToList();
            List<TermSearchDto> output = new();
            TermSearchDto temp;
            foreach (var i in results)
            {
                temp = new()
                {
                    PId = i.Pid,
                    Sem = i.Sem,
                    CId = i.Cid,
                    Id = i.Id
                };
                output.Add(temp);
            }
            return output;
        }
        public void Select(TermSelectDto input)
        {
            if(!(_context.Terms.Any(t => t.Id == input.TId)))
            {
                throw new ApplicationException("No term with provided Id was found");
            }
            else if(!(_context.Students.Any(t => t.Id == input.SId)))
            {
                throw new Exception("No Student with provided Id was found");
            }
            else
            {
                Selection t = new() 
                { 
                    Sid = input.SId,
                    Tid = input.TId
                };
                _context.Selections.Add(t);
                _context.SaveChanges();
            }
        }
    }
}
