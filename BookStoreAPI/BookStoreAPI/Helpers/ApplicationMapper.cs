using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BooksModel>().ReverseMap();
        }
    }
}
