using System;
using System.Collections.Generic;
using System.Text;
using Practica3.Models;

namespace Practica3.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public GridModel BarAndHotelsMenuOption { get; set; } = new GridModel();
        public HomeViewModel ()
        {
            BarAndHotelsMenuOption.Title = "Bar and Hotels";
        }



    }
}
