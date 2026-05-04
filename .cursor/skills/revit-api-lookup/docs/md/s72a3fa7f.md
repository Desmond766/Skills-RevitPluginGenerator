---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexFormat.IsValid
source: html/275a7383-ac5e-7964-a72d-1355d9b1b769.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexFormat.IsValid Method

Tests whether the vertex format specification is valid for rendering.

## Syntax (C#)
```csharp
public bool IsValid()
```

## Returns
True if the vertex format specification is valid for rendering, false otherwise.

## Remarks
The vertex format specifications are internally associated with low-level graphics state and may become invalidated when
 the state changes. Therefore, an application should test each vertex format object for validity before using it when
 submitting geometry. If the vertex format object becomes invalid, the application should re-create it.

