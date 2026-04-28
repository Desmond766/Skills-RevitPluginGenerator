---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetCustomHandleTag
source: html/019e2c30-c247-2d8a-476b-25be0f547dbb.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetCustomHandleTag Method

Returns the handle tag of the RebarConstrainedHandle.
 This is valid only for Free Form Rebar.

## Syntax (C#)
```csharp
public int GetCustomHandleTag()
```

## Returns
Returns the handle tag of the RebarConstrainedHandle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Constrained rebar is a shape driven rebar element.

