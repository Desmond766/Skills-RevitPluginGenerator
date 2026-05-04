---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.IsDocumentTransmitted(Autodesk.Revit.DB.ModelPath)
source: html/3f9fd4b7-147e-a342-e257-394c0ea41de8.htm
---
# Autodesk.Revit.DB.TransmissionData.IsDocumentTransmitted Method

Determines whether the document at a given file location
 is transmitted.

## Syntax (C#)
```csharp
public static bool IsDocumentTransmitted(
	ModelPath filePath
)
```

## Parameters
- **filePath** (`Autodesk.Revit.DB.ModelPath`) - The path to the document whose transmitted state will be checked.

## Returns
True if the document is a transmitted file, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

