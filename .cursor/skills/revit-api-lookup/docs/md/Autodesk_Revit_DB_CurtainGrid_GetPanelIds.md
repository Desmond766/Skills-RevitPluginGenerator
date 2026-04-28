---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.GetPanelIds
source: html/e1120452-d2b1-886f-e080-95ba0fa9b79b.htm
---
# Autodesk.Revit.DB.CurtainGrid.GetPanelIds Method

Gets all ElementIds of the panels of the curtain grid.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetPanelIds()
```

## Returns
The panel ElementIds

## Remarks
For curtain walls, the ElementIds in this set are of either Panel or Wall Elements. 
For curtain systems, ElementIds are of Panel Elements.

