---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidUsage(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/66c74377-1553-5b90-45d7-14f24a53eede.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidUsage Method

Validates that the ExternallyTaggedGeometryObject's usage is set to an allowed value for a DirectShape.

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

