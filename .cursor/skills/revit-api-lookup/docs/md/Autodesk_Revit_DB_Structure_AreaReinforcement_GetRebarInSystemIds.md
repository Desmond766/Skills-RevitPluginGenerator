---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetRebarInSystemIds
source: html/164ad9af-4034-ca8b-d7f6-2e108becf7e1.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetRebarInSystemIds Method

Returns the ids of the RebarInSystem elements owned by the AreaReinforcement
 element.

## Syntax (C#)
```csharp
public IList<ElementId> GetRebarInSystemIds()
```

## Remarks
The RebarInSystem elements are only created if
 ReinforcementSettings.HostStructuralRebar is set to true. If that setting
 is false, this function returns an empty array.

