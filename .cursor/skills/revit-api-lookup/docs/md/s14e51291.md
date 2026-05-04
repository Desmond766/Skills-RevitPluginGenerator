---
kind: method
id: M:Autodesk.Revit.DB.Outline.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/7be638d8-f794-3247-89d0-39602b2b3f90.htm
---
# Autodesk.Revit.DB.Outline.#ctor Method

Constructor that uses a minimum and maximum XYZ point to initialize the outline.

## Syntax (C#)
```csharp
public Outline(
	XYZ minimumPoint,
	XYZ maximumPoint
)
```

## Parameters
- **minimumPoint** (`Autodesk.Revit.DB.XYZ`) - The minimum point
- **maximumPoint** (`Autodesk.Revit.DB.XYZ`) - The maximum point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

