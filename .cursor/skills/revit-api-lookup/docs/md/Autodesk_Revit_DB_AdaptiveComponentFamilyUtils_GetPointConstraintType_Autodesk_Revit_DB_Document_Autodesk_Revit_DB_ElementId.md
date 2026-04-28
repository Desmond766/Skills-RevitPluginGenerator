---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPointConstraintType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/26f04a97-ab5a-2180-9db1-b20749c4ab82.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPointConstraintType Method

Gets constrain type of an Adaptive Shape Handle Point.

## Syntax (C#)
```csharp
public static AdaptivePointConstraintType GetPointConstraintType(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
Constraint type of the Adaptive Shape Handle Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to a Shape Handle Point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

