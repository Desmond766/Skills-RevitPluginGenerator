---
kind: method
id: M:Autodesk.Revit.DB.LevelAssociationData.GetLevelAssociationData(Autodesk.Revit.DB.Element)
source: html/46a006d0-da74-8d5d-15b6-9db0d62ba7e4.htm
---
# Autodesk.Revit.DB.LevelAssociationData.GetLevelAssociationData Method

Returns LevelAssociationData associated with this element, if it exists.

## Syntax (C#)
```csharp
public static LevelAssociationData GetLevelAssociationData(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element from which we try to obtain LevelAssociationData.

## Remarks
If the input element doesn't have LevelAssociationData than it retuns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

