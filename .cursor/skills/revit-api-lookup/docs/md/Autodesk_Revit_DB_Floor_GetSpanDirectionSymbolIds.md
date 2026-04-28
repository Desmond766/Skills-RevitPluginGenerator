---
kind: method
id: M:Autodesk.Revit.DB.Floor.GetSpanDirectionSymbolIds
zh: 楼板、板、地板
source: html/253ac763-7b9b-7efb-8eca-5b6599fd8d5f.htm
---
# Autodesk.Revit.DB.Floor.GetSpanDirectionSymbolIds Method

**中文**: 楼板、板、地板

Retrieves span direction symbol ElementIds.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetSpanDirectionSymbolIds()
```

## Returns
A collection of Element Ids of span direction symbol elements

## Remarks
The element types of the Ids of these symbols
determine if the floor has one way or two way span direction graphics.

