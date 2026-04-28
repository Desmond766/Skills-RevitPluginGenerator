---
kind: property
id: P:Autodesk.Revit.DB.ImageInstance.HeightScale
source: html/c0c41a38-7554-4472-479a-794b561a6534.htm
---
# Autodesk.Revit.DB.ImageInstance.HeightScale Property

The factor applied to the ImageType to calculate the Height of the ImageInstance.

## Syntax (C#)
```csharp
public double HeightScale { get; set; }
```

## Remarks
If LockProportions is true, then changes to the HeightScale will also result in changes to the WidthScale .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for heightScale results in a height that is more than 30000 feet.
 -or-
 When setting this property: The given value for heightScale results in a width that is more than 30000 feet because LockProportions is set to true.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for heightScale must be non-negative.

