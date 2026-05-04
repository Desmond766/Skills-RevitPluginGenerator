---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLevelIdByHeight(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element)
source: html/b6142529-84ac-41b9-f0d5-ac0105e430c2.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLevelIdByHeight Method

Gets the level if by the height of the element.

## Syntax (C#)
```csharp
public static ElementId GetLevelIdByHeight(
	ExporterIFC exporterIFC,
	Element elem
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **elem** (`Autodesk.Revit.DB.Element`) - The element.

## Returns
The level id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

