﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessRepository.DataModels
{
    public class BookRepository : IDataAccessRepository<BookDataModel>
    {
        public BookRepository(IDbContext context) : base(context)
        {
        }

        public override void Add(BookDataModel record)
        {
            m_context.Books.Add(record);
        }

        public override void AddRange(IEnumerable<BookDataModel> records)
        {
            m_context.Books.AddRange(records);
        }

        public override Task<List<BookDataModel>> FindAll()
        {
            return m_context.Books.ToListAsync();
        }

        public override BookDataModel Find(int id)
        {
            return m_context.Books.FirstOrDefault(b => b.Id == id);
        }

        public override BookDataModel FindLast()
        {
            return m_context.Books.OrderByDescending(b => b.Id).FirstOrDefault();
        }

        public override void Remove(int id)
        {
            var book = Find(id);
            m_context.Books.Remove(book);
        }

        public override void RemoveRange(IEnumerable<int> idList)
        {
            throw new NotImplementedException();
        }

        public override void Update(BookDataModel record)
        {            
            m_context.Books.Update(record);
        }

        public override void Save()
        {
            m_context.SaveChanges();
        }
    }
}
