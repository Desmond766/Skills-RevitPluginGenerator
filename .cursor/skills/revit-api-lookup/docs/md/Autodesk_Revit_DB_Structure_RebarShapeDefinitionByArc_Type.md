---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.Type
zh: 类型
source: html/55d48817-1a60-05eb-dfeb-d053ac80328e.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.Type Property

**中文**: 类型

Among those rebar shapes defined by an arc, specify which kind.

## Syntax (C#)
```csharp
public RebarShapeDefinitionByArcType Type { get; set; }
```

## Remarks
This property may be explicitly set to Arc or LappedCircle.
 But to set the property to Spiral, you must call SetArcTypeSpiral()
 and provide default values for the height, pitch, and finishing turns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The arc type cannot be set directly
 to Spiral. Instead, call SetArcTypeSpiral() to provide defaults
 for spiral parameters.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

