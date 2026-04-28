---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckConstructionSetElement(Autodesk.Revit.DB.ElementId)
source: html/88be30fb-288e-01ee-3ca3-c1b303ee8b56.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckConstructionSetElement Method

Checks that the construction set ElementId is acceptable.

## Syntax (C#)
```csharp
public bool CheckConstructionSetElement(
	ElementId constructionSetElementId
)
```

## Parameters
- **constructionSetElementId** (`Autodesk.Revit.DB.ElementId`) - The construction set ElementId to be checked.

## Returns
True if the construction set ElementId is a valid construction set element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

