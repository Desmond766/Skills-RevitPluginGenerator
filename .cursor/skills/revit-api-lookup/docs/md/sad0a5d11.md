---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSizeSettings.AddSize(Autodesk.Revit.DB.Mechanical.DuctShape,Autodesk.Revit.DB.MEPSize)
source: html/ed95c206-c4f5-8aff-9c88-ff393dbb333e.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettings.AddSize Method

Inserts a new MEPSize in to the duct size settings. The duct shape determines the location of the new size in the size table.

## Syntax (C#)
```csharp
public void AddSize(
	DuctShape shape,
	MEPSize sizeInfo
)
```

## Parameters
- **shape** (`Autodesk.Revit.DB.Mechanical.DuctShape`) - The shape of duct.
- **sizeInfo** (`Autodesk.Revit.DB.MEPSize`) - The new MEPSize to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Throws if there is no size set determined by the duct shape
 or there is already the same size in the size set determined by the duct shape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if the function is called during iterating the size set.

