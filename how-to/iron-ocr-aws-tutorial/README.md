# Utilizing IronOcr on AWS Lambda for Document Reading

This tutorial will guide you in configuring an AWS Lambda function to use IronOCR for reading documents stored in an S3 Bucket. Follow these steps to set up IronOCR on AWS Lambda efficiently.

## 1. Set Up AWS Lambda Using a Container Template

IronOcr requires specific dependencies, which necessitate containerizing your Lambda function.

To create a containerized AWS Lambda using Visual Studio, first, install the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/). Then, choose a C# AWS Lambda template, opt for a **Container Image** blueprint, and click "Finish".

## 2. Update Package Dependencies

Edit your project's Dockerfile as follows:

```dockerfile
# Use dotnet:7 for .NET version 7
FROM public.ecr.aws/lambda/dotnet:7

WORKDIR /var/task

# Update installed packages
RUN yum update -y

# Install necessary dependencies
RUN yum install -y amazon-linux-extras
RUN amazon-linux-extras install epel -y
RUN yum install -y libgdiplus

# Copy binaries for Lambda from build output
COPY "bin/Release/lambda-publish" .
```

## 3. Add IronOcr NuGet Packages

In Visual Studio, to incorporate the `IronOcr` and `IronOcr.Linux` NuGet packages:

1. Navigate to `Project > Manage NuGet Packages...`
2. Choose `Browse` and search for `IronOcr` and `IronOcr.Linux`.
3. Install the selected packages.

## 4. Adjust the FunctionHandler Implementation

The following code snippet demonstrates fetching and processing an image from an S3 Bucket for OCR with IronOcr. Ensure that the S3 bucket is prepared and the [SixLabors.ImageSharp](https://www.nuget.org/packages/SixLabors.ImageSharp) package is installed:

```csharp
using Amazon;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using SixLabors.ImageSharp;
using IronOcr;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronOcrAWSLambda;

public class Function
{
	private readonly IAmazonS3 _s3Client;
	private readonly string accessKey = "ACCESS-KEY";
	private readonly string secretKey = "SECRET-KEY";

	public Function()
	{
		_s3Client = new AmazonS3Client(accessKey, secretKey);
	}

	public async Task<string> FunctionHandler(string input, ILambdaContext context)
	{
		IronOcr.License.LicenseKey = "IRONOCR-LICENSE-KEY";
		string bucketName = "S3-BUCKET-NAME";

		var getObjectRequest = new GetObjectRequest
		{
			BucketName = bucketName,
			Key = input
		};

		using (GetObjectResponse response = await _s3Client.GetObjectAsync(getObjectRequest))
		{
			using (Stream responseStream = response.ResponseStream)
			{
				Console.WriteLine("Loading image from S3.");
				Image image = Image.Load(responseStream);

				Console.WriteLine("Processing OCR with IronOCR.");
				IronTesseract ironTesseract = new IronTesseract();
				OcrInput ocrInput = new OcrInput(image);
				OcrResult result = ironTesseract.Read(ocrInput);

				return result.Text;
			}
		}
	}
}
```

## 5. Configure Memory and Timeout Settings

Allocate sufficient memory and set an appropriate timeout for the Lambda function based on your document processing needs. Recommended settings to start with:

```json
"function-memory-size" : 512,
"function-timeout" : 300
```

## 6. Deployment

To deploy your application, right-click the solution in Visual Studio and select `Publish to AWS Lambda...`. Configure the necessary settings. For detailed instructions on publishing, visit the [AWS Website](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-creating-project-in-visual-studio.html#publish-to-lam).

## 7. Activation and Testing

Activate and test your Lambda function using either the [Lambda console](https://console.aws.amazon.com/lambda) or directly from Visual Studio.