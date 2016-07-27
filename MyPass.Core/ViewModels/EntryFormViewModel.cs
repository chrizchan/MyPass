using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MyPass.Core.Models;

namespace MyPass.Core.ViewModels
{
    public class EntryFormViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Desription { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}