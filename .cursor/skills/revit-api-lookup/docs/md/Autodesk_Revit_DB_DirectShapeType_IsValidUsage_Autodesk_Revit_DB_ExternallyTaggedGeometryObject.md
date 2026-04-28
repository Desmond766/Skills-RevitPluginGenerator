---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidUsage(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/348236e2-020c-d809-df06-6987721b3abb.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidUsage Method

Validates that the ExternallyTaggedGeometryObject's usage is set to an allowed value for a DirectShapeType.

## Syntax (C#)
```csharp
public bool IsValidUsage(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The geometry to check.

## Returns
True if the usage is permitted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

