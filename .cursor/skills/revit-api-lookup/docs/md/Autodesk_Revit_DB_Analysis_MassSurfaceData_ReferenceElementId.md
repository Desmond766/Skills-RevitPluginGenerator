---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.ReferenceElementId
source: html/771ae7d7-0977-660c-1881-6fba10dd6a1f.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.ReferenceElementId Property

The ElementId of the element whose face the MassSurfaceData primarily refers to.

## Syntax (C#)
```csharp
public ElementId ReferenceElementId { get; }
```

## Remarks
A MassSurfaceData may represent multiple faces from the same or different elements. This generally
 only happens if the faces are geometrically fully coincident and logically represent
 a single building object. "Interior walls" of the conceptual energy building model is a common
 example where two different faces may be represented by a single MassSurfaceData.

