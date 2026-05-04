---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AreOptionsValid(Autodesk.Revit.DB.DirectShapeOptions)
source: html/d613f35a-83ad-cc32-25a9-449b9ba04723.htm
---
# Autodesk.Revit.DB.DirectShape.AreOptionsValid Method

Validates that the given DirectShapeOptions are allowed for this particular DirectShape.

## Syntax (C#)
```csharp
public bool AreOptionsValid(
	DirectShapeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeOptions`) - The options object.

## Returns
True if the DirectShapeOptions are valid; false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

