---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AreOptionsValid(Autodesk.Revit.DB.DirectShapeTypeOptions)
source: html/1d5fdef2-42ba-9857-6c20-ee9b6e7eb79d.htm
---
# Autodesk.Revit.DB.DirectShapeType.AreOptionsValid Method

Validates that the given DirectShapeTypeOptions are allowed for this particular DirectShapeType.

## Syntax (C#)
```csharp
public bool AreOptionsValid(
	DirectShapeTypeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeTypeOptions`) - The options object.

## Returns
True if the DirectShapeTypeOptions are valid; false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

