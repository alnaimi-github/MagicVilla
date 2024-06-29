using MagicVilla_Web.Dto.VillaNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.VM
{
    public class VillaNumberCreateVM
    {
        public VillaNumberCreateVM()
        {
            VillaNumber = new();
        }
        public VillaNumberCreateDto VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>villaList { get; set; }
    }
}
