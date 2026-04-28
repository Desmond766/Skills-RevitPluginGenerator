---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetMEPAnalyticalModelData(Autodesk.Revit.DB.Element)
source: html/ba3e03e0-5a6c-9aa4-bafd-266af8958838.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetMEPAnalyticalModelData Method

Gets the MEP analytical model data of the specified element.

## Syntax (C#)
```csharp
public static MEPAnalyticalModelData GetMEPAnalyticalModelData(
	Element pElement
)
```

## Parameters
- **pElement** (`Autodesk.Revit.DB.Element`) - The element that owns the MEP analytical model data.

## Returns
The MEP analytical model data of this element, null if not available.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

