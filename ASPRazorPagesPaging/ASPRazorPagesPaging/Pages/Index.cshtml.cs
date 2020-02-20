using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ASPRazorPagesPaging;

namespace ASPRazorPagesPaging.Pages
{
    public class IndexModel : PageModel
    {
        List<Person> people;
        
        public IndexModel()
        {
            people = new List<Person>()
            {
                new Person {Name = "Sam", Age=25},
                new Person{ Name="Tom", Age=19},
                new Person {Name="Bob", Age=24},
                new Person {Name = "Kate", Age=25},
                new Person{ Name="Mary", Age=20},
                new Person {Name="Bill", Age=27},
                new Person {Name = "Yan", Age=28},
                new Person{ Name="Ana", Age=30},
                new Person {Name="Grey", Age=29},
            };
        }
        public List<Person> DisplayedPeople { get; set; }

       

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 4;

        public int TotalPages => (int) Math.Ceiling((decimal) Count / PageSize);

        public bool ShowPrev => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;

        public List<Person> GetPaginatedResult(int currentPage, int pageSize)
        {
            var data = GetData();
            return data.OrderBy(d => d.Age).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetCount()
        {
            return people.Count;
        }

        private List<Person> GetData()
        {
            return people;
        }
        
        #region Search

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
        
        public void OnGet(string searchString)
        {
            DisplayedPeople = GetPaginatedResult(CurrentPage, PageSize);
            Count = GetCount();

        }
 
        public void OnGetByName(string name)
        {
            DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnGetByAge(int age)
        {
            DisplayedPeople = people.Where(p => p.Age==age).ToList();
        }

        #endregion
        
    }
}