---
kind: method
id: M:Autodesk.Revit.DB.FamilyUtils.GetProfileSymbols(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ProfileFamilyUsage,System.Boolean)
source: html/804d7710-829a-4ad9-13ab-fbb5650bfe77.htm
---
# Autodesk.Revit.DB.FamilyUtils.GetProfileSymbols Method

Gets the profile Family Symbols of the document.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetProfileSymbols(
	Document document,
	ProfileFamilyUsage profileFamilyUsage,
	bool oneCurveLoopOnly
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **profileFamilyUsage** (`Autodesk.Revit.DB.ProfileFamilyUsage`) - The profile family usage.
- **oneCurveLoopOnly** (`System.Boolean`) - Whether or not to return only profiles with one curve loop.

## Returns
The set of profile Family Symbol element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

