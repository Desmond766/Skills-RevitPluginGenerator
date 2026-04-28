---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddExternallyTaggedGeometry(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/2c551429-8b90-ed46-3e29-a6b3dbc1cb95.htm
---
# Autodesk.Revit.DB.DirectShape.AddExternallyTaggedGeometry Method

Adds the externally tagged geometry object to the DirectShape.

## Syntax (C#)
```csharp
public void AddExternallyTaggedGeometry(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The externally tagged geometry that should be added to the DirectShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input shape does not satisfy DirectShape validation criteria.
 -or-
 The input geometry does not have a permitted usage.
 -or-
 The externallyTaggedGeometry has already been added to this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

