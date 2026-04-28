---
kind: method
id: M:Autodesk.Revit.DB.ImagePlacementOptions.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.BoxPlacement)
source: html/c7c4ecc7-d14f-31ed-0603-93defe113cef.htm
---
# Autodesk.Revit.DB.ImagePlacementOptions.#ctor Method

Constructs a new ImagePlacementOptions for placing an ImageInstance

## Syntax (C#)
```csharp
public ImagePlacementOptions(
	XYZ location,
	BoxPlacement placementPoint
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The location where the image will be placed
- **placementPoint** (`Autodesk.Revit.DB.BoxPlacement`) - The point of the image that will be aligned to the location in the view

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

