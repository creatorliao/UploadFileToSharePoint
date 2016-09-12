using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client; // NuGet Package: Microsoft.SharePoint.Client.Online.CSOM Version 15.0.4763.1000

namespace UpLoadFileToSharePoint
{
    public partial class UpLoadFileToSharePoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void ButtonUploadFile(object sender, EventArgs e)
        { 
            try
            {
                if ((file.PostedFile != null) && (file.PostedFile.ContentLength > 0))
                {
                    string newFileName = System.IO.Path.GetFileName(file.PostedFile.FileName);
                    string fileContentType = file.PostedFile.ContentType; //to know ContentType file 
                    String sharePointSite = "https://YOUR_SHAREPOINT_SITE.sharepoint.com";
                    byte[] fileBytes = new byte[file.PostedFile.ContentLength];
                    file.PostedFile.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.PostedFile.ContentLength));
                    using (var context = new ClientContext(sharePointSite))
                    {
                        var passWord = new SecureString();
                        foreach (var c in "PASSWORD") passWord.AppendChar(c);
                        context.Credentials = new SharePointOnlineCredentials("USER", passWord);
                        var web = context.Web;
                        var newFile = new FileCreationInformation
                        {
                            Content = fileBytes,
                            Overwrite = true,
                            Url = System.IO.Path.GetFileName(newFileName)
                        };

                        var targetFolder = context.Web.GetFolderByServerRelativeUrl("/storage_library/YOUR_FOLDER");
                        var uploadFile = targetFolder.Files.Add(newFile);
                        context.Load(uploadFile);
                        context.ExecuteQuery();
                        LabelResult.Text = "File Uploaded";
                    }

                }
                else
                {
                    LabelResult.Text = "File didn´t upload";
                    System.Diagnostics.Debug.WriteLine("File didn´t upload");
                }
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error", ex);
            }
        }
    }
}