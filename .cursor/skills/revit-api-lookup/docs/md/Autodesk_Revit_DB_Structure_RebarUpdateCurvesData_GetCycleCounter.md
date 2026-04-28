---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetCycleCounter
source: html/64d47c1b-bd88-3166-dfcc-6987c86ea1af.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetCycleCounter Method

Gets the cycle counter that is stored in the rebar.

## Syntax (C#)
```csharp
public int GetCycleCounter()
```

## Returns
Returns the cycle counter.

## Remarks
The cycle counter value is changed when the free form Rebar element is selected and the user press Space key
 -or- by through [!:Autodesk::Revit::DB::Structure::RebarRebarFreeFormAccessor::CycleCounter] property.
 -or- by the server if it considers that the counter reaches the maximum value and reset it (set it to 0).

