---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.GetUnlockedPanelIds
source: html/5571b4c3-08f4-c300-5d4e-90d405b1cb52.htm
---
# Autodesk.Revit.DB.CurtainGrid.GetUnlockedPanelIds Method

Gets all ElementIds of the unlocked panels of the curtain grid.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetUnlockedPanelIds()
```

## Returns
The unlocked panel ElementIds

## Remarks
For curtain walls, the ElementIds in this set are of either Panel or Wall Elements. 
For curtain systems, ElementIds are of Panel Elements.

