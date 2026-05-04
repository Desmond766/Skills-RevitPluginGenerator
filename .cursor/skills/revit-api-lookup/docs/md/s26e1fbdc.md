---
kind: property
id: P:Autodesk.Revit.DB.Options.View
zh: 视图
source: html/cea72f89-cfd1-f5cb-f61d-bf047df2681b.htm
---
# Autodesk.Revit.DB.Options.View Property

**中文**: 视图

The view used for geometry extraction.

## Syntax (C#)
```csharp
public View View { get; set; }
```

## Remarks
If a view-specific version of an element exists, it will be extracted in the
retrieval of geometry. Also, the detail level of the geometry will be taken from the 
view's detail level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting this property with a Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting this property,
if DetailLevel is already set. When DetailLevel is set view-specific geometry can't be
extracted.

