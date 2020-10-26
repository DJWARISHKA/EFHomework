using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFHomework
{
    internal class Program
    {
        private static async Task<List<Faculty>> get()
        {
            var db = new AppContext();
            return await db.Faculties.ToListAsync();
        }

        private static void Main(string[] args)
        {
            var faculties = get();
            faculties.Wait();
            var f = faculties.Result[0];
            Console.WriteLine(f.Groups.Count());
        }
    }
}