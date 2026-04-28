---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.GetFlow
source: html/949e7120-6845-a62f-6156-b0504e243f84.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.GetFlow Method

Gets the flow of this piping system.

## Syntax (C#)
```csharp
public double GetFlow()
```

## Remarks
The system flow is calculated in the non-blocking evaluation framework. The caller may set up callbacks that react to the asynchronous calculation results.
 If no callback is set up (e.g, called from third-party applications), the calculation is automatically switched to synchronous calculation so the caller
 can access the up-to-date result. Similarly, the public method get_ParameterValue(BuiltInParameter.RBS_PIPE_FLOW_PARAM) has the same behavior. Due to this
 change, the parameter RBS_PIPE_FLOW_PARAM no longer supports dynamic model update.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The flow can not be calculated for this system.

