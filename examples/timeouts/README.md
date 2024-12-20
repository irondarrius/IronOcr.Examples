***Based on <https://ironsoftware.com/examples/timeouts/>***

`TimeoutMs` offers an optional timeout measure in milliseconds, which cancels the OCR read operation if it exceeds the specified duration.

Like the `AbortToken`, `TimeoutMS` is particularly useful for handling large input files during instances when the program or application becomes non-responsive.

It's important to mention that this functionality is not available in .NET Framework 4.x.x.