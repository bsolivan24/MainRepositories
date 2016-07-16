using System.Web.Mvc;
using VolumeCalculatorWebApp.Models;
using System.Threading.Tasks;


namespace VolumeCalculatorWebApp.Controllers
{
    public class VolumeCalculatorController : Controller
    {
        // GET: VolumeCalculator
        public ActionResult VolumeCalculator()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CalculateCylinder(VolumeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState["CylinderProperties.Volume"].Value = null;
                model.CylinderProperties.Volume = 123.ToString();
            }

            // If we got this far, something failed, redisplay form
            var result = View("VolumeCalculator", model);
            return result;
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CalculateCone(VolumeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState["ConeProperties.Volume"].Value = null;
                model.ConeProperties.Volume = 123.ToString();
            }

            // If we got this far, something failed, redisplay form
            var result = View("VolumeCalculator", model);
            return result;
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CalculateSphere(VolumeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState["SphereProperties.Volume"].Value = null;
                model.SphereProperties.Volume = 123.ToString();
            }

            // If we got this far, something failed, redisplay form
            var result = View("VolumeCalculator", model);
            return result;
        }

    }
}