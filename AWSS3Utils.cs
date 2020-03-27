using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;

namespace HR_To_AWS
{
    class AWSS3Utils
    {
        private const string bucketName = "wwwklient";
        private const string keyName = "emp_From_base.csv";
        private string filePath = "";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;
        private static IAmazonS3 s3Client;

        public void AsyncUpload(string filePathParam)
        {
            filePath = filePathParam;
            s3Client = new AmazonS3Client(bucketRegion);
            UploadFileAsync();
        }

        private async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility =
                    new TransferUtility(s3Client);

                // Option 3. Upload data from a type of System.IO.Stream.
                using (var fileToUpload =
                    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    await fileTransferUtility.UploadAsync(fileToUpload,
                                               bucketName, keyName);
                }
                Console.WriteLine("Upload 3 completed");

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}
