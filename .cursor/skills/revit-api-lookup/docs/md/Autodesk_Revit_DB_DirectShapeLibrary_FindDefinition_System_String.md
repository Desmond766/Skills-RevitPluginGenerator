---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.FindDefinition(System.String)
source: html/197f93e0-7577-8f1c-c039-81e4ae989a4f.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.FindDefinition Method

Find a definition by id

## Syntax (C#)
```csharp
public IList<GeometryObject> FindDefinition(
	string id
)
```

## Parameters
- **id** (`System.String`) - Definition id. Expecected to be unique

## Returns
List of geometry objects that together define a shape

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

