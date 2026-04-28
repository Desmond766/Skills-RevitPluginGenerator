---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.RemoveReferenceObject(System.String)
source: html/9ac53791-dc38-76b1-28a4-e074011ff0ac.htm
---
# Autodesk.Revit.DB.DirectShapeType.RemoveReferenceObject Method

Removes any reference objects with the given name from the DirectShapeType.
 Nothing is done if no reference objects have the given name or if the name is the empty string.

## Syntax (C#)
```csharp
public void RemoveReferenceObject(
	string refName
)
```

## Parameters
- **refName** (`System.String`) - The name of the reference object(s) to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

