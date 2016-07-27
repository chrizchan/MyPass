using System.Collections;
using System.Collections.Generic;
using MyPass.Core.Models;

namespace MyPass.Core.ViewModels
{
    public class EntryFormViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}