---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.FindDefinitionType(System.String)
source: html/c1a53b64-8ceb-e144-3f68-561c6f62a165.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.FindDefinitionType Method

Find a DirectShapeType element by definition id. The element will be used for creating instances of that definition.

## Syntax (C#)
```csharp
public ElementId FindDefinitionType(
	string id
)
```

## Parameters
- **id** (`System.String`) - Definition id. Expected to be unique.

## Returns
Element id of a DirectShapeTypeElement

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

