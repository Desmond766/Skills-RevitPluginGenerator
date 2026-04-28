---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetLevelInfo(Autodesk.Revit.DB.ElementId)
source: html/c404ab36-866c-8ac8-a8b1-c60d963791ed.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetLevelInfo Method

Returns an object representing the information about a level in the document.

## Syntax (C#)
```csharp
public IFCLevelInfo GetLevelInfo(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id.

## Returns
The level information.

## Remarks
Level information is currently automatically collected and cached in the ExporterIFC
 object. This method returns the cached information for a given level,
 which is often needed during export of particular building elements which reference levels, as well
 as to implement automatic wall and column splitting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

