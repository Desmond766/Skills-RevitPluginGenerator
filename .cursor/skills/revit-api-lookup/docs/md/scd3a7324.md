---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.CycleCounter
source: html/dc7ccd08-60d5-3cc8-e99a-66e87cbdbc13.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.CycleCounter Property

Identifies the cycle counter. It can be zero or a pozitive number. Its value is changed when the free form Rebar element is selected and the user press Space key
 -or- through the setter of this property
 -or- by the server if it considers that the counter reaches the maximum value and reset it (set it to 0).
 This property can be accessed just for Rebars that are controlled by a server.

## Syntax (C#)
```csharp
public int CycleCounter { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for cycleCounter is negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.

