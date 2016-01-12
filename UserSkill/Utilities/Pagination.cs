using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UserSkill.Models;

namespace UserSkill.Utilities
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public Pagination PageInfo { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Genders { get; set; }
    }
}