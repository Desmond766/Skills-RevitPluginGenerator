---
kind: type
id: T:Autodesk.Revit.DB.IFamilyLoadOptions
source: html/d447ed92-74e1-2125-dd0a-38a5ae85ce53.htm
---
# Autodesk.Revit.DB.IFamilyLoadOptions

An interface class which provide the callback for family load options.

## Syntax (C#)
```csharp
public interface IFamilyLoadOptions
```

## Remarks
If the family is not loaded, or if the family is loaded but unchanged, the situation will never trigger and OnFamilyFound(Boolean, Boolean ) and OnSharedFamilyFound(Family, Boolean, FamilySource , Boolean ) will not be called.
 Only if the family is loaded and changed should the interface methods be called.

