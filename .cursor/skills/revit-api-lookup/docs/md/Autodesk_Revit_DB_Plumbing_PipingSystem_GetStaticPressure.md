---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.GetStaticPressure
source: html/f50549b4-7aca-2766-36bb-aa6b53dfb5f5.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.GetStaticPressure Method

Gets the static pressure of this piping system.

## Syntax (C#)
```csharp
public double GetStaticPressure()
```

## Remarks
The system static pressure is calculated in the non-blocking evaluation framework. The caller may set up callbacks that react to the asynchronous calculation results.
 If no callback is set up (e.g, called from third-party applications), the calculation is automatically switched to synchronous calculation so the caller
 can access the up-to-date result. Similarly, the public method get_ParameterValue(BuiltInParameter.RBS_PIPE_STATIC_PRESSURE) has the same behavior. Due to this
 change, the parameter RBS_PIPE_STATIC_PRESSURE no longer supports dynamic model update.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The static pressure can not be calculated for this system.

