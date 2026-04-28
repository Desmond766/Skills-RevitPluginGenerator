---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.ValidateViewType(Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/682c6dd1-ee09-db45-91cf-85fba6b9dff6.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.ValidateViewType Method

Validates the incoming view type. As of today, the only allowed view type is Plan.

## Syntax (C#)
```csharp
public static bool ValidateViewType(
	DirectShapeTargetViewType targetViewType
)
```

## Parameters
- **targetViewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`)

## Returns
True if %targetViewType% is DirectShapeTargetViewType::Plan

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

