---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.GetResult(Autodesk.Revit.DB.ExternalGeometryId,Autodesk.Revit.DB.BRepBuilderPersistentIds)
source: html/b72c5abd-629e-96aa-0b87-95b5cc763f80.htm
---
# Autodesk.Revit.DB.BRepBuilder.GetResult Method

Get the Geometry object built by this BRepBuilder. This will clear the built Geometry stored in the BRepBuilder.
 This function will throw if this BRepBuilder hasn't completed building the b-rep. Use IsResultAvailable() to verify that this BRepBuilder contains a valid result.

## Syntax (C#)
```csharp
public ExternallyTaggedBRep GetResult(
	ExternalGeometryId externalId,
	BRepBuilderPersistentIds brepPersistentIds
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external Id of the Geometry object built by this BRepBuilder.
- **brepPersistentIds** (`Autodesk.Revit.DB.BRepBuilderPersistentIds`) - An object storing the relationship between ExternalGeometryIds and BRepBuilderGeometryIds.

## Returns
The Geometry object built by this BRepBuilder.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one BRepBuilderGeometryId in the supplied BRepBuilderPersistentIds map could not be found in this BRepBuilder object.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object hasn't completed building data or was unsuccessful building it. Built Geometry is unavailable.
 In order to access the built Geometry, Finish() must be called first. That will set the state to completed.

