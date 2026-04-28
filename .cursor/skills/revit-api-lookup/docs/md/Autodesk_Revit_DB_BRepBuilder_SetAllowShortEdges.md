---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.SetAllowShortEdges
source: html/2e0f0e48-a219-7abe-96c4-b755cb5b687b.htm
---
# Autodesk.Revit.DB.BRepBuilder.SetAllowShortEdges Method

Make BRepBuilder allow edges that it would normally disallow as being too short for Revit geometry.

## Syntax (C#)
```csharp
public void SetAllowShortEdges()
```

## Remarks
When used, this function must be called before any geometry is defined (e.g., just after constructing a BRepBuilder object).
 Geometry with short edges may not be as reliable as fully valid geometry.
 This option is intended to allow the construction of geometry such as mechanical items with small features
 that is not expected to interact much with other Revit elements.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This function was called after the geometry had been defined (e.g. by calls to addFace).

