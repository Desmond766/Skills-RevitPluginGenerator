---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetDividedSurfaceForReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/718252c3-faac-2f25-ec76-ca2a027c663a.htm
---
# Autodesk.Revit.DB.DividedSurface.GetDividedSurfaceForReference Method

Get a divided surface for a given reference. Returns null if the reference does not host a divided surface.

## Syntax (C#)
```csharp
public static DividedSurface GetDividedSurfaceForReference(
	Document document,
	Reference faceReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **faceReference** (`Autodesk.Revit.DB.Reference`) - Reference that represents a face.

## Returns
The newly created divided surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

