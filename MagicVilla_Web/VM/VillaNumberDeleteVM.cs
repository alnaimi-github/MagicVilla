using MagicVilla_Web.Dto.VillaNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.VM
{
    public class VillaNumberDeleteVM
    {
        public VillaNumberDeleteVM()
        {
            VillaNumber = new VillaNumberDto();
        }
        public VillaNumberDto VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>villaList { get; set; }
    }
}
