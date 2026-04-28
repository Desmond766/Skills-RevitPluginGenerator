---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetAllRebarShapeIds
zh: 钢筋、配筋
source: html/a4226864-acec-b0b9-ddb2-fae12b48f378.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetAllRebarShapeIds Method

**中文**: 钢筋、配筋

Gets the ids of the RebarShapes elements that defines the shapes of the rebar.

## Syntax (C#)
```csharp
public IList<ElementId> GetAllRebarShapeIds()
```

## Returns
Returns the ids of the RebarShapes elements that defines the shapes of the rebar.

## Remarks
If multiple bars in the set has the same shape id, this id will be reported only one in the resulted array.

