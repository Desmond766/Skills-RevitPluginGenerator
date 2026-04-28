---
kind: method
id: M:Autodesk.Revit.DB.Structure.PathReinforcement.GetRebarInSystemIds
source: html/66d7ac46-c022-c65a-0c18-4fdedb77c5f6.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.GetRebarInSystemIds Method

Returns the ids of the RebarInSystem elements owned by the PathReinforcement
 element.

## Syntax (C#)
```csharp
public IList<ElementId> GetRebarInSystemIds()
```

## Remarks
The RebarInSystem elements are only created if
 ReinforcementSettings.HostStructuralRebar is set to true. If that setting
 is false, this function returns an empty array.

