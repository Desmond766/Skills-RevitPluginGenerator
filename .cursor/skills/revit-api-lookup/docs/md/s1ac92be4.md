---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.AddCoping(Autodesk.Revit.DB.FamilyInstance)
zh: 族实例
source: html/a0fc20d1-36fc-a230-d41f-f7163184d328.htm
---
# Autodesk.Revit.DB.FamilyInstance.AddCoping Method

**中文**: 族实例

Adds a coping (cut) to a steel beam.

## Syntax (C#)
```csharp
public bool AddCoping(
	FamilyInstance cutter
)
```

## Parameters
- **cutter** (`Autodesk.Revit.DB.FamilyInstance`) - A steel beam or column. May not be Nothing nullptr a null reference ( Nothing in Visual Basic) or itself.

## Remarks
This beam will be cut to fit another element, the cutter. The cut will include an offset
determined by the parameter STRUCTURAL_COPING_DISTANCE. The parameter affects all copings
on this element. This function corresponds to Tools -> Coping in Revit Structure.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when 'cutter' is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when 'cutter' refers to this instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails.

