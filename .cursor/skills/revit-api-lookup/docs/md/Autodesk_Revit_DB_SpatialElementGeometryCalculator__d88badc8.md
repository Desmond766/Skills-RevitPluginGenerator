---
kind: type
id: T:Autodesk.Revit.DB.SpatialElementGeometryCalculator
source: html/c0132067-6444-1dd6-a25c-690fb5dd7d9e.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator

Use this class to calculate the geometry of a spatial element and obtain the relationships between the geometry and
 the element's boundary elements.

## Syntax (C#)
```csharp
public class SpatialElementGeometryCalculator : IDisposable
```

## Remarks
This class maintains an internal cache for geometry it has already processed. If you intend to calculate geometry
 for several elements in the same project you should use a single instance of this class. Note that the cache will
 be cleared when any change is made to the document.

