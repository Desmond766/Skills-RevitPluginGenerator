---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetSplittingCurves(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/d99625f8-3fc4-aace-bfe7-b1705ea2d195.htm
---
# Autodesk.Revit.DB.PartUtils.GetSplittingCurves Method

Identifies the curves that were used to create the part.

## Syntax (C#)
```csharp
public static IList<Curve> GetSplittingCurves(
	Document document,
	ElementId partId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The source document of the part.
- **partId** (`Autodesk.Revit.DB.ElementId`) - The part id.

## Returns
The curves that created the part. Empty if partId is not a Part or Part is not divided.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

