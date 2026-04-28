---
kind: property
id: P:Autodesk.Revit.DB.View.SketchPlane
zh: 视图
source: html/2531634f-f0d4-3cb3-7f8a-fe809d33a61f.htm
---
# Autodesk.Revit.DB.View.SketchPlane Property

**中文**: 视图

The sketch plane assigned to the view for model curve creation.

## Syntax (C#)
```csharp
public SketchPlane SketchPlane { get; set; }
```

## Remarks
If this property is set in when the current work plane is visible, the updated work plane will not be shown until the current 
transaction is committed. Therefore it is recommended the Add-On commits the transaction before performing UI operations (for example, PickPoint).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting the property to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting the property to a sketch plane that cannot be used to create model elements,
or when the input sketch plane is orthogonal to the view orientation.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting the property to a view that does not permit model curve creation, or when other errors occur.

