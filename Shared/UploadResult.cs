using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileUpload.Shared
{
    public class UploadResult
    {
        public bool Uploaded { get; set; }
        public string FileName { get; set; } = String.Empty;
        public string StoredFileName { get; set; } = String.Empty;
        public int ErrorCode { get; set; }
    }
}
