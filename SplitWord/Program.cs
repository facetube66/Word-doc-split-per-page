using System.IO;
using SautinSoft.Document;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SplitDocumentByPages();
        }

        static void SplitDocumentByPages()
        {
            string filePath = "F://sample_102.docx";
            //string myKey = "1234567890";
            //DocumentCore.Serial = myKey;

            DocumentCore dc = DocumentCore.Load(filePath);
            string folderPath = Path.GetFullPath(@"Result-files");
            DocumentPaginator dp = dc.GetPaginator();
            for (int i = 0; i < dp.Pages.Count; i++)
            {
                DocumentPage page = dp.Pages[i];
                Directory.CreateDirectory(folderPath);

                // Save the each page to PDF format.
                page.Save(folderPath + @"\Page - " + i.ToString() + ".txt", SaveOptions.TxtDefault);
            }
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(folderPath) { UseShellExecute = true });
        }
    }
}