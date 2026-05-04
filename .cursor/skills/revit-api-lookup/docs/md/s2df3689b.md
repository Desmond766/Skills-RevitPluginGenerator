---
kind: type
id: T:Autodesk.Revit.DB.FailuresAccessor
source: html/dea68b06-a061-fc05-d814-db741f2e7f14.htm
---
# Autodesk.Revit.DB.FailuresAccessor

An interface class that provides access to failure information posted in a document and methods to resolve these failures.

## Syntax (C#)
```csharp
public class FailuresAccessor : IDisposable
```

## Remarks
An instance of this class can be obtained only as an argument passed to interfaces used in the process of failure resolution
 and is the only available interface to fetch information about failures in a document.
 While reading from a document during failure processing is allowed, the only way to modify document during failure resolution is via methods
 provided by this class.
 After returning from failure processing, the instance of the class is deactivated and cannot be used any longer.

