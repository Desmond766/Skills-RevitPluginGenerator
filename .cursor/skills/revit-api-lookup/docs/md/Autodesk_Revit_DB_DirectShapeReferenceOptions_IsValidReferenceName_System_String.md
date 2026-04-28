---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidReferenceName(System.String)
source: html/4ecec12f-10ee-cb15-9917-b41dd0e39cb2.htm
---
# Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidReferenceName Method

Validates that the input name can be assigned to a direct shape reference.

## Syntax (C#)
```csharp
public static bool IsValidReferenceName(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name to assign to the reference.

## Returns
True if the input name is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

