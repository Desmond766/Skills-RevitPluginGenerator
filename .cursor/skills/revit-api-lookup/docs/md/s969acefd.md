---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.RemoveCoping(Autodesk.Revit.DB.FamilyInstance)
zh: 族实例
source: html/c0ccd04c-f952-011f-4b0f-25862792d619.htm
---
# Autodesk.Revit.DB.FamilyInstance.RemoveCoping Method

**中文**: 族实例

Removes a coping (cut) from a steel beam.

## Syntax (C#)
```csharp
public bool RemoveCoping(
	FamilyInstance cutter
)
```

## Parameters
- **cutter** (`Autodesk.Revit.DB.FamilyInstance`) - A steel beam or column for which this beam currently has a coping cut. May not be Nothing nullptr a null reference ( Nothing in Visual Basic) or itself.

## Remarks
This function corresponds to Tools -> Remove coping in Revit Structure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when 'cutter' is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when 'cutter' refers to this instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails.

