---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.MakeAdaptivePoint(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.AdaptivePointType)
source: html/8225009b-bcf6-7ce8-8d0a-4c7b3909b0e6.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.MakeAdaptivePoint Method

Makes Reference Point an Adaptive Point or makes an Adaptive Point a Reference Point.

## Syntax (C#)
```csharp
public static void MakeAdaptivePoint(
	Document doc,
	ElementId refPointId,
	AdaptivePointType type
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id
- **type** (`Autodesk.Revit.DB.AdaptivePointType`) - The Adaptive Point Type

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

