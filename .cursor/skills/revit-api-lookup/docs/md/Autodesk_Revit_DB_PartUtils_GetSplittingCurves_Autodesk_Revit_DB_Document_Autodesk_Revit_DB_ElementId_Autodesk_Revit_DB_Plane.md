---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetSplittingCurves(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Plane@)
source: html/c628a082-da8c-7698-5b76-d2eaf49d6381.htm
---
# Autodesk.Revit.DB.PartUtils.GetSplittingCurves Method

Identifies the curves that were used to create the part and the plane in which they reside.

## Syntax (C#)
```csharp
public static IList<Curve> GetSplittingCurves(
	Document document,
	ElementId partId,
	out Plane sketchPlane
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The source document of the part.
- **partId** (`Autodesk.Revit.DB.ElementId`) - The part id.
- **sketchPlane** (`Autodesk.Revit.DB.Plane %`) - The plane in which the division curves were sketched.

## Returns
The curves that created the part. Empty if partId is not a part or Part is not divided.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

