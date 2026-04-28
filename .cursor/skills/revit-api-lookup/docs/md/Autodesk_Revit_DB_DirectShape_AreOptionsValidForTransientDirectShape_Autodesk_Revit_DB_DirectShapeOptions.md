---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AreOptionsValidForTransientDirectShape(Autodesk.Revit.DB.DirectShapeOptions)
source: html/83b95bbf-6e6d-25ab-053b-441447ac389f.htm
---
# Autodesk.Revit.DB.DirectShape.AreOptionsValidForTransientDirectShape Method

Validates that the given DirectShapeOptions are allowed if this DirectShape is transient.

## Syntax (C#)
```csharp
public bool AreOptionsValidForTransientDirectShape(
	DirectShapeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeOptions`) - The options object.

## Returns
True if the DirectShapeOptions are valid; false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

