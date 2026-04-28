---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.IsValidHostId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/f294365b-5eee-57c0-ad6a-cbdd7bd7637f.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.IsValidHostId Method

Indicates if the provided host id can host line loads
 The document containing both the host and the load
 The id of the analytical element that is about to host a line load
 True if a line load can be placed on the input host id

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

