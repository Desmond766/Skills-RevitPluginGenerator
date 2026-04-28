---
kind: property
id: P:Autodesk.Revit.DB.DividedSurface.IsComponentMirrored
source: html/e4095192-0151-0abf-7ff3-522dc249d306.htm
---
# Autodesk.Revit.DB.DividedSurface.IsComponentMirrored Property

Whether the pattern is mirror-imaged.

## Syntax (C#)
```csharp
public bool IsComponentMirrored { get; set; }
```

## Remarks
This property has no effect unless a pattern
is selected (the ObjectType property is not Nothing nullptr a null reference ( Nothing in Visual Basic) ).
Changing this flag effectively reflects the component
through its YZ-plane.

