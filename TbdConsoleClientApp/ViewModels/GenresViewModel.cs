using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbdConsoleClientApp.ViewModels
{
    internal class GenresViewModel
    {
        public int genreId { get; set; }
        public string title { get; set; }



        public List<GenresViewModel> genres { get; set; }
    }
}
