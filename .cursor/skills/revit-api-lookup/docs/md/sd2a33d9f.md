---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.SetOptions(Autodesk.Revit.DB.DirectShapeTypeOptions)
source: html/a7ef3f68-713f-5adc-caf9-dcee1e46efb1.htm
---
# Autodesk.Revit.DB.DirectShapeType.SetOptions Method

Sets the options to use for this DirectShapeType.

## Syntax (C#)
```csharp
public void SetOptions(
	DirectShapeTypeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeTypeOptions`) - Options to use for this DirectShapeType.

## Remarks
The new options take effect immediately.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The DirectShapeTypeOptions provided are not valid for this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

