---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.AddDefinition(System.String,Autodesk.Revit.DB.GeometryObject)
source: html/bd9edd01-aa2d-10d3-1d78-fb8883da3134.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.AddDefinition Method

Add a definition to be reused by instances. A definition is a single geometry object.

## Syntax (C#)
```csharp
public void AddDefinition(
	string id,
	GeometryObject GNode
)
```

## Parameters
- **id** (`System.String`) - ID of the definition to be added. Must be unique.
- **GNode** (`Autodesk.Revit.DB.GeometryObject`) - Definition as a single Geometry object

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

