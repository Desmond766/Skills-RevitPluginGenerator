---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetLevelInfos
source: html/c7f1c52a-a0d0-cc15-4a08-1c476bb7509b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetLevelInfos Method

Returns a collection containing the information about all levels in the document.

## Syntax (C#)
```csharp
public IDictionary<ElementId, IFCLevelInfo> GetLevelInfos()
```

## Returns
The collection of level information.

## Remarks
Level information is currently automatically collected and cached in the ExporterIFC
 object. This method returns the cached information which is often needed during export
 of particular building elements which reference levels, as well as to implement automatic
 wall and column splitting.

