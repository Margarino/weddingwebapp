using OfficeOpenXml;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using weddingWebapp.DataAccess.DataObjects;
namespace weddingWebapp
{
    public class ExcelController
    {
        public async Task exportTable()
        { 
            matrimak_Context context = new matrimak_Context();
            var memoryStream = new MemoryStream();


            var data = context.Regalos.ToArray();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Lista Regalos");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            excel.SaveAs(memoryStream);
            memoryStream.Position = 0;
            string filename = "Lista de regalos.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //return File(memoryStream,contentType, filename);


        }
    }
}




/*/
 * 
public IActionResult pushToTable()  //pushes current regalo to array and then to memory stream
{
    matrimak_Context contex = new matrimak_Context();
    var memoryStream = new MemoryStream();
    var data = contex.Regalos.ToArray();
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //you greedy fucks
    ExcelPackage excel = new ExcelPackage();
    var workSheet = excel.Workbook.Worksheets.Add("Lista Regalos");
    workSheet.Cells[1, 1].LoadFromCollection(data, true);
    excel.SaveAs(memoryStream);
    memoryStream.Position = 0;
    string filename = "Lista Regalos.xlsx";
    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    return File(memoryStream, contentType, filename);

}

/*/