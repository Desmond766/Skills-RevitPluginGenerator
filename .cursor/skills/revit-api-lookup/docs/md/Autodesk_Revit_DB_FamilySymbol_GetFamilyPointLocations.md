---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.GetFamilyPointLocations
zh: 族类型、族符号
source: html/b25b0bf1-6c01-846b-8dd2-9576e629d13c.htm
---
# Autodesk.Revit.DB.FamilySymbol.GetFamilyPointLocations Method

**中文**: 族类型、族符号

Returns the Point Locations for the Family Symbol.

## Syntax (C#)
```csharp
public IList<FamilyPointLocation> GetFamilyPointLocations()
```

## Remarks
If a family symbol has point references then their locations are returned by this method,
otherwise an empty collection is returned. Examples of FamilySymbol objects that contain point
location are Panels and Flexible Components.

