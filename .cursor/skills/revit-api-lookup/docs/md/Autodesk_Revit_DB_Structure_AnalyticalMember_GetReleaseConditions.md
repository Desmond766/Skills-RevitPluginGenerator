---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.GetReleaseConditions
source: html/95da8025-e532-bbfa-3e5a-564c2710e8d3.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.GetReleaseConditions Method

Gets the release conditions associated with this Analytical Member.

## Syntax (C#)
```csharp
public IList<ReleaseConditions> GetReleaseConditions()
```

## Returns
Returns a collection of Release Conditions associated with this Analytical Member. Empty collection will be returned if Analytical Member doesn't have any Release Conditions.
 End to which release conditions will be added is defined by setting [!:Autodesk::Revit::DB::Structure::ReleaseConditions::Position] 
 property in provided release conditions object.

