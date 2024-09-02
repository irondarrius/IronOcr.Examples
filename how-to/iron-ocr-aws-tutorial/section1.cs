using Amazon;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using SixLabors.ImageSharp;
using IronOcr;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronOcrAWSLambda;

public class Function
{
	private readonly IAmazonS3 _s3Client;
	private readonly string accessKey;
	private readonly string secretKey;

	public Function()
	{
		accessKey = "ACCESS-KEY";
		secretKey = "SECRET-KEY";
		_s3Client = new AmazonS3Client(accessKey, secretKey);
	}
	public async Task<string> FunctionHandler(string input, ILambdaContext context)
	{
		IronOcr.License.LicenseKey = "IRONOCR-LICENSE-KEY";
		string bucketName = "S3-BUCKET-NAME";

		var getObjectRequest = new GetObjectRequest
		{
			BucketName = bucketName,
			Key = input,
		};

		using (GetObjectResponse response = await _s3Client.GetObjectAsync(getObjectRequest))
		{
			// Read the content of the object
			using (Stream responseStream = response.ResponseStream)
			{
				Console.WriteLine("Reading image from S3");
				Image image = Image.Load(responseStream);

				Console.WriteLine("Reading image with IronOCR");
				IronTesseract ironTesseract = new IronTesseract();
				OcrInput ocrInput = new OcrInput(image);
				OcrResult result = ironTesseract.Read(ocrInput);

				return result.Text;
			}
		}
	}
}