---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.CycleCounterChanged
source: html/9edec8b1-5f5e-8ccc-afb5-4b2aeb5de23d.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.CycleCounterChanged Property

True if the cycle counter was changed, false otherwise. The cycle counter value is changed when the free form Rebar element is selected and the user press Space key
 -or- by through [!:Autodesk::Revit::DB::Structure::RebarRebarFreeFormAccessor::CycleCounter] property.
 -or- by the server if it considers that the counter reaches the maximum value and reset it (set it to 0).

## Syntax (C#)
```csharp
public bool CycleCounterChanged { get; }
```

