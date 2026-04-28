---
kind: method
id: M:Autodesk.Revit.DB.Structure.PointLoad.IsValidHostId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/c5304968-914f-7e7e-ea26-ffd6e1dee6d5.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.IsValidHostId Method

Indicates if the provided host id can host point loads
 The document containing both the host and the load
 The id of the analytical element that is about to host a point load
 True if a point load can be placed on the input host id

## Syntax (C#)
```csharp
public static bool IsValidHostId(
	Document pDoc,
	ElementId hostId
)
```

## Parameters
- **pDoc** (`Autodesk.Revit.DB.Document`)
- **hostId** (`Autodesk.Revit.DB.ElementId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

