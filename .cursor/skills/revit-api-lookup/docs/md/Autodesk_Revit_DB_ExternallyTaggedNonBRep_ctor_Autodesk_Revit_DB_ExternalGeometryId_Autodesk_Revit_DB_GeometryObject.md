---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedNonBRep.#ctor(Autodesk.Revit.DB.ExternalGeometryId,Autodesk.Revit.DB.GeometryObject)
source: html/3a907b7c-df51-71b3-a4cc-7da9bfdf0486.htm
---
# Autodesk.Revit.DB.ExternallyTaggedNonBRep.#ctor Method

Constructs an ExternallyTaggedGeometryObject associating a given ExternalGeometryId with
 a particular GeometryObject.

## Syntax (C#)
```csharp
public ExternallyTaggedNonBRep(
	ExternalGeometryId externalId,
	GeometryObject geometry
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The Id of the input geometry object.
- **geometry** (`Autodesk.Revit.DB.GeometryObject`) - The externally tagged geometry object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - geometry must not be a Solid.
 -or-
 geometry must not have sub-nodes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

