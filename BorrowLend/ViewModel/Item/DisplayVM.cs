using Microsoft.AspNetCore.Mvc.Rendering;
using BorrowLend.Entity;
using System.ComponentModel;
using BorrowLend.ViewModel.Shared;

namespace BorrowLend.ViewModel.ItemVM
{
    public class DisplayVM
    {
        public List<Item> ItemsList { get; set; }
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }
    }
}
