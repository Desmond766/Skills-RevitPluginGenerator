---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctSizeSettings.Item(Autodesk.Revit.DB.Mechanical.DuctShape)
source: html/04a9f724-107f-17ff-12d5-92a309df53d1.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettings.Item Property

Get the DuctSizes for this DuctShape.

## Syntax (C#)
```csharp
public DuctSizes this[
	DuctShape ductShape
] { get; }
```

## Parameters
- **ductShape** (`Autodesk.Revit.DB.Mechanical.DuctShape`) - The duct shape.

## Returns
The DuctSizes for this DuctShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no DuctSizes for this DuctShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

