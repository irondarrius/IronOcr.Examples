# Implementing Document Reading with IronOcr on AWS Lambda

***Based on <https://ironsoftware.com/how-to/iron-ocr-aws-tutorial/>***


This tutorial provides an overview on how to configure AWS Lambda to utilize IronOCR for document reading tasks, specifically from an S3 Bucket.

## 1. Initialize a Containerized AWS Lambda

To run IronOcr effectively, it is essential to install certain dependencies on the environment. To facilitate this, you should employ a containerized approach for your Lambda function.

You can create a containerized Lambda effortlessly using Visual Studio. First, install the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/). Choose an AWS Lambda C# project, select the **Container Image** as the template, and conclude by clicking "Finish".

## 2. Update Project Dependencies

Amend the Dockerfile in your project as below:

```dockerfile
# Adjust according to your needs: dotnet:5 or dotnet:6 for respective .NET versions.

***Based on <https://ironsoftware.com/how-to/iron-ocr-aws-tutorial/>***

FROM public.ecr.aws/lambda/dotnet:7

WORKDIR /var/task

# Update the packages list and install required libraries.

***Based on <https://ironsoftware.com/how-to/iron-ocr-aws-tutorial/>***

RUN yum update -y
RUN yum install -y amazon-linux-extras
RUN amazon-linux-extras install epel -y
RUN yum install -y libgdiplus

# Copy your build output directory here.

***Based on <https://ironsoftware.com/how-to/iron-ocr-aws-tutorial/>***

COPY "bin/Release/lambda-publish" .
```

## 3. Incorporate IronOcr NuGet Packages

To add `IronOcr` and `IronOcr.Linux` to your project in Visual Studio:

1. Navigate to `Project > Manage NuGet Packages...`
2. Click on `Browse`, type in `IronOcr` and `IronOcr.Linux`, then proceed to install the located packages.

## 4. Adapt the FunctionHandler Code

This snippet demonstrates retrieving and reading an image from an S3 bucket. Ensure the setup of your bucket and installation of the [SixLabors.ImageSharp](https://www.nuget.org/packages/SixLabors.ImageSharp) package beforehand.

```cs
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
	private readonly string accessKey = "ACCESS-KEY";
	private readonly string secretKey = "SECRET-KEY";
	private readonly IAmazonS3 _s3Client = new AmazonS3Client(accessKey, secretKey);

	public async Task<string> FunctionHandler(string input, ILambdaContext context)
	{
		IronOcr.License.LicenseKey = "IRONOCR-LICENSE-KEY";
		const string bucketName = "S3-BUCKET-NAME";

		var getObjectRequest = new GetObjectRequest
		{
			BucketName = bucketName,
			Key = input,
		};

		using (var response = await _s3Client.GetObjectAsync(getObjectRequest))
		{
			using (Stream responseStream = response.ResponseStream)
			{
				Console.WriteLine("Fetching image from S3");
				Image image = Image.Load(responseStream);

				Console.WriteLine("Processing image with IronOCR");
				var ironTesseract = new IronTesseract();
				var ocrInput = new OcrInput(image);
				var result = ironTesseract.Read(ocrInput);

				return result.Text;
			}
		}
	}
}
```

## 5. Configure Memory and Execution Timeout Settings

Depending on the document size, adjust memory size and timeout settings in `aws-lambda-tools-defaults.json`:

```json
{
  "function-memory-size": 512,
  "function-timeout": 300
}
```

## 6. Deploy to AWS Lambda

In Visual Studio, right-click the solution and choose `Publish to AWS Lambda...`. Configure settings accordingly. More details can be found on the [AWS Lambda deployment guide](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-creating-project-in-visual-studio.html#publish-to-lambda).

## 7. Test Your Configuration

Test the Lambda function through the AWS Lambda management console or directly from Visual Studio to ensure everything is set up properly.