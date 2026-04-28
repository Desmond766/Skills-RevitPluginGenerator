---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCombination.GetCaseAndCombinationIds
source: html/c1dc497b-5eaf-5ec9-2cb3-70eb5242a1ed.htm
---
# Autodesk.Revit.DB.Structure.LoadCombination.GetCaseAndCombinationIds Method

Returns collection of the load combination case and combination IDs.

## Syntax (C#)
```csharp
public IList<ElementId> GetCaseAndCombinationIds()
```

## Returns
A collection of the load combination case and combination IDs.

## Remarks
Load combination components could be load cases or other load combinations.
 To set them with factors use [M:Autodesk.Revit.DB.Structure.LoadCombination.SetComponents(System.Collections.Generic.IList`1{Autodesk.Revit.DB.Structure.LoadComponent})] method.

