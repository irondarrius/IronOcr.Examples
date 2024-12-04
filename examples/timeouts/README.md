***Based on <https://ironsoftware.com/examples/timeouts/>***

`TimeoutMs` offers an optional timeout setting, specified in milliseconds, that cancels the OCR reading task if it exceeds the defined period.

Like `AbortToken`, `TimeoutMs` aids in managing the reading of extensive input files, especially helpful if the process halts during runtime.

It's important to highlight that this functionality is not available in .NET Framework 4.x.x.