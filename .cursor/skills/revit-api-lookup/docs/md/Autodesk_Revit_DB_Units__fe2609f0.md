---
kind: type
id: T:Autodesk.Revit.DB.Units
source: html/89d89465-897f-4105-b935-27edf67aab3e.htm
---
# Autodesk.Revit.DB.Units

A document's default settings for formatting numbers with units.

## Syntax (C#)
```csharp
public class Units : IDisposable
```

## Remarks
The Units class represents a document's default settings for
 formatting numbers with units as strings. It contains a
 FormatOptions object for each unit
 type as well as settings related to decimal symbol and digit
 grouping. The Units class stores a FormatOptions object for every valid
 unit type, but not all of them can be directly modified. Some, like
 UT_Number and UT_SiteAngle, have fixed definitions. Others have
 definitions which are automatically derived from other unit types.
 For example, UT_SheetLength is derived from UT_Length and
 UT_ForceScale is derived from UT_Force. See
 IsModifiableUnitType() and
 GetModifiableUnitTypes() .

