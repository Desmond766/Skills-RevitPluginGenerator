---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.UpdateExternallyTaggedGeometry(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/0acd0330-9e79-8be8-ff3c-740ed053ea82.htm
---
# Autodesk.Revit.DB.DirectShapeType.UpdateExternallyTaggedGeometry Method

Updates the externally tagged geometry object in the DirectShapeType.

## Syntax (C#)
```csharp
public void UpdateExternallyTaggedGeometry(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The externally tagged geometry that should be updated in the DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input shape does not satisfy DirectShapeType validation criteria.
 -or-
 A previous version of the externally tagged geometry is not present in this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

