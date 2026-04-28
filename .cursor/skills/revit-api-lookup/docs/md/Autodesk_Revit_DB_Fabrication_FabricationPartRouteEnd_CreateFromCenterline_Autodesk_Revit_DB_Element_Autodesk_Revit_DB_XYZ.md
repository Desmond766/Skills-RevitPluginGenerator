---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd.CreateFromCenterline(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ)
source: html/81ff0ae2-1df5-6e62-cd94-3c8c31dc92ab.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd.CreateFromCenterline Method

Create fabrication routing end from centerline point on straight element.

## Syntax (C#)
```csharp
public static FabricationPartRouteEnd CreateFromCenterline(
	Element element,
	XYZ ptAt
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The straight element that the centerline is on.
- **ptAt** (`Autodesk.Revit.DB.XYZ`) - A point along the straight element where the fitting to be cut in should be positioned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

