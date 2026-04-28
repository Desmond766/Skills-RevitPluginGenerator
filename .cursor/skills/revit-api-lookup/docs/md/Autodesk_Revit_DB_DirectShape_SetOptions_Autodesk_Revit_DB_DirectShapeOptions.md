---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.SetOptions(Autodesk.Revit.DB.DirectShapeOptions)
source: html/a7163c75-af77-624c-ca60-e5271827c03f.htm
---
# Autodesk.Revit.DB.DirectShape.SetOptions Method

Sets the options to use for this DirectShape.

## Syntax (C#)
```csharp
public void SetOptions(
	DirectShapeOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.DirectShapeOptions`) - Options to use for this DirectShape.

## Remarks
The new options take effect immediately.
 If this DirectShape relies on a DirectShapeType for references, the options stored in DirectShapeType take precedence.
 Note that changing options affects how the object interacts with Revit. E.g., switching references off will disable
 existing constraints applied to that object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The DirectShapeOptions provided are not valid for this DirectShape.
 -or-
 The DirectShapeOptions provided are not valid for this transient DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

