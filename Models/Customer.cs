﻿namespace WebAPI_CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Location>? Locations { get; set; }
    }
}
