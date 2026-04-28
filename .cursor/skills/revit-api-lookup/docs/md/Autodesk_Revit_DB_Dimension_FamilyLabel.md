---
kind: property
id: P:Autodesk.Revit.DB.Dimension.FamilyLabel
zh: 尺寸标注、标注
source: html/cd34752d-ff4f-e6f7-05e5-82405af00e52.htm
---
# Autodesk.Revit.DB.Dimension.FamilyLabel Property

**中文**: 尺寸标注、标注

The family parameter label of the dimension.

## Syntax (C#)
```csharp
public FamilyParameter FamilyLabel { get; set; }
```

## Remarks
A dimension only can be labeled to a family parameter in a family document.
When the dimension is labeled by a reporting parameter, the dimension value drives the parameter value.
When the parameter is labeled by a non-reporting, the value of the parameter drives the dimension.
If the dimension is multi-segmented, each segment of the dimension is driven by the same parameter value.
Multi-segmented dimensions cannot be labeled by reporting parameters.
To unbind the family parameter, set this property to Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the family parameter's ParameterType is not suitable for this dimension.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when dimension can not be labeled.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when failed to get the BuiltInParameter DIM_LABEL.

