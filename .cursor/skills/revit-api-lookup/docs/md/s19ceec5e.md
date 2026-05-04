---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.GetStraightsThatWereNotChanged
source: html/644c47d9-806b-cd68-bf3e-0f8997c89f50.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.GetStraightsThatWereNotChanged Method

Gets the set of fabrication part straights that were not changed due to either there was no corresponding part in the service or the size was out of range.

## Syntax (C#)
```csharp
public ISet<ElementId> GetStraightsThatWereNotChanged()
```

## Remarks
This set of element identifiers is only available after the ChangeService or ChangeSize method has been invoked, and returns FabricationNetworkChangeServiceResult::Enum::PartialFailure.

