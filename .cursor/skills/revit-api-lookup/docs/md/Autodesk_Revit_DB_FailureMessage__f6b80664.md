---
kind: type
id: T:Autodesk.Revit.DB.FailureMessage
source: html/d0795bd6-f092-90f2-5c2c-3876e616454c.htm
---
# Autodesk.Revit.DB.FailureMessage

Represents a message describing a failure of an operation in Revit.

## Syntax (C#)
```csharp
public class FailureMessage : IDisposable
```

## Remarks
Failure messages are typically shown to the user in the Revit error dialog.
 This class contains the following information about the failures:
 The basic description of the failure (retrieved from the FailureDefinition) The available resolutions for the failure. The elements related to the failure.

