using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DefineXAjaxOdev.Controllers
{
    public class ProductsController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult SyncUrunGetir( string qUrunAdi)
		{
			List<string> qDonus = new List<string>();
			DataTable qTablo = new DataTable();
			SqlConnection qcon = new SqlConnection("Server=DESKTOP-670OPH6\\FARUKSDB;Database=DefineXOdev;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
			qcon.Open();
			SqlDataAdapter qadap = new SqlDataAdapter(String.Format("SELECT * FROM Products WHERE Name LIKE '%{0}%'", qUrunAdi), qcon.ConnectionString);
			qadap.Fill(qTablo);
			qcon.Close();
			foreach (DataRow dr in qTablo.Rows)
			{
				qDonus.Add(dr["Name"].ToString());
			}
			return Json(qDonus);
		}
	}
}
