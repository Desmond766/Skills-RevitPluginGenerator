---
kind: property
id: P:Autodesk.Revit.DB.DividedSurface.IsComponentFlipped
source: html/82f331a5-8933-d7f7-8be7-e8dbad1236c5.htm
---
# Autodesk.Revit.DB.DividedSurface.IsComponentFlipped Property

Whether the pattern is flipped.

## Syntax (C#)
```csharp
public bool IsComponentFlipped { get; set; }
```

## Remarks
This property has no effect unless a pattern
is selected (the ObjectType property is not Nothing nullptr a null reference ( Nothing in Visual Basic) ).
Changing this flag effectively reflects the component
through its XY-plane, which is equivalent to reflecting
it through the original surface.

