---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPointConstraintType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.AdaptivePointConstraintType)
source: html/3d4c1b04-f574-7ff5-cac3-0c14e80b74ee.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPointConstraintType Method

Sets constrain type of an Adaptive Shape Handle Point.

## Syntax (C#)
```csharp
public static void SetPointConstraintType(
	Document doc,
	ElementId refPointId,
	AdaptivePointConstraintType constraintType
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id
- **constraintType** (`Autodesk.Revit.DB.AdaptivePointConstraintType`) - Constraint type of the Adaptive Shape Handle Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to a Shape Handle Point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

