---
kind: method
id: M:Autodesk.Revit.DB.Part.GetFaceOffset(Autodesk.Revit.DB.Face)
source: html/a4bb499a-8705-5138-0e15-74fb5bc4508b.htm
---
# Autodesk.Revit.DB.Part.GetFaceOffset Method

Get face offset of the given part face.

## Syntax (C#)
```csharp
public double GetFaceOffset(
	Face face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face whose offset is required.

## Returns
Returns the value of the offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - face does not belong to the part.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

