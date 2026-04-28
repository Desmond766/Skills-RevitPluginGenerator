---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.UpdateExternallyTaggedGeometry(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/c15c6964-0514-7c53-fdf0-9900ec68636f.htm
---
# Autodesk.Revit.DB.DirectShape.UpdateExternallyTaggedGeometry Method

Updates the externally tagged geometry object in the DirectShape.

## Syntax (C#)
```csharp
public void UpdateExternallyTaggedGeometry(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The externally tagged geometry that should be updated in the DirectShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input shape does not satisfy DirectShape validation criteria.
 -or-
 A previous version of the externally tagged geometry is not present in this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

