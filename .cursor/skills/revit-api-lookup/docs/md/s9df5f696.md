---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsSingle
source: html/d9e95eca-6e25-eb15-3ee9-49e61f9b5e2b.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsSingle Method

Sets the Layout Rule property of rebar set to Single.

## Syntax (C#)
```csharp
public void SetLayoutAsSingle()
```

## Remarks
Only one bar will remain, which is at the position of rebar plane

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

