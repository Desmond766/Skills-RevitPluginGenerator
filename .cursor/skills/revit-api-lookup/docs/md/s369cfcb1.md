---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetSplittingElements(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/bdf7331d-978c-3e94-bf05-43f2e6394aaf.htm
---
# Autodesk.Revit.DB.PartUtils.GetSplittingElements Method

Identifies the elements ( reference planes, levels, grids ) that were used to create the part.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetSplittingElements(
	Document document,
	ElementId partId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The source document of the part.
- **partId** (`Autodesk.Revit.DB.ElementId`) - The part id.

## Returns
The elements that created the part. Empty if partId is not a Part or Part is not divided.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

