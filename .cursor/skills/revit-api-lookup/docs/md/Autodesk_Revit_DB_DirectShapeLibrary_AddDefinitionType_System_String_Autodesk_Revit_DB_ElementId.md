---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.AddDefinitionType(System.String,Autodesk.Revit.DB.ElementId)
source: html/2cdbc926-c1f1-d6f3-f37d-e75d1a0e0e1b.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.AddDefinitionType Method

Add a definition to be reused by instances. Adding a definition type will change how the instances are created.
 When asked to create a definition, the library object will look for a corresponding type object.
 If one is found, it will create an instance of geometry stored in the type object. If it is not found,
 the library will look for a list of geometry objects stored as definition, and will copy and transform these
 to create an instance.

## Syntax (C#)
```csharp
public void AddDefinitionType(
	string id,
	ElementId typeId
)
```

## Parameters
- **id** (`System.String`) - ID of the definition to be added. Must be unique.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Element id of the DirectShapeType element that will be used as a definition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

