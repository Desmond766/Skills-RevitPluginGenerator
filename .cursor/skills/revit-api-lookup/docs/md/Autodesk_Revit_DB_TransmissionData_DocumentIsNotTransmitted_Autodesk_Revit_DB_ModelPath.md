---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.DocumentIsNotTransmitted(Autodesk.Revit.DB.ModelPath)
source: html/b64eb87e-2c2a-2510-ae8b-a3046e5ecf40.htm
---
# Autodesk.Revit.DB.TransmissionData.DocumentIsNotTransmitted Method

Determines whether the document at a given file location
 is not transmitted.

## Syntax (C#)
```csharp
public static bool DocumentIsNotTransmitted(
	ModelPath filePath
)
```

## Parameters
- **filePath** (`Autodesk.Revit.DB.ModelPath`) - The path to the document whose transmitted state will be checked.

## Returns
False if the document is a transmitted file, true otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

