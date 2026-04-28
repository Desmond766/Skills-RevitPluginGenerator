---
kind: property
id: P:Autodesk.Revit.DB.ImageInstance.Width
zh: 宽度
source: html/c135b323-bdcf-4945-6f7b-f2da08bb41fe.htm
---
# Autodesk.Revit.DB.ImageInstance.Width Property

**中文**: 宽度

The width of the ImageInstance.

## Syntax (C#)
```csharp
public double Width { get; set; }
```

## Remarks
If LockProportions is true, then changes to the Width will also result in changes to the Height .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for width results in a height that is more than 30000 feet because LockProportions is set to true.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for width must be between 0 and 30000 feet.

