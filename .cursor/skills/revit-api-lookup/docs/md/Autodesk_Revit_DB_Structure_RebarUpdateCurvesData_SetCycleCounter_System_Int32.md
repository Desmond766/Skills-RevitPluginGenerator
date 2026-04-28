---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetCycleCounter(System.Int32)
source: html/677618c3-c7ca-0077-231b-bcc6e3ab293c.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetCycleCounter Method

Sets the cycle counter to a specific value.

## Syntax (C#)
```csharp
public void SetCycleCounter(
	int cycleCounter
)
```

## Parameters
- **cycleCounter** (`System.Int32`)

## Remarks
The actual value is set into the rebar after the curves computation. This function can be called to reset the counter to zero or to another value. The cycle counter value is changed when the free form Rebar element is selected and the user press Space key
 -or- by through [!:Autodesk::Revit::DB::Structure::RebarRebarFreeFormAccessor::CycleCounter] property.
 -or- by the server if it considers that the counter reaches the maximum value and reset it (set it to 0).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for cycleCounter is negative.

