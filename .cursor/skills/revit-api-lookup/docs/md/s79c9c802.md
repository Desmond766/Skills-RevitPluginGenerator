---
kind: type
id: T:Autodesk.Revit.DB.FailureResolution
source: html/8075460b-afbf-6558-b402-b1f75fdf2412.htm
---
# Autodesk.Revit.DB.FailureResolution

Defines a resolution for a failure.

## Syntax (C#)
```csharp
public class FailureResolution : IDisposable
```

## Remarks
A failure could have several permitted resolutions. List of applicable resolution types for the specific failure
 is defined by the FailureDefinition, actual FailureResolutions are instantiated with the FailureMessage before it is posted.
 Multiple resolutions per failure are allowed, although Revit UI only uses default resolution.

