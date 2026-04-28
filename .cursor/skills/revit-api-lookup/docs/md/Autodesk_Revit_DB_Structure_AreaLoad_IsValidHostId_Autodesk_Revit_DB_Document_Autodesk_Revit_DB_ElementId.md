---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.IsValidHostId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/25e62c90-a5b5-09d5-9c49-03058e5e51b0.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.IsValidHostId Method

Indicates if the provided host id can host area loads
 The document containing both the host and the load
 The id of the analytical element that is about to host an area load
 True if an area load can be placed on the input host id

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

