using Emergent.Software;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Emergent.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISoftwareManager _softwareManager;
        public IEnumerable<Emergent.Software.Software> SoftwareList { get; set; }
        public string CurrentFilterString { get; set; } = string.Empty;

        public IndexModel(ISoftwareManager softwareManager)
        {
            _softwareManager = softwareManager;
        }

        public void OnGet()
        {
            SoftwareList = _softwareManager.GetSoftwareList();
        }

        [BindProperty] public int Major { get; set; }
        [BindProperty] public int Minor { get; set; }
        [BindProperty] public int Patch { get; set; }

        public void OnPost()
        {
            var version = new Software.Version(Major, Minor, Patch);
            SoftwareList = _softwareManager.GetGreaterVersionNumbers(version);
            CurrentFilterString = version.ToString();
        }
    }
}
