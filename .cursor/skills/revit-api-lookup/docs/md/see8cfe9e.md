---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.RemoveReferenceObject(System.String)
source: html/fcb98055-956d-0e3f-cda6-056411311ad8.htm
---
# Autodesk.Revit.DB.DirectShape.RemoveReferenceObject Method

Removes any reference objects with the given name from the DirectShape.
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

