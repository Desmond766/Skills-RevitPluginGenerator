---
kind: property
id: P:Autodesk.Revit.DB.ImageInstance.Height
zh: 高度
source: html/ba996fed-0624-689f-08a8-1488cdb1292a.htm
---
# Autodesk.Revit.DB.ImageInstance.Height Property

**中文**: 高度

The height of the ImageInstance.

## Syntax (C#)
```csharp
public double Height { get; set; }
```

## Remarks
If LockProportions is true, then changes to the Height will also result in changes to the Width .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for height results in a width that is more than 30000 feet because LockProportions is set to true.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for height must be between 0 and 30000 feet.

