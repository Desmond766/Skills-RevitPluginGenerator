---
kind: property
id: P:Autodesk.Revit.DB.ImageInstance.WidthScale
source: html/c938de3b-849b-11a0-c80b-cb852b65c64b.htm
---
# Autodesk.Revit.DB.ImageInstance.WidthScale Property

The factor applied to the width of the ImageType to calculate the Width of the ImageInstance.

## Syntax (C#)
```csharp
public double WidthScale { get; set; }
```

## Remarks
If LockProportions is true, then changes to the WidthScale will also result in changes to the HeightScale .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for widthScale results in a width that is more than 30000 feet.
 -or-
 When setting this property: The given value for widthScale results in a height that is more than 30000 feet because LockProportions is set to true.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for widthScale must be non-negative.

