---
kind: method
id: M:Autodesk.Revit.DB.Part.ResetFaceOffset(Autodesk.Revit.DB.Face)
source: html/6e715369-6f25-adec-e331-25f43d9a75fd.htm
---
# Autodesk.Revit.DB.Part.ResetFaceOffset Method

Resets the offset applied to the given part face.

## Syntax (C#)
```csharp
public void ResetFaceOffset(
	Face face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face whose offset needs to be reset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - face does not belong to the part.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

