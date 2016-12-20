﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeAndCode.Base;
using CoffeeAndCode.Domain.DbContexts;
using CoffeeAndCode.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAndCode.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly CoffeeAndCodeDbContext _context;

        public UsersController(CoffeeAndCodeDbContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public async Task<List<User>>  Get()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            Guid idGuid;
            if(!Guid.TryParse(id, out idGuid)) { return new User(); }
            return await _context.Users.SingleOrDefaultAsync(usr => usr.Id == idGuid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
