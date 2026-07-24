using System;
using System.Collections.Generic;

namespace NBoard.Models
{
    public class Document
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<Page> Pages { get; set; }
        public string FilePath { get; set; }

        public Document()
        {
            Id = Guid.NewGuid().ToString();
            Name = "Untitled Document";
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Pages = new List<Page> { new Page() };
            FilePath = string.Empty;
        }

        public Document(string name) : this()
        {
            Name = name;
        }
    }

    public class Page
    {
        public int Id { get; set; }
        public List<DrawingAction> Actions { get; set; }

        public Page()
        {
            Id = DateTime.Now.Millisecond;
            Actions = new List<DrawingAction>();
        }
    }
}