---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.GetFixtureUnits
source: html/ca222d0d-8eb9-2a9c-625b-3c243e0d9c29.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.GetFixtureUnits Method

Gets the fixture units of this piping system.

## Syntax (C#)
```csharp
public double GetFixtureUnits()
```

## Remarks
The system fixture units is calculated in the non-blocking evaluation framework. The caller may set up callbacks that react to the asynchronous calculation results.
 If no callback is set up (e.g, called from third-party applications), the calculation is automatically switched to synchronous calculation so the caller
 can access the up-to-date result. Similarly, the public method get_ParameterValue(BuiltInParameter.RBS_PIPE_SYSTEM_FIXTURE_UNIT_PARAM) has the same behavior.
 Due to this change, the parameter RBS_PIPE_SYSTEM_FIXTURE_UNIT_PARAM no longer supports dynamic model update.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fixture units can not be calculated for this system.

