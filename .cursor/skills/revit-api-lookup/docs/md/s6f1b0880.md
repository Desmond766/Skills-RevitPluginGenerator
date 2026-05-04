---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.AddDefinition(System.String,System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/08cb25e6-8a3f-ba50-486d-272d6d29add9.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.AddDefinition Method

Add a definition to be reused by instances. A definition is a collection of geometry objects.

## Syntax (C#)
```csharp
public void AddDefinition(
	string id,
	IList<GeometryObject> GNodes
)
```

## Parameters
- **id** (`System.String`) - ID of the definition to be added. Must be unique.
- **GNodes** (`System.Collections.Generic.IList < GeometryObject >`) - Definition as a list of Geometry objects

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

