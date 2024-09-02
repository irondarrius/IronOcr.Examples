The `TimeoutMs` setting allows you to specify a maximum duration, in milliseconds, for the OCR operation before it is automatically stopped.

Like `AbortToken`, `TimeoutMs` is beneficial for managing the reading of large files, particularly if the process encounters an issue or hangs during execution.

It's important to mention that this functionality is not available in .NET Framework 4.x.x.